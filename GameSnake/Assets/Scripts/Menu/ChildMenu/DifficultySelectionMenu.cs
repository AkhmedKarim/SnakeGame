using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DifficultySelectionMenu : ChildMenu
{
    Button easyMode,
        mediumMode,
        hardMode;
	public DifficultySelectionMenu(GameObject menu) : base(menu)
    {
        easyMode = instanse.transform.Find("EasyModeButton").GetComponent<Button>();
        mediumMode = instanse.transform.Find("MediumModeButton").GetComponent<Button>();
        hardMode = instanse.transform.Find("HardModeButton").GetComponent<Button>();

        easyMode.onClick.AddListener(() => {
            StartGame(DifficultController.Difficult.Easy);
        });
        mediumMode.onClick.AddListener(() => {
            StartGame(DifficultController.Difficult.Medium);
        });
        hardMode.onClick.AddListener(() => {
            StartGame(DifficultController.Difficult.Hard);
        });
    }

    private void StartGame(DifficultController.Difficult difficultMode)
    {
        DifficultController.currentDifficult = difficultMode;
        SceneLoader.Load(SceneLoader.Scene.Game);
    }
}

