using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static int score;
    
    public static bool isPaused;
    public static bool lose;
    
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

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
       
        mainCanvas.gameObject.SetActive(true);
        pauseMenu.gameObject.SetActive(false);
        loseMenu.gameObject.SetActive(false);
        score = 0;
        isPaused = false;
        lose = false;
        enableMusic = true;
        audioManager = GetComponent<AudioManager>();
        highScore = PlayerPrefs.GetInt ("highscore", highScore);
        audioManager.Play("MainMusic");
    }

    private void Update()
    {
        scoreText.text = score.ToString();
        if (lose)
        {
            Lose();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            mainCanvas.gameObject.SetActive(true);
            pauseMenu.gameObject.SetActive(true);
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
        SceneManager.LoadScene("Game");
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
        Application.Quit();
    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt ("highscore", highScore);
        PlayerPrefs.Save();
    }
}
