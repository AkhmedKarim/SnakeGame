using System.Collections.Generic;
using UnityEngine;

public class GameField : MonoBehaviour,
    IGameFieldUI
{
    const int FIELD_WIDTH = 26, FIELD_HEGHT = 26;
    static Vector2[] AllFieldsCells;

    static void InitFieldCells()
    {
        AllFieldsCells = new Vector2[FIELD_HEGHT * FIELD_WIDTH];

        int i = 0;
        for (int y = 0; y < FIELD_HEGHT; y++)
        {
            for (int x = 0; x < FIELD_WIDTH; x++)
            {
                AllFieldsCells[i++] = new Vector2(x, y);
            }
        }
    }

    SnakeBehaviour snake;
    //FoodBehaviour foodSpawner;
    [SerializeField] List<Food> foodList;
    [SerializeField] List<GameObject> gameObjectList;

    GameUI gameUI;
    public GameUI GameUI => gameUI;
    SnakeBehaviour IGameFieldUI.Snake => snake;
    Transform IGameFieldUI.transform => transform;

    Transform foodContainer, snakeContainer;

    private void Awake()
    {
        if(AllFieldsCells == null)
            InitFieldCells();
        foodList = new List<Food>();
        gameObjectList = new List<GameObject>();


        foodContainer = transform.Find("Food Container");
        if (foodContainer == null)
        {
            foodContainer = new GameObject("Food Container").transform;
            foodContainer.parent = transform;
        }

        snakeContainer = transform.Find("Snake Container");
        if (snakeContainer == null)
        {
            snakeContainer = new GameObject("Snake Container").transform;
            snakeContainer.parent = transform;
        }

        gameUI = new GameUI(onGameField: this);
    }

    void Start()
    {

    }

    void Update()
    {
        gameUI.Update();
    }

    public void StayInside(Transform obj)
    {
        if (obj.position.x >= FIELD_WIDTH)
        {
            obj.position = new Vector3(0, obj.position.y, obj.position.z);
        }
        else if (obj.position.x < 0)
        {
            obj.position = new Vector3(FIELD_WIDTH - 1, obj.position.y, obj.position.z);
        }

        if (obj.position.y >= FIELD_HEGHT)
        {
            obj.position = new Vector3(obj.position.x, 0, obj.position.z);
        }
        else if (obj.position.y < 0)
        {
            obj.position = new Vector3(obj.position.x, FIELD_HEGHT - 1, obj.position.z);
        }
    }

    public void PlaceOnField(GameObject @object)
    {
        if (@object.TryGetComponent(out SnakeBehaviour snake))
        {
            if (this.snake != null)
            {
                Destroy(snake.gameObject);
            }

            this.snake = snake;
            gameUI.SubmitOnSnakeDiead();

            @object.transform.parent = snakeContainer;
        }
        else if (@object.TryGetComponent(out Food food))
        {
            foodList.Add(food);
            @object.transform.parent = foodContainer;
        }
        else if (@object.name.StartsWith("part"))
        {
            gameObjectList.Add(@object);
            @object.transform.parent = snakeContainer;
        }
        //else if (@object.TryGetComponent(out FoodBehaviour foodSpawner))
        //{
        //    if (this.foodSpawner != null)
        //    {
        //        Destroy(foodSpawner.gameObject);
        //    }

        //    this.foodSpawner = foodSpawner;
        //    @object.transform.parent = foodContainer;
        //}
        else
        {
            gameObjectList.Add(@object);
            @object.transform.parent = transform;
        }

        
    }

    public void RemoveFromField(GameObject @object)
    {
        if (@object.TryGetComponent(out SnakeBehaviour snake))
        {
            if (this.snake != null)
            {
                snake = null;
            }
        }
        else if (@object.TryGetComponent(out Food food))
        {
            foodList.Remove(food);
        }
      
        else
        {
            gameObjectList.Remove(@object);
        }
    }

    public Vector2 GetRandomPositionForFoodSpawn()
    {
        List<Vector2> occupiedPositions = new List<Vector2>();
        if (snake != null)
            occupiedPositions.AddRange(snake.GetAllSnakeBodyPartsPosition());
        foreach (var item in foodList)
        {
            occupiedPositions.Add(item.transform.position);
        }

        if (occupiedPositions.Count == AllFieldsCells.Length)
        {
            //пасхалка, гра завершена
            return new Vector2(-1, -1);
        }

        var cellsWitoutSnake = new List<Vector2>();
        cellsWitoutSnake.AddRange(AllFieldsCells);
        int i = 0;
        while (i < occupiedPositions.Count)
        {
            while (cellsWitoutSnake.Contains(occupiedPositions[i]))
            {
                cellsWitoutSnake.Remove(occupiedPositions[i]);
            }
            i++;
        }

        return cellsWitoutSnake[Random.Range(0, cellsWitoutSnake.Count)];
    }

    public bool TryGetFood(Vector2 headPosition, out Food food)
    {
        foreach (Food _food in foodList)
        {
            if ((Vector2)_food.transform.position == headPosition)
            {
                food = _food;
                return true;
            }
        }

        food = null;
        return false;
    }


}