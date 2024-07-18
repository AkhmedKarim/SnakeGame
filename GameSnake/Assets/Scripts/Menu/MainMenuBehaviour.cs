
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
    ScoresPanel scoresPanel;


    private void Awake()
    {
        
    }

    void Start()
    {
        difficultySelectionMenu =
            new DifficultySelectionMenu(GameObject.Find("DifficultySelectionMenu"));
        difficultySelectionMenu.SetActive(false);

        settingMenu = new SettingMenu(GameObject.Find("SettingsWindow"));

        interactebleMenu = new InteractebleMenu(GameObject.Find("InteractebleWindow"));
        interactebleMenu.noButton.onClick.AddListener(()=> CloseWindow());
        interactebleMenu.SetActive(false);

        scoresPanel = new ScoresPanel(GameObject.Find("ScorePanel"));
        scoresPanel.Reload();

        SetupBlurPanel();
        SetupButtons();
    }



    void SetupBlurPanel()
    {
        blurPanel = GameObject.Find("BlurPanel").GetComponent<Button>();
        blurPanel.onClick.AddListener(() => {
            CloseWindow();
        });
        blurPanel.gameObject.SetActive(false);
    }

    void SetupButtons()
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


