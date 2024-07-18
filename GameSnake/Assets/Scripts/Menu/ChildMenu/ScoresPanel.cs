using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



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



        foreach (var lable in scoresLable)
        {
            var text = lable.GetComponent<Text>();

            var evntTrig = lable.GetComponent<EventTrigger>();
            if (evntTrig == null)
                evntTrig = lable.gameObject.AddComponent<EventTrigger>();

            EventTrigger.Entry onPointerEntry = new EventTrigger.Entry
            {
                eventID = EventTriggerType.PointerEnter
            };
            onPointerEntry.callback.AddListener((eventData) =>
            {
                text.fontSize += 10;
            });
            evntTrig.triggers.Add(onPointerEntry);

            EventTrigger.Entry onPointerExit = new EventTrigger.Entry
            {
                eventID = EventTriggerType.PointerExit
            };
            onPointerExit.callback.AddListener((eventData) =>
            {
                text.fontSize -= 10;
            });
            evntTrig.triggers.Add(onPointerExit);
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
        }
    }

    
}

