using UnityEngine;
using UnityEngine.UI;

public class MainMenuBehaviour : MonoBehaviour
{
    Button playButtun,
        quitButtun,
        settingButtun;

    Button blurPanel;

    ChildMenu currentOpenMenu;
    DifficultySelectionMenu difficultySelectionMenu;
    SettingMenu settingMenu;
    InteractebleMenu interactebleMenu;


    void Start()
    {
        difficultySelectionMenu =
            new DifficultySelectionMenu(GameObject.Find("DifficultySelectionMenu"));
        difficultySelectionMenu.SetActive(false);

        settingMenu = new SettingMenu(GameObject.Find("SettingsWindow"));
        settingMenu.SetActive(false);

        interactebleMenu = new InteractebleMenu(GameObject.Find("InteractebleWindow"));
        interactebleMenu.noButton.onClick.AddListener(()=> CloseWindow());
        interactebleMenu.SetActive(false);

        SetupBlurPanel();
        SetupButton();
    }

    void Update()
    {
        Debug.Log(SoundManager.Volume);
    }

    void SetupBlurPanel()
    {
        blurPanel = GameObject.Find("BlurPanel").GetComponent<Button>();
        blurPanel.onClick.AddListener(() => {
            CloseWindow();
        });
        blurPanel.gameObject.SetActive(false);
    }

    void SetupButton()
    {
        playButtun = transform.Find("PlayButton").GetComponent<Button>();
        quitButtun = transform.Find("QuitButton").GetComponent<Button>();
        settingButtun = transform.Find("SettingsButton").GetComponent<Button>();

        playButtun.onClick.AddListener(() =>
            OpenWindow(difficultySelectionMenu)
        );
        quitButtun.onClick.AddListener(()=>
            OpenWindow(interactebleMenu)
        );
        settingButtun.onClick.AddListener(() =>
            OpenWindow(settingMenu)
        );
    }

    void OpenWindow(ChildMenu childMenu)
    {
        blurPanel.gameObject.SetActive(true);
        childMenu.SetActive(true);
        currentOpenMenu = childMenu;
    }
    void CloseWindow()
    {
        currentOpenMenu?.SetActive(false);
        blurPanel?.gameObject.SetActive(false);
    }
}
