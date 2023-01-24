using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    int score;

    public void ScoreManager(int amountToIncrease) // increasing the score
    {
        score += amountToIncrease; // score = score + amountToIncrease;
        Debug.Log("Score is now: " + score);
    }
}
