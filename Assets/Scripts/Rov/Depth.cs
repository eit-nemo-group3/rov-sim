using UnityEngine;
using TMPro;
using System;

namespace RovSim.Rov
{
    public class Depth : MonoBehaviour
    {

        public TMP_Text depthText;
        public GameObject surface;
        public GameObject player;

        private string _text;

        // Start is called before the first frame update
        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            surface = GameObject.FindGameObjectWithTag("Surface");
        }

        // Update is called once per frame
        private void Update()
        {
            CalculateDistance();
        }

        private void CalculateDistance()
        {
            var dist = Mathf.Abs(surface.transform.position.y - player.transform.position.y);
            var d1 = Math.Round(dist, 1);
            _text = d1.ToString();
            depthText.SetText(_text + "m");
        }
    }
}
