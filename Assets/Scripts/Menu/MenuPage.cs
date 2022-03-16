using UnityEngine;

namespace RovSim.Menu
{
    public class MenuPage : MonoBehaviour
    {
        public void SetVisibility(bool visible)
        {
            this.gameObject.SetActive(visible);
        }
    }
}
