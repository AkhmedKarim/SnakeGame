using System;
using UnityEngine;
public interface IGameFieldUI
{
    public SnakeBehaviour Snake { get; }
    Transform transform { get; }
}

