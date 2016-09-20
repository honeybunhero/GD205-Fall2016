using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    Quaternion startRot;
    Quaternion rotRight, rotLeft;
    int playerX, playerZ;
    int walkSpeed;
    bool Alive = true;
    public Text gameText;
    public Text livesText;
    public Text playerPos;
    public Text scoringText;
    public Text winnerText;
    public int Score;
    int Lives;
    int textTimer;
    int timeToRestart;
    bool winner;
    public GameObject points;
    AudioSource sounds;
    public AudioClip Cheering;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        gameText.text = "Welcome to the game. Can you solve the puzzle?";
        playerX = 0;
        playerZ = -3;
        //playerX = 1;
        //playerZ = 24;

        sounds = GetComponent<AudioSource>();
        startRot = Quaternion.Euler(0, 0, 0);
        rotLeft = Quaternion.Euler(0, -90, 0);
        rotRight = Quaternion.Euler(0, 90, 0);
        Score = 0;
        Lives = 3;
        walkSpeed = 5;
        winnerText.text = "";
        scoringText.text = "Score: " + Score;
        livesText.text = "Lives: " + Lives;
        winner = false;
        transform.position = new Vector3(playerX, .5f, playerZ);
    }
    void OnCollisionEnter(Collision col)
    {
        /* if (col.gameObject.CompareTag("Death"))
         {
             if (Alive)
             {
                 transform.position = new Vector3(0, .5f, -3);
                 Lives--;
                 transform.rotation = startRot;
                 livesText.text = "Lives: " + Lives;
                 gameText.text = "You cannot go that far!";
                 textTimer = 0;
             }
         }
         if (Lives <= 0)
         {
             Alive = false;
             gameText.text = "GAME OVER!";
             textTimer = 0;
         }*/
        if (col.gameObject.tag == ("Points"))
        {
            if (!sounds.isPlaying)
            {
                sounds.PlayOneShot(Cheering);
            }
            col.gameObject.SetActive(false);
            Score += 10;
            scoringText.text = "Score: " + Score;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Win")
        {
            if (Score == 40)
            {
                winnerText.text = "Congradulations! You've won!";
                walkSpeed = 0;
                winner = true;
            }
            else
            {

                gameText.text = ("Collect all the points first!");
                transform.position = new Vector3(1, .5f, 24);
            }
        }
    }

    void PlayerMove()
    {
        if (Alive)
        {

            float zWalk = Input.GetAxis("Vertical") * Time.deltaTime;
            transform.Translate(0, 0, zWalk * walkSpeed);
            /* if (Input.GetKeyDown(KeyCode.W))
             {
                 transform.position = transform.position + Camera.main.transform.forward * walkSpeed;
                 //transform.position += Vector3.forward;
                 //transform.position += new Vector3(0, 0, walkSpeed);
             }
             if (Input.GetKeyDown(KeyCode.S))
             {
                 transform.position = transform.position + Camera.main.transform.forward * -walkSpeed;
                 //transform.position -= Vector3.forward;
                 //transform.position += new Vector3(0, 0, -walkSpeed);
             }*/
            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.rotation *= rotLeft;
                //transform.position += new Vector3(-walkSpeed, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.rotation *= rotRight;
                //transform.position += new Vector3(walkSpeed, 0, 0);
            }
        }
    }
    void Update()
    {
        playerX = (int)transform.position.x;
        playerZ = (int)transform.position.z;
        PlayerMove();
        textTimer++;

        playerPos.text = "X: " + playerX + " Z: " + playerZ;

        if (textTimer >= 200)
        {
            gameText.text = "";
            textTimer = 0;
        }
        if (winner)
        {
            timeToRestart++;
        }
        if (timeToRestart >= 100)
        {
            timeToRestart = 0;
            transform.rotation = startRot;
            Start();
        }
    }
}