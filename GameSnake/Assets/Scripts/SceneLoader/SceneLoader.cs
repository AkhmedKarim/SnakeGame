using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
	public enum Scene
	{
		MainMenu,
		Game
	}

	public static LoadingSceneBehaviour loadingSceneBehaviour;

    public static void Load(Scene scene)
	{
        loadingSceneBehaviour = GameObject.Find("LoadingScene")?.GetComponent<LoadingSceneBehaviour>();

		if (loadingSceneBehaviour != null)
		{
            loadingSceneBehaviour.LoadingScen(scene);
            loadingSceneBehaviour = null;
            return;
		}

        SceneManager.LoadScene(scene.ToString());

    }
	public static void CloseAllGame()
	{
		Application.Quit();
	}

	
}

