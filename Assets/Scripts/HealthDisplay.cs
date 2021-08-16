using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    Text health_text;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        health_text = GetComponent<Text>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        health_text.text = player.Get_Health().ToString();
    }
}
