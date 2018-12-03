using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public float offset;
    public GameObject projectile;
    public Transform shotPoint;
    public ParticleSystem particleSystem;
    public GameObject gameRunner;

    private double timeBtwShots;
    public double startTimeBtwShots;

    private void FixedUpdate()
    {
        if (gameRunner.GetComponent<StartGame>().started == true)
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

            if (timeBtwShots <= 0)
            {
                if (Input.GetMouseButton(0))
                {
                    FindObjectOfType<AudioManager>().Play("GunShot");
                    Instantiate(projectile, shotPoint.position, transform.rotation);
                    Instantiate(particleSystem, shotPoint.position, transform.rotation);
                    timeBtwShots = startTimeBtwShots;
                }
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }
}
