using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls the behaviour of the game start menu.
/// </summary>
public class GameStartMenu : MonoBehaviour
{
    [Header("UI Pages")]
    /// <summary>
    /// The GameObject representing the main menu.
    /// </summary>
    public GameObject mainMenu;

    /// <summary>
    /// The GameObject representing the options menu.
    /// </summary>
    public GameObject options;

    /// <summary>
    /// The GameObject representing the about menu.
    /// </summary>
    public GameObject about;

    [Header("Main Menu Buttons")]
    /// <summary>
    /// The Button component representing the start button.
    /// </summary>
    public Button startButton;

    /// <summary>
    /// The Button component representing the options button.
    /// </summary>
    public Button optionButton;

    /// <summary>
    /// The Button component representing the about button.
    /// </summary>
    public Button aboutButton;

    /// <summary>
    /// The Button component representing the quit button.
    /// </summary>
    public Button quitButton;

    /// <summary>
    /// The List of Button components representing the return buttons.
    /// </summary>
    public List<Button> returnButtons;

    /// <summary>
    /// Called before the first frame update.
    /// Initializes the menu and the button events.
    /// </summary>
    void Start()
    {
        EnableMainMenu();

        //Hook events
        startButton.onClick.AddListener(StartGame);
        optionButton.onClick.AddListener(EnableOption);
        aboutButton.onClick.AddListener(EnableAbout);
        quitButton.onClick.AddListener(QuitGame);

        foreach (var item in returnButtons)
        {
            item.onClick.AddListener(EnableMainMenu);
        }
    }

    /// <summary>
    /// Quits the game.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Starts the game by transitioning to the next scene.
    /// </summary>
    public void StartGame()
    {
        HideAll();
        SceneTransitionManager.singleton.GoToSceneAsync(1);
    }

    /// <summary>
    /// Hides all the menus.
    /// </summary>
    public void HideAll()
    {
        mainMenu.SetActive(false);
        options.SetActive(false);
        about.SetActive(false);
    }

    /// <summary>
    /// Enables the main menu and hides the other menus.
    /// </summary>
    public void EnableMainMenu()
    {
        mainMenu.SetActive(true);
        options.SetActive(false);
        about.SetActive(false);
    }

    /// <summary>
    /// Enables the options menu and hides the other menus.
    /// </summary>
    public void EnableOption()
    {
        mainMenu.SetActive(false);
        options.SetActive(true);
        about.SetActive(false);
    }

    /// <summary>
    /// Enables the about menu and hides the other menus.
    /// </summary>
    public void EnableAbout()
    {
        mainMenu.SetActive(false);
        options.SetActive(false);
        about.SetActive(true);
    }
}
