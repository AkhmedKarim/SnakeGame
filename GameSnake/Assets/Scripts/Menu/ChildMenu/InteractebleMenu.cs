using System;
using UnityEngine;
using UnityEngine.UI;
public class InteractebleMenu : ChildMenu
{
    Button yesButton;
    public Button noButton;
    public InteractebleMenu(GameObject menu) : base(menu)
    {
        yesButton = instanse.transform.Find("YesButton").GetComponent<Button>();
        noButton = instanse.transform.Find("NoButton").GetComponent<Button>();


        yesButton.onClick.AddListener(() => {
            SceneLoader.CloseAllGame();
        });
        
    }
}

