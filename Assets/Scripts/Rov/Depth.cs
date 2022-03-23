using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Depth : MonoBehaviour
{   
    public Transform player;
    public TMP_Text depthText;
    public float depth;
    private string text;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        depth = player.transform.localPosition.y;
        Double d1 = Math.Round(depth,2);
        text = d1.ToString();
        depthText.SetText(text+"m");
    }
}