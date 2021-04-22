using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    public float speed;
    float xVelocity;

    public string username;
    public float checkRadius;
    public LayerMask platform;
    public GameObject groundCheck;
    public GameObject[] hearts;
    public bool isOnGround;
    bool playerDead;
    private int hp = 3;
     
    private void Awake()
    {
        Time.timeScale = 1;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isOnGround = Physics2D.OverlapCircle(groundCheck.transform.position, checkRadius, platform);

        anim.SetBool("isOnGround", isOnGround);

        Movement();
        if (hp == 0)
        {
            username = PlayerPrefs.GetString("username");
            Highscores.AddNewHighscore(username,10*TransferData._instance.layer);
            GameManager.instance.gameOverUI.SetActive(true);
            Time.timeScale = 0;
        }
    }
    

    void Movement()
    {
        xVelocity = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(xVelocity * speed * 1.5f, rb.velocity.y);

        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x)); //Run animation

        if(xVelocity != 0)
        {
            transform.localScale = new Vector3(xVelocity, 1, 1);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Fan"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
        }
        if(other.gameObject.CompareTag("Platform") || other.gameObject.CompareTag("Fan"))
        { 
            TransferData._instance.layer++;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Spike"))
        {
            anim.SetTrigger("dead");
            hp = 0;
            Destroy(hearts[0].gameObject);
            Destroy(hearts[1].gameObject);
            Destroy(hearts[2].gameObject);

        }
        if (other.gameObject.tag == "spine")
        {
            anim.SetTrigger("dead");
            hp -= 1;
            Destroy(hearts[hp].gameObject);
        }
    }

    public void PlayerDead(){
        if(hp == 0)
        {
        TransferData._instance.layer = 0;
        GameManager.GameOver(playerDead);
        Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawWireSphere(groundCheck.transform.position, checkRadius);
    }
}
