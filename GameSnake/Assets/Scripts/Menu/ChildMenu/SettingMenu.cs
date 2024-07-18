using UnityEngine;
using UnityEngine.Events;

public class SettingMenu : ChildMenu
{
    
    public SettingMenu(GameObject menu) : base(menu)
    {
    }

    public override void SetActive(bool active)
    {
        if (active)
        {
            Open();
        }
        else
        {
            Close();
        }
    }

    void Close()
    {
        instanse.GetComponent<Animator>().SetTrigger("Close");
    }

    void Open()
    {
        instanse.GetComponent<Animator>().SetTrigger("Open");
    }
}

