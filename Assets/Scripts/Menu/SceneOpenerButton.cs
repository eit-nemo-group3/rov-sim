using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Collections;

namespace RovSim.Menu
{
    [RequireComponent(typeof(Button))]
    public class SceneOpenerButton : MonoBehaviour
    {
        public Animator transition;
        [SerializeField] private string sceneName;

        public void Awake()
        {
            if (String.IsNullOrEmpty(sceneName))
            {
                Debug.LogError("SceneOpenerButton requires field sceneName.");
                return;
            }

            Button button = GetComponent<Button>();
            button.onClick.AddListener(LoadScene);
        }


        private void LoadScene()
        {
            StartCoroutine(LoadLevel(sceneName));
        }

        IEnumerator LoadLevel(string levelName)
        {
            transition.SetTrigger("Start");
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelName);

            // Wait until the asynchronous scene fully loads
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }
    }
}
