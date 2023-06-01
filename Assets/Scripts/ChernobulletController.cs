using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChernobulletController : MonoBehaviour
{
    public Gun gun;
    public GameObject explosion;

    bool isQuitting;

    // Start is called before the first frame update
    void Start()
    {
        gun = FindObjectOfType<Gun>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyController>())
        {
            EnemyController enemyToDamage = collision.gameObject.GetComponent<EnemyController>();
            enemyToDamage.TakeDamage(gun.damage);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("MainCamera"))
        {
            Destroy(gameObject);
        }
    }

    void OnApplicationQuit()
    {
        isQuitting = true;
    }
    void OnDestroy()
    {
        if (!isQuitting)
        {
            Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}
