using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyScript : MonoBehaviour {
    public Button damage, atcSpeed, mvmSpeed;
    public GameObject player, gun, projectile;

    public int damageUpCost;
    public int playerSpeedUpCost;
    public int timeBtwShotsUpCost;

    public Text damageText;
    public Text playerSpeedText;
    public Text timeBtwShotsText;

    public ParticleSystem buyParticles;

    private void Update()
    {
        double timeBtwShots = gun.gameObject.GetComponent<Gun>().startTimeBtwShots;
        float damageValue = projectile.gameObject.GetComponent<Projectile>().damage;
        float projectileSpeed = projectile.gameObject.GetComponent<Projectile>().speed;
        double playerSpeed = player.gameObject.GetComponent<Player>().speed;
        float maxHealth = player.gameObject.GetComponent<Player>().MaxHealth;

        damageText.text = damageValue.ToString();
        playerSpeedText.text = playerSpeed.ToString();
        timeBtwShotsText.text = timeBtwShots.ToString();
    }
    void Start () {
        damage.onClick.AddListener(buyDamage);
        atcSpeed.onClick.AddListener(buyAtcSpeed);
        mvmSpeed.onClick.AddListener(buyMvmSpeed);
	}

    void buyDamage()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        double timeBtwShots = gun.gameObject.GetComponent<Gun>().startTimeBtwShots;
        float damageValue = projectile.gameObject.GetComponent<Projectile>().damage;
        float projectileSpeed = projectile.gameObject.GetComponent<Projectile>().speed;
        double playerSpeed = player.gameObject.GetComponent<Player>().speed;
        float maxHealth = player.gameObject.GetComponent<Player>().MaxHealth;

        if (maxHealth > damageUpCost)
        {
            Debug.Log("Purchased Attack Upgrade");
            projectile.gameObject.GetComponent<Projectile>().damage += 1;
            player.gameObject.GetComponent<Player>().MaxHealth -= damageUpCost;
            Instantiate(buyParticles, player.transform.position, transform.rotation);
            if (player.gameObject.GetComponent<Player>().Health > player.gameObject.GetComponent<Player>().MaxHealth)
            {
                player.gameObject.GetComponent<Player>().Health = player.gameObject.GetComponent<Player>().MaxHealth;
            }
        }
    }

    void buyAtcSpeed()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        double timeBtwShots = gun.gameObject.GetComponent<Gun>().startTimeBtwShots;
        float damageValue = projectile.gameObject.GetComponent<Projectile>().damage;
        float projectileSpeed = projectile.gameObject.GetComponent<Projectile>().speed;
        double playerSpeed = player.gameObject.GetComponent<Player>().speed;
        float maxHealth = player.gameObject.GetComponent<Player>().MaxHealth;

        if (maxHealth > timeBtwShotsUpCost)
        {
            Debug.Log("Purchased Attack Speed Upgrade");
            gun.gameObject.GetComponent<Gun>().startTimeBtwShots -= 0.01;
            player.gameObject.GetComponent<Player>().MaxHealth -= timeBtwShotsUpCost;
            Instantiate(buyParticles, player.transform.position, transform.rotation);
            if (player.gameObject.GetComponent<Player>().Health > player.gameObject.GetComponent<Player>().MaxHealth)
            {
                player.gameObject.GetComponent<Player>().Health = player.gameObject.GetComponent<Player>().MaxHealth;
            }
        }
    }

    void buyMvmSpeed()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        double timeBtwShots = gun.gameObject.GetComponent<Gun>().startTimeBtwShots;
        float damageValue = projectile.gameObject.GetComponent<Projectile>().damage;
        float projectileSpeed = projectile.gameObject.GetComponent<Projectile>().speed;
        double playerSpeed = player.gameObject.GetComponent<Player>().speed;
        float maxHealth = player.gameObject.GetComponent<Player>().MaxHealth;

        if (maxHealth > playerSpeedUpCost)
        {
            Debug.Log("Purchased Player Speed Upgrade");
            player.gameObject.GetComponent<Player>().speed += 0.25;
            player.gameObject.GetComponent<Player>().MaxHealth -= playerSpeedUpCost;
            Instantiate(buyParticles, player.transform.position, transform.rotation);
            if (player.gameObject.GetComponent<Player>().Health > player.gameObject.GetComponent<Player>().MaxHealth)
            {
                player.gameObject.GetComponent<Player>().Health = player.gameObject.GetComponent<Player>().MaxHealth;
            }
        }
    }
}
