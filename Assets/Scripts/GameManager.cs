using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score;

    public void GameOver()
    {
        Debug.Log("Game Over");
    }
    public void IncreaseScore()
    {
        score++;
    }
}
