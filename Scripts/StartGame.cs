using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

    public bool start;
    public bool started;
    public bool ended;
    public GameObject projectile;
    public float score;
    public Text scoreText;
    public Text savedScoreText;
    public GameObject player;
    public GameObject gun;
    public GameObject transition;
    public GameObject startScreen;
    public bool mute;
    public bool muteSound;

    void Update()
    {
        if (mute == true)
        {
            FindObjectOfType<AudioManager>().Stop("TitleSong");
            FindObjectOfType<AudioManager>().Stop("GameSong");
        }
        if (muteSound == true)
        {
            FindObjectOfType<AudioManager>().Stop("Click");
            FindObjectOfType<AudioManager>().Stop("GunShot");
            FindObjectOfType<AudioManager>().Stop("Death");
            FindObjectOfType<AudioManager>().Stop("EnemyDeath");
            FindObjectOfType<AudioManager>().Stop("WaveComplete");
        }
        scoreText.text = score.ToString();
        if (ended == true)
        {
            ended = false;
            EndGame();
        }
        if (start == true)
        {
            started = true;
            start = false;
            SStartGame();
        }
    }

    void Start () {
        SStartGame();
	}

    public void SStartGame()
    {
        gameObject.GetComponent<EnemySpawner>().waveNumber = 0;
        score = 0;
        projectile.gameObject.GetComponent<Projectile>().damage = projectile.gameObject.GetComponent<Projectile>().damageDefault;
        player.GetComponent<Player>().MaxHealth = 100;
        player.GetComponent<Player>().Health = 100;
        player.GetComponent<Player>().speed = 2.5;
        gun.GetComponent<Gun>().startTimeBtwShots = 0.25;
        player.transform.position = new Vector3(0, 0, 0);
    }

    public void EndGame()
    {
        FindObjectOfType<AudioManager>().Stop("GameSong");
        started = false;
        savedScoreText.text = scoreText.text;
        StartCoroutine(FEndGame());
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (var i = 0; i < Enemies.Length; i++)
        {
            Destroy(Enemies[i]);
        }
    }

    IEnumerator FEndGame()
    {
        transition.SetActive(true);
        transition.GetComponent<Transition>().toggleAnimation = true;
        yield return new WaitForSeconds(2);
        startScreen.SetActive(true);
        transition.SetActive(false);
        StopCoroutine(FEndGame());
    }
}
