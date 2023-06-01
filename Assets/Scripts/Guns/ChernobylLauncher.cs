using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChernobylLauncher : Gun
{
    public float explosionDamage;
    public override void Shoot()
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
}
