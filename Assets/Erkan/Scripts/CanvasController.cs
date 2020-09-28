using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject ResumeButton;

    public Text pauseText;
    void Start()
    {
        
    }

    void Update()
    {
    }
    public void Pause()
    {
        pauseText.text = "PAUSE";
        pauseMenu.SetActive(true);
        ResumeButton.SetActive(true);
        Time.timeScale = 0;
    }
    public void Death()
    {
        pauseText.text = "You Died";
        pauseMenu.SetActive(true);
        ResumeButton.SetActive(false);
        Time.timeScale = 0;
    }
    
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void SceneLoader(int sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
