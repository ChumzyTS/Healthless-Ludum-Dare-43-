using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public double speed;
    public Animator animator;
    public float Health;
    public float MaxHealth;
    public ParticleSystem hitParticle;
    public float screenLeft;
    public float screenRight;
    public float screenTop;
    public float screenBottom;
    public GameObject gameRunner;

    private Rigidbody2D rb2d;
    private int TimeSinceInput;
    private bool Walking;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        InvokeRepeating("IdleCheck", 1f, 1f);
    }

    
    void FixedUpdate()
    {
        if (gameRunner.GetComponent<StartGame>().started == true)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            float speedFloat = (float)speed; ;
            rb2d.velocity = (movement * speedFloat);
            if (rb2d.velocity.x != 0 || rb2d.velocity.y != 0)
            {
                animator.SetBool("Walking", true);
            }
            else
            {
                animator.SetBool("Walking", false);
            }
            if (transform.position.x < screenLeft)
            {
                transform.position = new Vector3(screenLeft, transform.position.y, 1);
            }
            else if (transform.position.x > screenRight)
            {
                transform.position = new Vector3(screenRight, transform.position.y, 1);
            }
            else if (transform.position.y > screenTop)
            {
                transform.position = new Vector3(transform.position.x, screenTop, 1);
            }
            else if (transform.position.y < screenBottom)
            {
                transform.position = new Vector3(transform.position.x, screenBottom, 1);
            }
            HealthManager();
        }
    }

    void IdleCheck ()
    {
        if (Input.anyKey)
        {
            TimeSinceInput = 0;
            animator.SetInteger("TimeSinceInput", 0);
        }
        else
        {
            TimeSinceInput = TimeSinceInput + 1;
            animator.SetInteger("TimeSinceInput", TimeSinceInput);
        }
    }

    void HealthManager ()
    {
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
        Health = Mathf.Round(Health);
        if (Health <= 0 || MaxHealth <= 0)
        {
            FindObjectOfType<AudioManager>().Play("Death");
            gameRunner.GetComponent<StartGame>().ended = true;
        }
    }

    public void TakeDamge (float damageTaken)
    {
        Health -= damageTaken;
        Instantiate(hitParticle, transform.position, transform.rotation);
    }

    public void addMaxHealth (float healthAdded)
    {
        if (MaxHealth < 100)
        {
            MaxHealth += healthAdded;
        }
        if (MaxHealth > 100)
        {
            MaxHealth = 100;
        }
        Health = MaxHealth;
    }
}
