using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public GameObject player;
    public Image bar;
    public Text healthText;
    public float number;

    private void FixedUpdate()
    {
        Player playerScript = player.GetComponent<Player>();
        if (playerScript != null)
        {
            float healthRatio = playerScript.Health / playerScript.MaxHealth;
            bar.rectTransform.localScale = new Vector2(healthRatio, 1);

            healthText.text = (((playerScript.Health / 100) * 100).ToString() + "/" + playerScript.MaxHealth.ToString());
        }
    }
}
