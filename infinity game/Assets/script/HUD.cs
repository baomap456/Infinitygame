using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Chapter1");
    }

    public void Resume()
    {
        GameObject.FindWithTag("Player").GetComponent<Player>(). Resume();
    }

    public void Pause()
    {
        GameObject.FindWithTag("Player").GetComponent<Player>(). Pause();
    }
    public void Exit()
    {
        Application.Quit();
    }
}
