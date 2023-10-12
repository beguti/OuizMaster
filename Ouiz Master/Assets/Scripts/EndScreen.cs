using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScoreText;
    [SerializeField] ScoreKeeper scoreKeeper;


    public void ShowFinalScore()
    {
        finalScoreText.text = "Tebrikler! \n Puan: " + scoreKeeper.CalculateScore() + "%";
    }
}
