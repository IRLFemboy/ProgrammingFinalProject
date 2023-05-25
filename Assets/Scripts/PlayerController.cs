using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    float horizontal;
    Rigidbody2D rb;
    BoxCollider2D bc;
    Vector2 move;

    Transform equipSlot;

    public GameObject equippedGun;

    public int health;
    int heartNum;

    public Image[] hearts;
    public Image heart;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    Transform heartContent;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        heartContent = GameObject.Find("HeartContent").transform;
        equipSlot = GameObject.Find("EquipSlot").transform;

        heartNum = health;
        for (int i = 0; i < health; i++)
        {
            var newHeart = Instantiate(heart, heartContent.transform.position, heart.transform.rotation);
            newHeart.transform.SetParent(heartContent);
        }

        GameObject gun = Instantiate(equippedGun, equipSlot.position, equipSlot.rotation);
        gun.transform.SetParent(gameObject.transform);
        GetHearts();
        hearts = GetHearts();
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < heartNum)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    Image[] GetHearts()
    {
        GameObject[] heartsObjects = GameObject.FindGameObjectsWithTag("Heart");
        Image[] hearts = new Image[heartsObjects.Length];
        for (int i = 0; i < heartsObjects.Length; i++)
        {
            hearts[i] = heartsObjects[i].GetComponent<Image>();
        }
        return hearts;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyProjectile"))
        {
            Destroy(collision.gameObject);
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        health--;
    }
}
