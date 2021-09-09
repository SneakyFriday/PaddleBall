using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    #region Variables

    public GameObject pauseMenu;
    public GameObject startMenu;
    public Animator musicAnim;
        
    [SerializeField] private AI ai;
        
    public float waitTime;
    
    private readonly float[] _difficulties = {0.051f, 0.055f, 0.065f, 0.070f};
    private float _currentDifficulty;
    private static readonly int FadeOut = Animator.StringToHash("fadeOut");

    #endregion
    

    public void StartGame()
    {
        StartCoroutine(ChangeScene());
    }
    
    private void OnDisable()
    {
        PlayerPrefs.SetFloat("difficulty", _currentDifficulty);
    }
    
    public void OptionMenu()
    {
        pauseMenu.SetActive(true);
        startMenu.SetActive(false);
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
    
    public void ChangeDifficulty(int value)
    {
        ai.SetNewDifficulty(_difficulties[value]);
        _currentDifficulty = _difficulties[value];
        Debug.Log(_currentDifficulty);
    }
}
