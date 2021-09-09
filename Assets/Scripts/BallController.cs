using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour
{
    Rigidbody2D _rb;
    public bool ballUnterwegs = false;
    public bool playerHit, AIHit;
    // public EventTrigger.TriggerEvent scoreTrigger;

    [SerializeField] private int ballSpeed = 1;
    [SerializeField] private int ballBoost = 5;
    public GameManager gm;
    private AudioClip hitSound, wallBounce;
    private AudioSource _audioSource;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        hitSound = (AudioClip)Resources.Load("sounds_impact1");
        wallBounce = (AudioClip)Resources.Load("sounds_impact2");

    }

    void Update()
    {
        float rndy = Random.Range(-1, 1);
        float xInput = Input.GetAxis("Horizontal");
        
        // Checks if the Game is running and left or right Button is pressed to start
        if(!ballUnterwegs && xInput != 0)
        {
            transform.gameObject.SetActive(true);
            if (rndy == 0)
            {
                rndy = 1;
            }
            _rb.AddForce(new Vector2(300, 200 * rndy));
            ballUnterwegs = true;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("PlayerWall"))
        {
            AIHit = true;
            ResetBall();
            if (gm.GetAIScore() == 4)
            {
                gm.Win(false,true);
            }

            if (gm.GetPlayerScore() == 4)
            {
                gm.Win(true, false);
            }
        }
        if (collision.CompareTag("AIWall"))
        {
            playerHit = true;
            ResetBall();
            if (gm.GetAIScore() == 4)
            {
                gm.Win(false,true);
            }

            if (gm.GetPlayerScore() == 4)
            {
                gm.Win(true, false);
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("paddle"))
        {
            // Sound when Ball hits Paddle
            _audioSource.clip = hitSound;
            _audioSource.volume = 0.1f;
            _audioSource.Play();
            
            // adds Force to the Ball
            if(transform.position.x < 0)
                _rb.AddRelativeForce(Vector2.right * ballSpeed, ForceMode2D.Force);
            if(transform.position.x > 0)
                _rb.AddRelativeForce(Vector2.left * ballSpeed, ForceMode2D.Force);
            
            // increase ballSpeed so the Ball gets faster
            ballSpeed += ballBoost;
        }

        if (other.collider.CompareTag("sideWall"))
        {
            _audioSource.clip = wallBounce;
            _audioSource.volume = 0.1f;
            _audioSource.Play();
        }
    }

    // Sets the Ball in the Middle after a Point
    private void ResetBall()
    {
        transform.position = new Vector2(0, 0);
        ballUnterwegs = false;
        _rb.velocity = Vector2.zero;
        ballSpeed = 1;
    }
}
