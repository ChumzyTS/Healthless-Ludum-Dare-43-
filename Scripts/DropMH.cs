using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropMH : MonoBehaviour {
    public ParticleSystem baseParticles;
    public ParticleSystem dropParticles;
    public ParticleSystem notKilledParticles;
    public GameObject player;
    public int timeUntilRemove;

    private void Start()
    {
        InvokeRepeating("baseParticle", 0.5f, 0.5f);
        Invoke("notKilled", timeUntilRemove);
    }

    private void baseParticle()
    {
        Instantiate(baseParticles, transform.position, transform.rotation);
    }

    public void notKilled()
    {
        Destroy(gameObject);
        Instantiate(notKilledParticles, transform.position, transform.rotation);
    }

    public void Drop()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Instantiate(dropParticles, transform.position, transform.rotation);
        player.gameObject.GetComponent<Player>().addMaxHealth(10);
        Debug.Log("Health Dropped");
    }
}
