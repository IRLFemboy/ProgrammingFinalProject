using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChernobulletExplosion : MonoBehaviour
{
    public ChernobylLauncher launcher;
    public Gun gun;

    private void Start()
    {
        launcher = FindObjectOfType<ChernobylLauncher>();

        gun = FindObjectOfType<Gun>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyController>())
        {
            Debug.Log("Enemy collision!");
            EnemyController enemyToDamage = collision.gameObject.GetComponent<EnemyController>();
            enemyToDamage.TakeDamage(launcher.explosionDamage);
        }
    }
}
