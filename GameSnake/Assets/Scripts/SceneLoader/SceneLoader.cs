using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public static class SceneLoader
{
	public enum Scene
	{
		MainMenu,
		Game
	}

	public static void Load(Scene scene)
	{
		SceneManager.LoadScene(scene.ToString());
    }
	public static void CloseAllGame()
	{
		Application.Quit();
	}
}

