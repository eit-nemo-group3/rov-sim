using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RovSim.Menu
{
    public class PauseMenu : MonoBehaviour
    {
        public GameObject pauseMenuUI;
        public Canvas hudCanvas;
        public Animator transition;

        private static bool _gameIsPaused;

        // Update is called once per frame
        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
            {
                if (_gameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }

        public void Resume()
        {
            Time.timeScale = 1f;
            _gameIsPaused = false;
            pauseMenuUI.SetActive(false);
            hudCanvas.enabled = true;
        }

        private void Pause()
        {
            Time.timeScale = 0f;
            _gameIsPaused = true;
            pauseMenuUI.SetActive(true);
            hudCanvas.enabled = false;
        }

        public void LoadMenu()
        {
            Time.timeScale = 1f;
            StartCoroutine(LoadLevel("MainMenu"));
        }

        public void RestartScene()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private IEnumerator LoadLevel(string levelName)
        {
            transition.SetTrigger("Start");
            var asyncLoad = SceneManager.LoadSceneAsync(levelName);

            // Wait until the asynchronous scene fully loads
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }
    }
}
