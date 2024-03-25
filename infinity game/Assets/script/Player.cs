using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float JumpForce;
    public Vector3 initialPosition;
    GameObject Pause, Exit, Resume, gamePause;
    public bool paused;
    [SerializeField]
    bool isOnGround;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            if (isOnGround == false) 
            { 
                isOnGround = true;
            }
        }
        if (collision.collider.tag == "Obstancle")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void Start()
    {
        initialPosition = transform.position;
        paused = false;
        initialPosition = gameObject.transform.position;
        gamePause = GameObject.Find("GamePause");
        Resume = GameObject.Find("resume");
        Exit = GameObject.Find("exit");
        Pause = GameObject.Find("pause");
        displayPauseButton(false);

    }
    public void pause()
    {
        paused =true;
        displayPauseButton(true);

        Time.timeScale = 0;
    }

    void displayPauseButton (bool state)
    {
        gamePause.SetActive(state);
        Resume.SetActive(state);
        Exit.SetActive(state);
        Pause.SetActive(!state);
    }

    public void resume()
    {
        Time.timeScale = 1;
        displayPauseButton(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isOnGround == true)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * JumpForce);
                isOnGround = false;
            }
        }
    }
}
