using UnityEngine;
using UnityEngine.UI;

namespace RovSim.Menu
{
    [RequireComponent(typeof(Button))]
    public class MenuNavigationButton : MonoBehaviour
    {
        [SerializeField] private MenuPage menuLink;

        private MenuController _controller;

        public void Awake()
        {
            _controller = GetComponentInParent<MenuController>();
            if (_controller is null)
            {
                Debug.LogError("MenuNavigationButton requires parent MenuController.");
                return;
            }

            if (menuLink is null)
            {
                Debug.LogError("MenuNavigationButton requires field menuLink.");
                return;
            }

            var button = GetComponent<Button>();
            button.onClick.AddListener(ChangeMenu);
        }

        private void ChangeMenu()
        {
            _controller.SetMenu(menuLink);
        }
    }
}
