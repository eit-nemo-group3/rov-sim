using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Depth : MonoBehaviour
{   
    public TMP_Text depthText;
    private string text;

    public GameObject overflate;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {   
        player = GameObject.FindGameObjectWithTag("Player");
        overflate = GameObject.FindGameObjectWithTag("Overflate");
    }

    // Update is called once per frame
    void Update()
    {
        CalculateDistance();
    }

    void CalculateDistance(){
        float dist = Mathf.Abs(overflate.transform.position.y - player.transform.position.y);
        Double d1 = Math.Round(dist,1);
        text = d1.ToString();
        depthText.SetText(text+"m");
    }
}