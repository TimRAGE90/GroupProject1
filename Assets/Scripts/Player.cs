using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rd2d;

    public float speed;

    public float jumpForce;

    public Text scoreText;

    private int score = 0;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        scoreText.text = "Score: " + score;
    }

    void Update()
    {
        //Plays right run animation.
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetInteger("State", 1);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetInteger("State", 0);
        }
        //Plays left run animation.
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetInteger("State", -1);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetInteger("State", 0);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetInteger("State", 0);
        }
    }

    //This is the movement for the character.
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
    }


    //This will be usefull for when we add coins that can give score.
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.tag == "Coin")
        {
            score = score + 100;
            scoreText.text = "Score: " + score;
            Destroy(collision.collider.gameObject);
        }

    }

    //This checks to see if the player can jump off of the ground or any platform.
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                animator.SetInteger("State", 2);
            }
        }
    }
}