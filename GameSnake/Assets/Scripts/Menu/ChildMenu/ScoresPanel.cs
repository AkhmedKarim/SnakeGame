using System;
using UnityEngine;
using UnityEngine.UI;


public class ScoresPanel : ChildMenu
{
    Text[] scoresLable;

    public ScoresPanel(GameObject menu) : base(menu)
    {
        scoresLable = new Text[5];

        scoresLable[0] = instanse.transform.Find("HighterScore").GetComponent<Text>();
        for (int i = 1; i < scoresLable.Length; i++)
        {
            scoresLable[i] = instanse.transform.Find($"Score_{i - 1}").GetComponent<Text>();
        }
    }

    public void Reload()
    {
        Score[] scoresArray = ScoreHandler.LoadScorese();
        int i = 0;

        foreach (var lable in scoresLable)
        {
            string _text = $"{scoresArray[i].name}: {scoresArray[i++].points}";

            lable.text = _text;
            Debug.Log(lable.transform.name);
        }
    }
}

