using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartButton : MonoBehaviour {

    public Button startButton;
    public GameObject animatorHolder;
    public GameObject gameRunner;
    public GameObject startScreen;

    public void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            FindObjectOfType<AudioManager>().Play("Click");
            StartCoroutine(FStartGame());
        }
    }


    public void Start () {
        startButton.onClick.AddListener(StartGame);
        FindObjectOfType<AudioManager>().Play("Click");
    }

    public void StartGame ()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        StartCoroutine(FStartGame());
    }

    IEnumerator FStartGame()
    {
        animatorHolder.SetActive(true);
        Debug.Log("GameStarted");
        animatorHolder.GetComponent<Transition>().toggleAnimation = true;
        yield return new WaitForSeconds(2);
        FindObjectOfType<AudioManager>().Stop("TitleSong");
        startScreen.SetActive(false);
        gameRunner.GetComponent<StartGame>().start = true;
        FindObjectOfType<AudioManager>().Play("GameSong");
        StopCoroutine(FStartGame());
        animatorHolder.SetActive(false);
    }
}
