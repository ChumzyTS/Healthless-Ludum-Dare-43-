using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteMusic : MonoBehaviour {

    public Button button;
    public Image panel;
    public GameObject gameRunner;

    private bool muteBool;

	void Start () {
        button.onClick.AddListener(Click);
	}
	
    void Click ()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        if (muteBool == true)
        {
            muteBool = false;
            panel.color = new Color(0, 201, 0);
        }
        else
        {
            muteBool = true;
            panel.color = new Color(201, 0, 0);
        }
    }

    private void Update()
    {
        gameRunner.GetComponent<StartGame>().mute = muteBool;
    }

}
