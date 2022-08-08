using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{


    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;


    public bool countDown;

    [Header("Limit Settings")]
    public bool hasLimit;
    public float timerLimit;


    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        //if the current time is true, then we need to do the block of code next to it ... and if the countdown is false, we want to do the block of code next to it ...


        if(hasLimit && ((countDown && currentTime <= timerLimit || (!countDown && currentTime >= timerLimit ))))
        {
            currentTime = timerLimit;
            SetTimerText();
            timerText.color = Color.red;
            enabled = false;

        }

        SetTimerText();
       




    }



    private void SetTimerText()
    {
        timerText.text = currentTime.ToString("0.0");

        if (timerText.text == "0.0")
       {
            SceneManager.LoadScene("loseScene");
       }


    }

 






}
