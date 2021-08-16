using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
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
        SceneManager.LoadScene("Game Over");
    }
    public void Game_Quit()
    {
        Application.Quit();
    }
}
