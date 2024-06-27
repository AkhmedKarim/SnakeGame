using System;
using UnityEngine;
public abstract class ChildMenu
{
    protected GameObject instanse;

    public ChildMenu(GameObject menu)
    {
        instanse = menu;
    }

    public void SetActive(bool active)
    {
        instanse.SetActive(active);
    }
}

