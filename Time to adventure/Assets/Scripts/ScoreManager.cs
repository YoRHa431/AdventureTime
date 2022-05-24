using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public Text scoreDisplay;

    private void Update()
    {
        scoreDisplay.text = "Ñ÷¸ò: " + score.ToString();
    }

    public void kill()
    {
        score+=125;
    }

}
