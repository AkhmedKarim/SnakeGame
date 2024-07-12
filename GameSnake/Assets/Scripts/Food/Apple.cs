using UnityEngine;
using System.Collections;

public class Apple : Food
{
    public override int Points
    {
        get
        {
            switch (DifficultController.currentDifficult)
            {
                default:
                case DifficultController.Difficult.Easy:
                    return 1;
                case DifficultController.Difficult.Medium:
                    return 2;
                case DifficultController.Difficult.Hard:
                    return 3;
            }
        }
    }
    
}

