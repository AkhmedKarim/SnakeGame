using System;
using UnityEngine;
public static class Snake
{
    public static Vector2 ToVector2(this SnakeDirection snakeDirection)
    {
        switch (snakeDirection)
        {
            default:
            case SnakeDirection.Up:
                return Vector2Int.up;

            case SnakeDirection.Down:
                return Vector2Int.down;

            case SnakeDirection.Left:
                return Vector2Int.left;

            case SnakeDirection.Right:
                return Vector2Int.right;
        }
    }

    public static Vector3 ToEulerAngles(this SnakeDirection snakeDirection)
    {
        switch (snakeDirection)
        {
            default:
            case SnakeDirection.Up:
                return new Vector3(0, 0, 180);

            case SnakeDirection.Down:
                return new Vector3(0, 0, 0);

            case SnakeDirection.Left:
                return new Vector3(0, 0, -90);

            case SnakeDirection.Right:
                return new Vector3(0, 0, 90);
        }
    }

    public static float ToAngle(this SnakeDirection direction)
    {        
        return Mathf.Atan2(direction.ToVector2().y, direction.ToVector2().x) * Mathf.Rad2Deg - 90;
    }

    public static Vector3 GetCornerRotationTo(this SnakeDirection currentPartDirection , SnakeDirection previousPartDirection)
    {
        switch (previousPartDirection)
        {
            default:
            case SnakeDirection.Up:
                switch (currentPartDirection)
                {
                    default:
                    case SnakeDirection.Left:
                        return new Vector3(0, 0, 0);
                    case SnakeDirection.Right:
                        return new Vector3(0, 0, 90);
                }

            case SnakeDirection.Down:
                switch (currentPartDirection)
                {
                    default:
                    case SnakeDirection.Left:
                        return new Vector3(0, 0, 270);
                    case SnakeDirection.Right:
                        return new Vector3(0, 0, 180);
                }

            case SnakeDirection.Left:
                switch (currentPartDirection)
                {
                    default:
                    case SnakeDirection.Up:
                        return new Vector3(0, 0, 180);
                    case SnakeDirection.Down:
                        return new Vector3(0, 0, 90);
                }

            case SnakeDirection.Right:
                switch (currentPartDirection)
                {
                    default:
                    case SnakeDirection.Up:
                        return new Vector3(0, 0, 270);
                    case SnakeDirection.Down:
                        return new Vector3(0,0,0);
                }
        }
    }
}

