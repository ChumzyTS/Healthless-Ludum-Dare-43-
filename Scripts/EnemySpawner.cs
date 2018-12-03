using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

    public GameObject spawnPoint1, spawnPoint2, spawnPoint3, spawnPoint4;
    public int waveNumber;
    public float enemyCount;
    public Text waveShow;
    public Animator waveAnimator;

    public GameObject enemy, tallEnemey, largeEnemy, smallEnemy, bossEnemy, heartEnemy;

    private bool showingAnimation;

    private void Update()
    {
        if (gameObject.GetComponent<StartGame>().started == true)
        {
            GameObject Enemy = GameObject.FindGameObjectWithTag("Enemy");
            if (Enemy == null)
            {
                SpawnEnemies();
            }
            Debug.Log(waveAnimator.GetCurrentAnimatorStateInfo(0).IsName("None"));
            if (waveAnimator.GetCurrentAnimatorStateInfo(0).IsName("None") == true && showingAnimation == true)
            {
                Invoke("stopAnimation", 2.0f);
            }
        }
    }

    private void stopAnimation()
    {
        waveAnimator.SetBool("Show", false);
        showingAnimation = false;
    }

    private void SpawnEnemies()
    {
        FindObjectOfType<AudioManager>().Play("WaveComplete");
        waveNumber += 1;
        waveShow.text = ("Wave - " + waveNumber);
        waveAnimator.SetBool("Show", true);
        showingAnimation = true;
        if (waveNumber > 5) {
            enemyCount = Mathf.RoundToInt((waveNumber ^ (11 / 10)) + (waveNumber * 2) - 12);
        }
        else
        {
            enemyCount = Mathf.RoundToInt(waveNumber * (14 / 10));
        }
        Debug.Log("Wave " + waveNumber + " has " + enemyCount + " Enemies");
        if (waveNumber % 10 == 0)
        {
            Instantiate(bossEnemy, spawnPoint1.transform.position, transform.rotation);
        }
        for (int i = 0; i < enemyCount; i++)
        {
            int spawnChosen = Random.Range(1, 4);
            PropertyName enemyChosen = "";
            if (waveNumber < 5)
            {
                enemyChosen = "Enemy";
            }
            else if (waveNumber < 10)
            {
                int enemyChooser = Random.Range(1, 100);
                if (enemyChooser <= 70)
                {
                    enemyChosen = "Enemy";
                }
                else
                {
                    enemyChosen = "Tall_Enemy";
                }
            }
            else if (waveNumber < 15)
            {
                int enemyChooser = Random.Range(1, 100);
                if (enemyChooser <= 60)
                {
                    enemyChosen = "Enemy";
                }
                else if (enemyChooser <= 90)
                {
                    enemyChosen = "Tall_Enemy";
                }
                else
                {
                    enemyChosen = "Small_Enemy";
                }
            }
            else if (waveNumber < 20)
            {
                int enemyChooser = Random.Range(1, 100);
                if (enemyChooser <= 55)
                {
                    enemyChosen = "Enemy";
                }
                else if (enemyChooser <= 85)
                {
                    enemyChosen = "Tall_enemy";
                }
                else if (enemyChooser <= 95)
                {
                    enemyChosen = "Small_Enemy";
                }
                else
                {
                    enemyChosen = "Large_Enemy";
                }
            }
            else if (waveNumber < 40)
            {
                int enemyChooser = Random.Range(1, 100);
                if (enemyChooser <= (55 - (waveNumber - 20)))
                {
                    enemyChosen = "Enemy";
                }
                else if (enemyChooser <= ((55 - (waveNumber - 20))) + (30 - ((waveNumber - 20) * 0.5)))
                {
                    enemyChosen = "Tall_Enemy";
                }
                else if (enemyChooser <= ((55 - (waveNumber - 20)) + (30 - ((waveNumber - 20) * 0.5)) + 5))
                {
                    enemyChosen = "Small_Enemy";
                }
                else if (enemyChooser <= ((55 - (waveNumber - 20)) + (30 - ((waveNumber - 20) * 0.5)) + 6))
                {
                    enemyChosen = "Health_Enemy";
                }
                else
                {
                    enemyChosen = "Large_Enemy";
                }
            }
            else
            {
                int enemyChooser = Random.Range(1, 10000);
                if (enemyChooser <= (5500 - (waveNumber - 20)))
                {
                    enemyChosen = "Enemy";
                }
                else if (enemyChooser <= ((5500 - ((waveNumber - 20)*100))) + (3000 - ((waveNumber - 20) * 50)))
                {
                    enemyChosen = "Tall_Enemy";
                }
                else if (enemyChooser <= ((55 - (waveNumber - 20))) + 10)
                {
                    enemyChosen = "Tall_Enemy";
                }
                else if (enemyChooser <= ((5500 - ((waveNumber - 20)*100)) + (3000 - ((waveNumber - 20) * 50)) + 5) && waveNumber > 60)
                {
                    enemyChosen = "Small_Enemy";
                }
                else if (enemyChooser <= ((5500 - ((waveNumber - 20) * 100)) + 10 + 5))
                {
                    enemyChosen = "Small_Enemy";
                }
                else if (enemyChooser <= ((5500 - ((waveNumber - 20)*100)) + (3000 - ((waveNumber - 20) * 50)) + 6) && waveNumber > 60)
                {
                    enemyChosen = "Health_Enemy";
                }
                else if (enemyChooser <= ((5500 - ((waveNumber - 20)*100)) + 10 + (50 - ((waveNumber - 40) * 5))))
                {
                    enemyChosen = "Health_Enemy";
                }
                else
                {
                    enemyChosen = "Large_Enemy";
                }
            }
            spawnEnemy(enemyChosen, spawnChosen);
        }

    }

    private void spawnEnemy(PropertyName enemyName, int spawnPoint)
    {
        Vector3 finalSpawnPoint = new Vector3(0, 0, 0);
        GameObject finalEnemyChoise = null;
        if (enemyName == "Enemy")
        {
            finalEnemyChoise = enemy;
        }
        else if (enemyName == "Tall_Enemy")
        {
            finalEnemyChoise = tallEnemey;
        }
        else if (enemyName == "Large_Enemy")
        {
            finalEnemyChoise = largeEnemy;
        }
        else if (enemyName == "Small_Enemy")
        {
            finalEnemyChoise = smallEnemy;
        }
        else if (enemyName == "Boss_Enemy")
        {
            finalEnemyChoise = bossEnemy;
        }
        else if (enemyName == "Health_Enemy")
        {
            finalEnemyChoise = heartEnemy;
        }
        if (spawnPoint == 1)
        {
            finalSpawnPoint = spawnPoint1.transform.position;
        }
        else if (spawnPoint == 2)
        {
            finalSpawnPoint = spawnPoint2.transform.position;
        }
        else if (spawnPoint == 3)
        {
            finalSpawnPoint = spawnPoint3.transform.position;
        }
        else if (spawnPoint == 4)
        {
            finalSpawnPoint = spawnPoint4.transform.position;
        }
        Instantiate(finalEnemyChoise, finalSpawnPoint, transform.rotation);
    }
}
