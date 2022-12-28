using UnityEngine;
using System.Collections.Generic;

namespace RovSim.Menu
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private MenuPage defaultMenu;

        private readonly List<MenuPage> _menus = new();

        public void Awake()
        {
            if (defaultMenu == null)
            {
                Debug.LogError("MenuController requires field defaultMenu.");
                return;
            }

            foreach (var menu in GetComponentsInChildren<MenuPage>(true))
            {
                _menus.Add(menu);
            }

            SetMenu(defaultMenu);
        }

        public void SetMenu(MenuPage newMenu)
        {
            foreach (var menu in _menus)
            {
                menu.SetVisibility(menu == newMenu);
            }
        }
    }
}
