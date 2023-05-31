using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [HideInInspector] public Transform muzzle;
    [HideInInspector] public bool canShoot = true;
    public Rigidbody2D bullet;
    public float bulletSpeed;
    public float shootDelay;
    public float damage;

    private void Start()
    {
        muzzle = GameObject.Find("muzzle").transform;
    }

    private void Update()
    {
        if(!PlayerController.isDead)
        {
            Shoot();
        }
    }

    public virtual void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            canShoot = false;
            Rigidbody2D newBullet = Instantiate(bullet, muzzle.position, muzzle.rotation);

            newBullet.velocity = Vector2.up * bulletSpeed;
            StartCoroutine(ShootDelay());
            Debug.Log("Pew!");
        }
    }
    public IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }
}
