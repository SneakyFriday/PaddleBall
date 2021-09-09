using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Variables
    
    private int _playerScore;
    private int _aiScore;
    public float waitTime;
    public GameObject winUI;
    public Text playerText;
    public Text aiText;
    public Text uiWinText;
    public GameObject pauseMenu;
    public GameObject startMenu;
    public SoundManager soundManager;
    public ChangeMusic changeMusic;
    public Animator musicAnim;
    public GameObject pressDMenu;
    public GameObject backgroundMusic;
    private readonly float[] _difficulties = {0.051f, 0.055f, 0.065f, 0.070f};
    private static float _currentDifficulty = 0.051f;
    private static readonly int FadeOut = Animator.StringToHash("fadeOut");
    [SerializeField] private BallController ballController;
    [SerializeField] private AI ai;
    
    #endregion
    
    public void Update()
    {
        Scores();
        GetPlayerInput();
        if (ballController.ballUnterwegs)
        {
            pressDMenu.SetActive(false);
        }
        
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat("difficulty", _currentDifficulty);
    }

    private void OnEnable()
    {
        
        _currentDifficulty = PlayerPrefs.GetFloat("difficulty");
        if (_currentDifficulty == 0)
        {
            _currentDifficulty = _difficulties[0];
        }
        Debug.Log(_currentDifficulty);
        
        if (ai)
        {
          ai.SetNewDifficulty(_currentDifficulty);  
        }
        
        if (!soundManager)
        {
            soundManager = (SoundManager)Resources.Load("AudioManager");
        }
    }
    
    public void OptionMenu()
    {
        pauseMenu.SetActive(true);
        startMenu.SetActive(false);
    }

    public int GetPlayerScore()
    {
        return _playerScore;
    }

    public int GetAIScore()
    {
        return _aiScore;
    }
    
    public void StartGame()
    {
        StartCoroutine(ChangeScene());
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
    
    IEnumerator ChangeScene()
    {
        musicAnim.SetTrigger(FadeOut);
        yield return new WaitForSeconds(waitTime);
        
        // Loads Scene as Single Scene after die current Scene
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    private void Scores()
    {
        if (ballController is { } && ballController.playerHit)
        {
            _playerScore++;
            playerText.text = _playerScore.ToString();
            ballController.playerHit = false;
        }

        if (ballController is { } && ballController.AIHit)
        {
            _aiScore++;
            aiText.text = _aiScore.ToString();
            ballController.AIHit = false;
        }
            
    }
    
    public void Win(bool playerIswinner, bool aiIsWinner)
    {

        if (!playerIswinner && aiIsWinner)
        {
            uiWinText.text = "AI WINS!";
            winUI.SetActive(true);
            backgroundMusic.SetActive(false);
            changeMusic.PlayAIWinSound();
        }

        if (playerIswinner && !aiIsWinner)
        {
            uiWinText.text = "YOU WIN!";
            winUI.SetActive(true);
            backgroundMusic.SetActive(false);
            changeMusic.PlayPlayerWinSound();
        }
    }

    public void ChangeDifficulty(int value)
    {
        _currentDifficulty = _difficulties[value];
        ai.SetNewDifficulty(_currentDifficulty);
    }

    public void DeselectPauseMenu()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    private void GetPlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
