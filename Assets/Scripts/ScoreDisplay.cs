using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    Text score_text;
    GameSession game_session;
    // Start is called before the first frame update
    void Start()
    {
        score_text = GetComponent<Text>();
        game_session = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        score_text.text = game_session.Get_Score().ToString();
    }
}
