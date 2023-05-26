using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    Rigidbody2D rb;
    BoxCollider2D bc;
    Vector2 ScreenSize;

    [Header("Bullet Things")]
    public GameObject enemyBullet;
    public Transform enemyMuzzle;
    public float bulletSpeed;
    public float minimumFireRate;
    public float maximumFireRate;

    [Header("Score Addition")]
    int scoreToAdd = 100;

    GameManager gm;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        bc.enabled = false;

        InvokeRepeating("Shoot", Random.Range(minimumFireRate, maximumFireRate), Random.Range(minimumFireRate, maximumFireRate));
        ScreenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        if(tag == "EnemyLeft")
        {
            rb.velocity = Vector2.right * speed;
            Vector2 currentpos = transform.position;
            if (currentpos.x > -ScreenSize.x + 1 && !bc.enabled)
            {
                bc.enabled = true;
                Debug.Log("Box Collider enabled!");
            }
        }

        if(tag == "EnemyRight")
        {
            rb.velocity = Vector2.left * speed;
            Vector2 currentpos = transform.position;
            if (currentpos.x < ScreenSize.x - 1 && !bc.enabled)
            {
                bc.enabled = true;
                Debug.Log("Box Collider enabled!");
            }
        }

        if (enemyBullet != null)
        {
            GameObject newBullet = GameObject.FindGameObjectWithTag("EnemyProjectile");
            if (newBullet != null)
            {
                if (newBullet.transform.position.y < -ScreenSize.y)
                {
                    Destroy(newBullet);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MainCamera"))
        {
            speed *= -1;
        }

        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);

            gm.score += scoreToAdd;
            gm.UpdateScore();
        }
    }

    void Shoot()
    {
        GameObject NewBullet = Instantiate(enemyBullet, enemyMuzzle.position, enemyBullet.transform.rotation);
        var bulletRb = NewBullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = Vector2.down * bulletSpeed;
    }
}
