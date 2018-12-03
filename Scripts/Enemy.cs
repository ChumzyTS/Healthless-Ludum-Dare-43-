using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health;
    public ParticleSystem deathParticles;
    public ParticleSystem hitParticles;
    public GameObject player;
    public float damage;
    public float timeBtwHits;
    private GameObject gameRunner;

    private float currentTimeBtwHits;


    public void Start()
    {
        currentTimeBtwHits = timeBtwHits;
        InvokeRepeating("decreaseTime", 1f, 1f);
    }

    public void Update()
    {
        GameObject gameRunner = GameObject.FindGameObjectWithTag("GameRunner");
        float score = gameRunner.gameObject.GetComponent<StartGame>().score;
        if (health <= 0)
        {
            FindObjectOfType<AudioManager>().Play("EnemyDeath");
            Debug.Log("Should Be Destroyed");
            DropMH healthDrop = gameObject.GetComponent<DropMH>();
            if (healthDrop != null)
            {
                healthDrop.Drop();
            }
            if (gameObject.name == "Enemy(Clone)")
            {
                gameRunner.gameObject.GetComponent<StartGame>().score += 50;
            }
            else if (gameObject.name == "Enemy_Tall(Clone)")
            {
                gameRunner.gameObject.GetComponent<StartGame>().score += 100;
            }
            else if (gameObject.name == "Enemy_Small(Clone)")
            {
                gameRunner.gameObject.GetComponent<StartGame>().score += 20;
            }
            else if (gameObject.name == "Enemy_Large(Clone)")
            {
                gameRunner.gameObject.GetComponent<StartGame>().score += 200;
            }
            else if (gameObject.name == "Enemy_Boss(Clone)")
            {
                gameRunner.gameObject.GetComponent<StartGame>().score += 5000;
            }
            else if (gameObject.name == "Enemy_Health(Clone)")
            {
                gameRunner.gameObject.GetComponent<StartGame>().score += 250;
            }
            else
            {
                Debug.Log("Not Listed, Named " + gameObject.name);
            }
            Instantiate(deathParticles, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void decreaseTime()
    {
        currentTimeBtwHits -= 1;
    }

    public void takeDamage(int damage)
    {
        Instantiate(hitParticles, transform.position, transform.rotation);
        health -= damage;
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (currentTimeBtwHits <= 0)
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<Player>().TakeDamge(damage);
                currentTimeBtwHits = timeBtwHits;
            }
        }
    }
}
