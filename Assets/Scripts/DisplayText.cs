using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DisplayText : MonoBehaviour
{
    public TMP_Text questHint;
    private float endTime = 0f;
    private bool startTimer = false;

    // Update is called once per frame
    void Update()
    {
        // Timer that goes for set amount of time
        // Sets startTimer to false to indicate finnish
        if (startTimer) {
            if (Time.time > endTime) {
                startTimer = false;
            }
        }
    }

    // Start Coroutine for SetText to allow waiting
    void SetText(string text, int seconds = -1)
    {
        StartCoroutine(CoroutineSetText(text, seconds));
    }

    // Set text, if seconds is specified then wait until timer is finnished and hide the text
    IEnumerator CoroutineSetText(string text, int seconds = -1)
    {   
        // Set text and align to center
        questHint.SetText(text);
        questHint.alignment = TMPro.TextAlignmentOptions.Center;

        // Only wait if seconds is specified
        if (seconds > 0) {
            // Setup endTime and wait until timer is done before hiding text
            endTime = Time.time + seconds;
            startTimer = true;

            while (startTimer) {
                yield return null;
            }
            HideText();
        }
    }

    // Start Coroutine for SetTextList to allow waiting
    void SetTextList(List<string> texts, int seconds = 3)
    {
        StartCoroutine(CoroutineSetTextList(texts, seconds));
    }

    // Go through each element of list and display it
    // Wait until timer is done before displaying next
    IEnumerator CoroutineSetTextList(List<string> texts, int seconds = 3)
    {
        for (int i = 0; i < texts.Count; i++) {
            SetText(texts[i], seconds);
            while (startTimer) {
                yield return null;
            }
        }
        HideText();
    }

    // Set text to empty string
    void HideText()
    {
        questHint.SetText("");
    }
}
