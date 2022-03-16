using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace RovSim.Menu
{
	public class MenuPage : MonoBehaviour
	{
		private List<GameObject> buttons = new List<GameObject>();

		public void Awake()
		{
			foreach (Transform child in this.transform)
			{
				Button button = child.GetComponent<Button>();
				if (button is null) continue;

				buttons.Add(child.gameObject);
			}
		}

		public void SetButtonVisibility(bool visible)
		{
			foreach (GameObject button in buttons)
			{
				button.SetActive(visible);
			}
		}
	}
}