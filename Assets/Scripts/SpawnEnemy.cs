using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public int enemyCap;
    public GameObject enemy;
    public GameObject[] enemySpawnPointLeft;
    public GameObject[] enemySpawnPointRight;
    bool hasReachedCap;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies", 1, 1);
    }

    void SpawnEnemies()
    {
        var enemyAmount = FindObjectsOfType<EnemyController>();
        for (int i = 0; i < enemySpawnPointLeft.Length; i++)
        {
            var pointLeft = enemySpawnPointLeft[i].transform;
            if (enemyAmount.Length < enemyCap && !hasReachedCap)
            {
               GameObject enemyLeft = Instantiate(enemy, pointLeft.position, enemy.transform.rotation);
               enemyLeft.tag = "EnemyLeft";
            }
        }

        for (int i = 0; i < enemySpawnPointRight.Length; i++)
        {
            var pointRight = enemySpawnPointRight[i].transform;
            if (enemyAmount.Length < enemyCap && !hasReachedCap)
            {
                GameObject enemyRight = Instantiate(enemy, pointRight.position, enemy.transform.rotation);
                enemyRight.tag = "EnemyRight";
            }
        }

        if (enemyAmount.Length == 0)
        {
            StartCoroutine(WaitToSpawnNextWave());
        }

        if(enemyAmount.Length == enemyCap)
        {
            hasReachedCap = true;
        }
    }

    IEnumerator WaitToSpawnNextWave()
    {
        yield return new WaitForSeconds(3);
        hasReachedCap = false;
    }
}
