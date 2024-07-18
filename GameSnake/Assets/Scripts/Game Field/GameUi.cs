using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using UnityEngine.UIElements;

public class GameUI
{
    IGameFieldUI gameField;

    Text scoreLable, highScoreLable;
    int currentScore, highScore;
    public int Score => currentScore;

    SetNewScoreMenu newScoreWindow;
    SettingsWindowInGame settingsWindow;


    public GameUI(IGameFieldUI onGameField)
    {
        gameField = onGameField;

        var canvas = gameField.transform.Find("Canvas");
        scoreLable = canvas.transform.Find("Score Lable").GetComponent<Text>();
        highScoreLable = canvas.transform.Find("High Score Lable").GetComponent<Text>();

        scoreLable.text = "Score: " + (currentScore = 0);
        InitHighScoreLable();


        SetupNewScoreWindow(in canvas);
        SetupSettingsWindow(in canvas);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !(newScoreWindow?.IsOpen ?? false))
        {
            if (settingsWindow.IsOpen)
                settingsWindow.SetActive(false);
            else
                settingsWindow.SetActive(true);
        }


        if (waitForSomeKey2endGame)
        {
            if (Input.anyKey)
            {
                SceneLoader.Load(SceneLoader.Scene.MainMenu);
            }
        }
    }

    bool waitForSomeKey2endGame = false;

    void SetupNewScoreWindow(in Transform canvas)
    {
        var _newScoreWindowGameObject = canvas.transform.Find("Set new score Window").gameObject;
        newScoreWindow = new SetNewScoreMenu(_newScoreWindowGameObject, this);
        newScoreWindow.SetActive(false);
    }
    void SetupSettingsWindow(in Transform canvas)
    {
        var _settingsWindowGameobject = canvas.transform.Find("SettingsWindow").gameObject;
        settingsWindow = new SettingsWindowInGame(_settingsWindowGameobject);
        settingsWindow.SetActive(false);
    }

    public void AddScore(int point)
    {
        currentScore += point;

        scoreLable.text = "Score: " + currentScore;
    }

    void InitHighScoreLable()
    {
        highScore = ScoreHandler.LoadScorese()[0].points;
        var name = ScoreHandler.LoadScorese()[0].name;
        highScoreLable.text = $"High Score: {highScore} ({name})";
    }

    public void SubmitOnSnakeDiead()
    {
        gameField.Snake.SnakeDead += () =>
        {
            if (currentScore > highScore)
            {
                newScoreWindow.Show();
                //ScoreHandler.SetScore(new Score(score, "Karim"));
            }
            else
            {
                gameField.transform.GetComponent<GameField>().StartCoroutine(HoldOn());
                //waitForSomeKey2endGame = true;
            }
        };
    }


    IEnumerator HoldOn()
    {
        yield return new WaitForSeconds(1.3f);
        waitForSomeKey2endGame = true;
    }
}

