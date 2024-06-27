using System;
using UnityEngine;
public static class SoundManager
{
    private static float _volume;
    public static float Volume
    {
        get => _volume;
        set => _volume = Mathf.Clamp01(value);
    }
}

