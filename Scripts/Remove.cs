using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remove : MonoBehaviour {
    public int timeUntilDeath;
	void Start () {
        Invoke("RRemove", timeUntilDeath);
	}

    public void RRemove()
    {
        Destroy(gameObject);
    }
}
