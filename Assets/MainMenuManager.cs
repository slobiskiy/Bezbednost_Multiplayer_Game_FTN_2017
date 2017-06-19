using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    public NetworkLauncher launcher;

    public Button PlayGameButton;
    public Button OptionsButton;
    public Button Exit;
    public Button BackToMainMenuButton;

    public InputField nameInput;

    public GameObject MainMenuParent;
    public GameObject LobbyParent;

    // Use this for initialization
    void Start()
    {

    }

    void Init()
    {

        PlayGameButton.onClick.AddListener(PlayGame);
        BackToMainMenuButton.onClick.AddListener(BackToMainMenu);

    }

    void PlayGame()
    {
        MainMenuParent.SetActive(false);
        LobbyParent.SetActive(true);
    }

    void BackToMainMenu()
    {
        MainMenuParent.SetActive(true);
        LobbyParent.SetActive(false);
    }


    public bool CheckIfNameExists()
    {
        if (nameInput.text != null)
        {
            return true;
        }

        return false;
    }

}
