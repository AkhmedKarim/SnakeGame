using System;
using UnityEngine;

public abstract class Food : MonoBehaviour
{
    public delegate void EatFood(Food food);
    public event EatFood FoodHasBeenEaten;

    public abstract int Points { get; }

    private void OnDestroy()
    {
        
    }

    public virtual void Eated()
    {
        FoodHasBeenEaten.Invoke(this);
    }
}

