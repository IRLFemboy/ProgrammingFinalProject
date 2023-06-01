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
    public static bool isDead;

    Transform equipSlot;
    public GameObject[] gunPrefabs;

    public GameObject equippedGun;

    public int health;
    int heartNum;

    public Image[] hearts;
    public Image heart;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    Transform heartContent;

    Animator anim;
    GameManager gm;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        heartContent = GameObject.Find("HeartContent").transform;
        equipSlot = GameObject.Find("EquipSlot").transform;

        heartNum = health;
        for (int i = 0; i < health; i++)
        {
            var newHeart = Instantiate(heart, heartContent.transform.position, heart.transform.rotation);
            newHeart.transform.SetParent(heartContent);
        }

        int selectedGun = PlayerPrefs.GetInt("selectedGun");
        equippedGun = gunPrefabs[selectedGun];
        GameObject gun = Instantiate(equippedGun, equipSlot.position, equipSlot.rotation);
        gun.transform.SetParent(gameObject.transform);

        GetHearts();
        hearts = GetHearts();
    }

    private void Update()
    {
        if(!isDead)
        {
            horizontal = Input.GetAxisRaw("Horizontal");

            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < health)
                {
                    hearts[i].sprite = fullHeart;
                }
                else
                {
                    hearts[i].sprite = emptyHeart;
                }

                if (i < heartNum)
                {
                    hearts[i].enabled = true;
                }
                else
                {
                    hearts[i].enabled = false;
                }
            }

            if(health <= 0)
            {
                Die();
            }
        }
    }

    private void FixedUpdate()
    {
        if(!isDead)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
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
        if (collision.gameObject.CompareTag("EnemyProjectile") && !isDead)
        {
            Destroy(collision.gameObject);
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        health--;
    }

    void Die()
    {
        isDead = true;
        rb.velocity = Vector2.zero;
        anim.SetBool("isDead", isDead);
    }
}
