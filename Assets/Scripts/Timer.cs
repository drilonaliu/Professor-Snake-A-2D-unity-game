using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Timer : MonoBehaviour
{
    public TextMeshPro text;
    public float startingTime = 10f;
    float currentTime;
    private bool stop = false;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        if (!stop)
        {
            currentTime -= 1 * Time.deltaTime;
        }
        text.text = Mathf.Round(currentTime) + "";
    }

    public void setTimer(float time)
    {
        currentTime = time;
    }

    public void startTime()
    {
        this.stop = false;
    }

    public void stopTime()
    {
        this.stop = true;
    }

    public bool haveTime()
    {
        return currentTime > 0;
    }

    public float getCurrentTime()
    {
        return currentTime;
    }
}
