using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    Transform muzzle;
    public Rigidbody2D bullet;
    public float bulletSpeed;
    bool canShoot = true;
    public float shootDelay;

    private void Start()
    {
        muzzle = GameObject.Find("muzzle").transform;
    }

    private void Update()
    {
        Shoot();
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
    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
        Debug.Log("You can shoot now! :)");
    }
}
