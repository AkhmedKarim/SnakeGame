using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class SnakeBehaviour : MonoBehaviour
{
    [SerializeField] AudioClip deadSound;
    public UnityAction SnakeDead;

    SnakeHead snakeHead;
    SnakeBody snakeBody;
    bool isAlive;

    public Vector2Int HeadPosition
    {
        get => new Vector2Int(
            (int)transform.position.x,
            (int)transform.position.y
            );
    }
    public SnakeDirection HeadDirection => snakeHead.InputDirection;


    [SerializeField] Sprite bodySprite, cornerSprite, teilSprite;

    GameField gameField;
    public GameField GameField => gameField;

    private void Awake()
    {
        isAlive = true;

        snakeHead = new SnakeHead(snakeHandler: this);
        snakeBody = new SnakeBody(snakeHandler: this);

        snakeBody.SetSprites(bodySprite, cornerSprite, teilSprite);
    }

    void Start()
	{
        Debug.Log(ScoreHandler.scoresFilePath);
        gameField = GameObject.Find("Game Field").GetComponent<GameField>();
        gameField.PlaceOnField(gameObject);

        moveTimerMax = GetSnakeSpeedByDifficultController();

    }

    float GetSnakeSpeedByDifficultController()
    {
        switch (DifficultController.currentDifficult)
        {
            default:
            case DifficultController.Difficult.Easy:
                return 0.5f;
            case DifficultController.Difficult.Medium:
                return 0.25f;
            case DifficultController.Difficult.Hard:
                return 0.1f;
        }
    }

	float moveTimer, moveTimerMax;
	void Update()
	{
        InputController();

        if (moveTimer >= moveTimerMax && isAlive)
		{
			moveTimer = 0;
            snakeBody.Update();
            snakeHead.Move();

            if (gameField.TryGetFood(HeadPosition, out Food food))
            {
                gameField.RemoveFromField(food.gameObject);
                food.Eated();

                snakeBody.AddBodyPart();
            }

            if (IsSnakeEateSelf())
            {
                SnakeDead.Invoke();
                isAlive = false;

                {//playSoundFunc
                    var sourse = GetComponent<AudioSource>();
                    sourse.clip = deadSound;
                    sourse.Play();
                }
            }
        }
		moveTimer += Time.deltaTime;
    }

    public Vector2[] GetAllSnakeBodyPartsPosition()
    {
        List<Vector2> snakeBodyParts = new List<Vector2>();

        if (snakeHead != null)
        {
            snakeBodyParts.Add(HeadPosition);

            snakeBodyParts.AddRange(snakeBody.GetAllPartsPosition());
        }
        return snakeBodyParts.ToArray();
    }

    void InputController()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            snakeHead.TryChangeDirection(SnakeDirection.Right);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            snakeHead.TryChangeDirection(SnakeDirection.Left);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            snakeHead.TryChangeDirection(SnakeDirection.Up);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            snakeHead.TryChangeDirection(SnakeDirection.Down);
        }


        if (Input.GetKeyDown(KeyCode.Q))
        {
            snakeBody.AddBodyPart();
        }
    }

    bool IsSnakeEateSelf()
    {
        foreach (var bodyPartPosition in snakeBody.GetAllPartsPosition())
        {
            if (HeadPosition == bodyPartPosition)
                return true;
        }

        return false;
    }


}

