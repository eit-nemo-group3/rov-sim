using UnityEngine;
using System.Collections.Generic;

namespace RovSim.Menu
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private MenuPage defaultMenu;

        private List<MenuPage> _menus = new List<MenuPage>();

        public void Awake()
        {
            if (defaultMenu == null)
            {
                Debug.LogError("MenuController requires field defaultMenu.");
                return;
            }

            foreach (MenuPage menu in GetComponentsInChildren<MenuPage>(true))
            {
                _menus.Add(menu);
            }

            SetMenu(defaultMenu);
        }

        public void SetMenu(MenuPage newMenu)
        {
            foreach (MenuPage menu in _menus)
            {
                menu.SetVisibility(menu == newMenu);
            }
        }
    }
}
