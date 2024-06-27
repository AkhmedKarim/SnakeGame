using System;
using UnityEngine;
public class SnakeHead
{
	GameObject head;
    Vector2Int currentDirection;

    public SnakeHead(GameObject snake)
    {
        head = snake;
        TryChangeDirection(new Vector2Int(1, 0));
    }

    public void Move()
    {
        head.transform.position += (Vector3)(Vector2)currentDirection;
    }

    public void TryChangeDirection(Vector2Int direction)
    {
        currentDirection = direction;
        float angle = Mathf.Atan2(currentDirection.y, currentDirection.x);
        head.transform.eulerAngles = new Vector3(0,0,angle - 90);
    }
}

