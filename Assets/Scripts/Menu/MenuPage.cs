using UnityEngine;

namespace RovSim.Menu
{
    public class MenuPage : MonoBehaviour
    {
        public void SetVisibility(bool visible)
        {
            gameObject.SetActive(visible);
        }
    }
}
