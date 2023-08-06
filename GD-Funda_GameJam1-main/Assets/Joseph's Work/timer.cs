using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class timer : MonoBehaviour
{
    float currTime = 0.0f;
    float startTime = 180.0f;
    // Start is called before the first frame update
    [SerializeField] TMP_Text countdownText;
    void Start()
    {
        currTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        currTime -= (1 * Time.deltaTime);
        TimeSpan time = TimeSpan.FromSeconds(currTime);
        countdownText.text = time.Minutes.ToString("00") + ":" + time.Seconds.ToString("00");
        if(currTime <= 0)
        {
            currTime = 0;
        }
    }
}
