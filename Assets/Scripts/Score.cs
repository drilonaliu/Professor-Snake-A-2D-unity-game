using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    public TextMeshPro score_text;
    public int score_value = 0;

    public void increase()
    {
        score_value += 10;
        updateScore();
    }

    public void decrease()
    {
        if (score_value >= 10)
        {
            score_value -= 10;
            updateScore();
        }

    }

    public void reset()
    {
        score_value = 0;
        updateScore();
    }
    
    public void updateScore()
    {
        score_text.text = score_value + "";
    }
}
