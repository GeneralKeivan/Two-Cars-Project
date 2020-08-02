using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    private AudioManager _audioManager;

    private string gameMode;

    public Text changeText;
    // Start is called before the first frame update
    void Start()
    {
        gameMode = PlayerPrefs.GetString("gameMode");
        if (gameMode != "Solo" && gameMode != "Double")
        {
            gameMode = "Solo";
        }
        changeText.text = gameMode;
        _audioManager = GetComponent<AudioManager>();
        _audioManager.Play("MainMusic");
    }

    public void Play()
    {
        if (gameMode == "Solo")
        {
            SceneManager.LoadScene("Game");
        }

        if (gameMode == "Double")
        {
            SceneManager.LoadScene("GameEasy");
        }
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void SwitchGameMode()
    {
        if (gameMode == "Solo")
        {
            gameMode = "Double";
        }

        else if (gameMode == "Double")
        {
            gameMode = "Solo";
        }
        else
        {
            gameMode = "Solo";
        }

        changeText.text = gameMode;

    }

    void OnDestroy()
    {
        PlayerPrefs.SetString("gameMode", gameMode);
        PlayerPrefs.Save();
    }
}
