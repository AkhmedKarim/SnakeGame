using System;
using UnityEngine;
public class SnakeHead
{
    SnakeBehaviour snakeHandler;

    SnakeDirection _currentDirection;
    SnakeDirection _newDirection;
    public SnakeDirection InputDirection { get => _newDirection; }//ShDirection - це напрям який обрав гравець, якщо гравець в моменті змінить напрям, то і ця змінна зміниться бистріше а ніж змінеться справжній наврям змії. Спавжній напрям це - _currentDirection


    public SnakeHead(SnakeBehaviour snakeHandler)
    {
        this.snakeHandler = snakeHandler;

        _newDirection = _currentDirection = SnakeDirection.Right;
    }

    public void Move()
    {
        _currentDirection =_newDirection ;

        float angle = InputDirection.ToAngle();

        snakeHandler.transform.eulerAngles = new Vector3(0, 0, angle);
        snakeHandler.transform.position += (Vector3)InputDirection.ToVector2();

        snakeHandler.GameField.StayInside(snakeHandler.transform);
    }

    public void TryChangeDirection(SnakeDirection direction)
    {
        if ((int)_currentDirection % 2 == 0 && (int)direction % 2 == 0 ||//enum SnakeDirection розташований таким чином
            (int)_currentDirection % 2 != 0 && (int)direction % 2 != 0)
            return;//якщо новий напрям протилежний попередньому

        _newDirection = direction;
    }

}
    


