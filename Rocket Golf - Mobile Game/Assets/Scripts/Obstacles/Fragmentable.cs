using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
public class Fragmentable : Destructible
{
    public FragmentPattern[] fragPatterns;
    public float explodeForce = 1f;

    private void Awake()
    {
        foreach (FragmentPattern pattern in fragPatterns)
        {
            if (pattern.gameObject.activeInHierarchy)
                Debug.LogError("FragPattern not disabled!");
        }
    }

    public override void DestroyDestructible()
    {
        DestroyFragmentable();
    }

    protected virtual void DestroyFragmentable()
    {
        if (fragPatterns.Length != 0)
        {
            int i = Random.Range(0, fragPatterns.Length);
            fragPatterns[i].transform.parent = null;
            fragPatterns[i].gameObject.SetActive(true);
        }
        gameObject.SetActive(false);
    }

    void enableFragment()
    {
        transform.parent = null;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        rb.bodyType = RigidbodyType2D.Dynamic;

        rb.AddForce(new Vector2(Random.Range(-explodeForce, explodeForce), Random.Range(-explodeForce, explodeForce)));
        rb.AddTorque(Random.Range(-explodeForce, explodeForce));
    }
}
