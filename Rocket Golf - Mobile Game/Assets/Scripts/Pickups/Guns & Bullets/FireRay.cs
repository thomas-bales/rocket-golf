using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRay : FireGun
{
    public int attackPower = 1;
    public LineRenderer laser;
    protected override void Fire()
    {
        StartCoroutine(fireRay());
    }

    IEnumerator fireRay()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);

        if (hit)
        {
            if (hit.transform.CompareTag("Enemy"))
            {
                GameEvents.EnemyTakeDamage(attackPower, hit.transform.GetComponent<Enemy>());
            }
            else if (hit.transform.CompareTag("Destructible"))
                GameEvents.DestructibleTakeDamage(attackPower, hit.transform.GetComponent<Destructible>());

            laser.SetPosition(1, hit.point);
        }
        else
        {
            laser.SetPosition(1, transform.position + transform.up * 100);
        }

        laser.enabled = true;
        
        if (laser.enabled)
            Debug.Log("Enabled Laser");

        yield return new WaitForSeconds(0.05f);

        laser.enabled = false;
    }
}
