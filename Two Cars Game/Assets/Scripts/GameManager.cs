using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int score;
    
    public bool isPaused;
    public bool lose;
    
    public bool enableMusic;
    public int highScore;
    
    public Canvas pauseMenu;
    public Canvas mainCanvas;
    public Canvas loseMenu;

    public Text scoreText;
    public Text PHighScore;
    public Text PScore;    
    public Text LHighScore;
    public Text LScore;
    
    private AudioManager audioManager;


    // Start is called before the first frame update
    void Start()
    {
        StartOver();
        enableMusic = true;
        audioManager.Play("MainMusic");
    }

    private void Update()
    {
        scoreText.text = score.ToString();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Pause();
        }
    }

    public void Lose()
    {
        isPaused = true;
        mainCanvas.gameObject.SetActive(false);
        loseMenu.gameObject.SetActive(true);
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt ("highscore", highScore);
        }
        LScore.text = "Your Score : " + score.ToString();
        LHighScore.text = "HighScore : " + highScore.ToString();
    }

    public void Pause()
    {
        isPaused = true;
        pauseMenu.gameObject.SetActive(true);
        mainCanvas.gameObject.SetActive(false);
        PScore.text = "Your Score : " + score.ToString();
        PHighScore.text = "HighScore : " + highScore.ToString();
    }

    public void Resume()
    {
        isPaused = false;
        pauseMenu.gameObject.SetActive(false);
        mainCanvas.gameObject.SetActive(true);
        }

    public void Restart()
    {
        mainCanvas.gameObject.SetActive(true);
        pauseMenu.gameObject.SetActive(true);
        loseMenu.gameObject.SetActive(true);
        StartOver();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToggleMusic()
    {
        enableMusic = !enableMusic;
        if (enableMusic)
        {
            audioManager.Play("MainMusic");
        }
        else
        {
            audioManager.Pause("MainMusic");
        }
    }

    public void Quit()
    {
        PlayerPrefs.SetInt ("highscore", highScore);
        PlayerPrefs.Save();
        Application.Quit();
    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt ("highscore", highScore);
        PlayerPrefs.Save();
    }

    public void SetIsPaused(bool a)
    {
        isPaused = a;
    }

    public bool GetIsPaused()
    {
        return isPaused;
    }

    public void AddScore()
    {
        score++;
    }

    public void StartOver()
    {
        mainCanvas.gameObject.SetActive(true);
        pauseMenu.gameObject.SetActive(false);
        loseMenu.gameObject.SetActive(false);
        
        score = 0;
        isPaused = false;
        lose = false;
        audioManager = GetComponent<AudioManager>();
        highScore = PlayerPrefs.GetInt ("highscore", highScore);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
