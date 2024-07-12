using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FoodBehaviour : MonoBehaviour
{
	[SerializeField] Food[] foodsPrefs;

    GameField gameField;

    private void Awake()
    {

    }

    private void Start()
    {       
        gameField = GameObject.Find("Game Field").GetComponent<GameField>();

        SpawnApple();
    }
    void Update()
    {

    }

    public void SpawnApple()
	{
        Food newFood = Instantiate(foodsPrefs[0]);//Food - some food
        newFood.transform.position = gameField.GetRandomPositionForFoodSpawn();
        gameField.PlaceOnField(newFood.gameObject);

        newFood.FoodHasBeenEaten += (Food food) => {
            gameField.GameUI.AddScore(food.Points);
            Destroy(food.gameObject);
            SpawnApple();
        };
    }
}

