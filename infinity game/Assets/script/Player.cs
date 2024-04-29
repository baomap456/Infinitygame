using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float Jumppower = 10f;
    private float Speed = 8f;
    private float horizontal;
    private bool isFacingRight = true;
    private Vector3 initialPosition;
    GameObject pause, exit, resume, gamePause;
    private bool paused;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask groundLayer;

    void OnCollisionEnter2D(Collision2D collision)
    {
      
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
        gamePause = GameObject.FindWithTag("GamePause");
        resume = GameObject.FindWithTag("Resume");
        exit = GameObject.FindWithTag("Exit");
        pause = GameObject.FindWithTag("Pause");
        displayPauseButton(false);

    }
    public void Pause()
    {
        paused =true;
        displayPauseButton(true);

        Time.timeScale = 0;
    }

    void displayPauseButton (bool state)
    {
        gamePause.SetActive(state);
        resume.SetActive(state);
        exit.SetActive(state);
        pause.SetActive(!state);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        displayPauseButton(false);
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGround())
        {
            rb.velocity = new Vector2(rb.velocity.x, Jumppower);
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();


    }
    private bool IsGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2 (horizontal * Speed, rb.velocity.y);
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight= !isFacingRight;
            Vector3 localscale = transform.localScale;
            localscale.x *= -1f;
            transform.localScale = localscale;
        }
    }
}
