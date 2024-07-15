using System;
using UnityEngine;
using UnityEngine.Audio;

public static class SoundManager
{

    private static float _volume = 0;


    public static float Volume
    {
        get => _volume;
        set => _volume = value;//Mathf.Lerp(-80, 0, value);
    }
}