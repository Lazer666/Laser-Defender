using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField]float delay_seconds = 1.5f;
    public void Load_Start_Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void Load_Game()
    {
        SceneManager.LoadScene("Game");
    }
    public void Load_Game_Over()
    {
        StartCoroutine(Load_Delay());
    }
    IEnumerator Load_Delay()
    {
        yield return new WaitForSeconds(delay_seconds);
        SceneManager.LoadScene("Game Over");
    }
    public void Game_Quit()
    {
        Application.Quit();
    }
}
