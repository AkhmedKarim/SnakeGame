using System;
using UnityEngine;
using UnityEngine.UI;

public class SetNewScoreMenu : ChildMenu
{
    InputField inputField;
    Text HighScoreLable;
    GameUI gameUI;
    QuiteFromGameScene_Module buttonsModule;

    public bool IsOpen => instanse.activeSelf;

    int NewHighScore => gameUI.Score;

    public SetNewScoreMenu(GameObject menu, GameUI gameUI) : base(menu)
    {
        this.gameUI = gameUI;
        HighScoreLable = instanse.transform.Find("New high score Lable").GetComponent<Text>();

        buttonsModule = new QuiteFromGameScene_Module(menu);

        SetupInputField();
        buttonsModule.SetupPlayButton();
        buttonsModule.SetupMainMenuButton();
    }

    public void Show()
    {
        SetActive(true);
        HighScoreLable.text = "New high score: " + NewHighScore;
    }

    void SetupInputField()
    {
        inputField = instanse.transform.Find("InputField").GetComponent<InputField>();
        inputField.onSubmit.AddListener((string name) => {
            //Debug.Log(name);

            ScoreHandler.SaveScore(new Score(NewHighScore, name));
            inputField.interactable = false;
            buttonsModule.playButton.interactable = true;
            buttonsModule.mainMenuButton.interactable = true;
        });
    }

}

