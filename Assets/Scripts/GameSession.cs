using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    int score = 0;
    private void Awake()
    {
        Setup_Singleton();
    }
    private void Setup_Singleton()
    {
        int num_Gamesessions = FindObjectsOfType<GameSession>().Length;
        if(num_Gamesessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public int Get_Score()
    {
        return score;
    }
    public void Add_Score(int score_value)
    {
        score += score_value;
    }
    public void Reset_Game()
    {
        Destroy(gameObject);
    }
}
