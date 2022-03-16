using UnityEngine;
using UnityEngine.UI;

namespace RovSim.Menu
{
    [RequireComponent(typeof(Button))]
    public class MenuNavigationButton : MonoBehaviour
    {
        [SerializeField] MenuPage menuLink;

        private MenuController controller;

        public void Awake()
        {
            controller = GetComponentInParent<MenuController>();
            if (controller is null)
            {
                Debug.LogError("MenuNavigationButton requires parent MenuController.");
                return;
            }

            if (menuLink is null)
            {
                Debug.LogError("MenuNavigationButton requires field menuLink.");
                return;
            }

            Button button = GetComponent<Button>();
            button.onClick.AddListener(ChangeMenu);
        }

        public void ChangeMenu()
        {
            controller.SetMenu(menuLink);
        }
    }
}
