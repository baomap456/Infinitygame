using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("Chapter1");
    }

    public void resume()
    {
        GameObject.Find("Player").GetComponent<Player>(). resume();
    }

    public void pause()
    {
        GameObject.Find("Player").GetComponent<Player>(). pause();
    }
    public void exit()
    {
        Application.Quit();
    }
}
