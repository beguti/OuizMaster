using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] QuestionSO question;
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    void Start()
    {
        DisplayQuestion();
    }

    private void DisplayQuestion()
    {

        questionText.text = question.GetQuestion();
        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswerIndex(i);
            answerButtons[i].GetComponent<Image>().sprite = defaultAnswerSprite;
        }
        ButtonState(true);
    }

    private void ButtonState(bool b)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponent<Button>().interactable = b;
        }
    }

    public void OnAnswerSelected(int index)
    {
        Debug.Log(index);
        if(index==question.GetCorrectAnswerIndex())
        {
            questionText.text = "Doðru!";
            Image buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            correctAnswerIndex = question.GetCorrectAnswerIndex();
            questionText.text = "Yanlýþ! Doðru cevap: " + question.GetAnswerIndex(correctAnswerIndex);
            Image buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        ButtonState(false);
    }

}
