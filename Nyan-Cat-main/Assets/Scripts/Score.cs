using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text MyScore;
    private int ScoreNum;

    public void Start()
    {
        ScoreNum = 0;
        UpdateScoreText();
    }

    private void OnTriggerEnter2D(Collider2D Poptart)
    {
        if (Poptart.CompareTag("Food"))
        {
            ScoreNum += 1;
            UpdateScoreText();
        }
    }

    private void UpdateScoreText()
    {
        MyScore.text = "Score : " + ScoreNum;
    }
}
