using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject KeybindsText;

    public void GameStart()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void ExitGame()
    {
        Application.Quit();
        print("Exited Game");
    }
    public void Keybinds()
    {
        KeybindsText.SetActive(true);
    }
    public void ExitKeybinds()
    {
        KeybindsText.SetActive(false);
    }
}
