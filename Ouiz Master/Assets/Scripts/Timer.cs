using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToShowCorrectAnswer = 10f;
    float TimerValue;
    public bool loadNextQuestion;
    public bool isAnsweringQuestion;
    public float fillFraction;

    private void Update()
    {
        UpdateTimer();
    }

    public void CancelTime()
    {
        TimerValue = 0;
    }

    void UpdateTimer()
    {
        TimerValue -= Time.deltaTime;
        if (isAnsweringQuestion)
        {
            if (TimerValue > 0)
            {
                fillFraction = TimerValue / timeToCompleteQuestion;
            }
            else
            {
                isAnsweringQuestion = false;
                TimerValue = timeToShowCorrectAnswer;
            }
        }
        else
        {
            if (TimerValue > 0)
            {
                fillFraction = TimerValue / timeToShowCorrectAnswer;
            }
            else
            {
                isAnsweringQuestion = true;
                TimerValue = timeToCompleteQuestion;
                loadNextQuestion = true;
            }
        }

    }
}
