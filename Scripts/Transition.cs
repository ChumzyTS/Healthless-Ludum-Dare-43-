using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour {

    public Animator animator;
    public int timeOfAnimation;
    public bool toggleAnimation;

	// Use this for initialization
	void Update () {
		if (toggleAnimation == true)
        {
            RunAnimation();
            toggleAnimation = false;
        }
	}

    void RunAnimation()
    {
        animator.SetBool("Running", true);
        Invoke("StopAnimation", timeOfAnimation);
    }

    void StopAnimation()
    {
        animator.SetBool("Running", false);
    }
}
