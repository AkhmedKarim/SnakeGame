using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuiteFromGameScene_Module : ChildMenu
{
    public Button playButton, mainMenuButton;

    public QuiteFromGameScene_Module(GameObject menu) : base(menu)
    {
    }

    public void SetupPlayButton(bool interactable = false)
    {
        playButton = instanse.transform.Find("PlayButton").GetComponent<Button>();
        playButton.onClick.AddListener(() => {
            Time.timeScale = 1;
            SceneLoader.Load(SceneLoader.Scene.Game);
        });
        playButton.interactable = interactable;
    }
    public void SetupMainMenuButton(bool interactable = false)
    {
        mainMenuButton = instanse.transform.Find("MainMenuButton").GetComponent<Button>();
        mainMenuButton.onClick.AddListener(() => {
            Time.timeScale = 1;
            SceneLoader.Load(SceneLoader.Scene.MainMenu);
        });
        mainMenuButton.interactable = interactable;
    }
}

