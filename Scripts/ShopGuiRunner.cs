using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopGuiRunner : MonoBehaviour {

    public Button buttonOpen, buttonClose;
    public Animator buttonAnimator;
    public GameObject buttonOpenGO, window;

	void Start () {
        buttonOpen.onClick.AddListener(Open);
        buttonClose.onClick.AddListener(Close);
    }

    void Open ()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        buttonAnimator.SetBool("Opening", true);
    }

    void Close ()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        buttonAnimator.SetBool("Opening", false);
        Invoke("CloseAfterAnimation", 2);
    }

    void CloseAfterAnimation ()
    {
        buttonOpenGO.SetActive(true);
        window.SetActive(false);
    }
}
