using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public Canvas HUDCanvas;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume ()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
        HUDCanvas.enabled = true;
    }

    public void Pause ()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
        pauseMenuUI.SetActive(true);
        HUDCanvas.enabled = false;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
