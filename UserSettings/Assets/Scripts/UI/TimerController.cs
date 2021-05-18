using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;
    public TMPro.TMP_Text timeCounter;

    private TimeSpan timePlaying;
    private bool timerOn;
    private float elapsedTime;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        timeCounter.text = "Time: 00:00:00";
    }

    public void BeginTimer()
    {
        timerOn = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerOn = false;
    }

    public string GetTime()
    {
        return timePlaying.ToString("mm':'ss':'ff");
    }

    public string GetCheckableTime()
    {
        return timePlaying.ToString("mmssff");
    }

    private IEnumerator UpdateTimer()
    {
        while(timerOn)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss':'ff");
            timeCounter.text = timePlayingStr;

            yield return null;
        }
    }
}
