using System;
using UnityEngine;

public class SettingsWindowInGame : ChildMenu
{

    public bool IsOpen => instanse.activeSelf;

    QuiteFromGameScene_Module buttonsModule;

    public SettingsWindowInGame(GameObject menu) : base(menu)
    {
        buttonsModule = new QuiteFromGameScene_Module(menu);

        buttonsModule.SetupMainMenuButton(interactable: true);
        buttonsModule.SetupPlayButton(interactable: true);
    }

    public override void SetActive(bool active)
    {
        Time.timeScale = (active ? 0 : 1);
        base.SetActive(active);
    }
}

