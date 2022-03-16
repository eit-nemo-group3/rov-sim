using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

namespace RovSim.Menu
{
	[RequireComponent(typeof(Button))]
	public class SceneOpenerButton : MonoBehaviour
	{
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
			SceneManager.LoadScene(sceneName);
		}
	}
}