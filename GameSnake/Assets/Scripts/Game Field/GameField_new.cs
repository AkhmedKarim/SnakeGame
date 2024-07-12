//using System.Collections.Generic;
//using UnityEngine;
//public static class GameField_new
//{
//    const int FIELD_WIDTH = 26, FIELD_HEGHT = 26;
//    static Vector2[] AllFieldsCells;
    
//    static GameField_new()
//    {
//        InitFieldCells();
//    }
//    static void InitFieldCells()
//    {
//        AllFieldsCells = new Vector2[FIELD_HEGHT * FIELD_WIDTH];

//        int i = 0;
//        for (int y = 0; y < FIELD_HEGHT; y++)
//        {
//            for (int x = 0; x < FIELD_WIDTH; x++)
//            {
//                AllFieldsCells[i++] = new Vector2(x, y);
//            }
//        }
//    }

//    public static void StayInsideField(Transform obj)
//    {
//        if (obj.position.x >= FIELD_WIDTH)
//        {
//            obj.position = new Vector3(obj.position.x - (FIELD_WIDTH), obj.position.y, obj.position.z);
//        }
//        else if (obj.position.x < 0)
//        {
//            obj.position = new Vector3(obj.position.x + (FIELD_WIDTH), obj.position.y, obj.position.z);
//        }

//        if (obj.position.y >= FIELD_HEGHT)
//        {
//            obj.position = new Vector3(obj.position.x, obj.position.y - (FIELD_HEGHT), obj.position.z);
//        }
//        else if (obj.position.y < 0)
//        {
//            obj.position = new Vector3( obj.position.x, obj.position.y + (FIELD_HEGHT), obj.position.z);
//        }
//    }

//    public static Vector2 GetRandomPositionWhithout(Vector2[] occupiedPositions)
//    {
//        //var occupiedPositions = snake.GetAllSnakeBodyPartsPosition();
//        if (occupiedPositions.Length == AllFieldsCells.Length)
//        {
//            //пасхалка, гра завершена
//            return new Vector2(-1, -1);
//        }

//        var cellsWitoutSnake = new List<Vector2>();
//        foreach (var part in occupiedPositions)
//        {
//            foreach (var cell in AllFieldsCells)
//            {
//                if (part != cell)
//                {
//                    cellsWitoutSnake.Add(cell);
//                }
//            }
//        }
//        return cellsWitoutSnake[Random.Range(0, cellsWitoutSnake.Count)];
//    }
//}

