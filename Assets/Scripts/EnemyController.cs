using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        bc.enabled = false;

        StartCoroutine(Shoot());
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
        }
    }

    IEnumerator Shoot()
    {
        GameObject NewBullet = Instantiate(enemyBullet, enemyMuzzle.position, enemyBullet.transform.rotation);
        var bulletRb = NewBullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = Vector2.down * bulletSpeed;
        yield return new WaitForSeconds(Random.Range(minimumFireRate, maximumFireRate));
    }
}
