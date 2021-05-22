using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : FireGun
{
    public GameObject bulletPrefab;
    public float bulletForce = 5f;
    protected override void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(bulletForce * transform.up, ForceMode2D.Impulse);
    }
}
