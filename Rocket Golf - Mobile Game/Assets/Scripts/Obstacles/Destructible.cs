using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Destructible : MonoBehaviour
{
    public int health = 1;

    private void OnEnable()
    {
        GameEvents.OnDestructibleTakeDamage += takeDamage;
    }

    private void OnDisable()
    {
        GameEvents.OnDestructibleTakeDamage -= takeDamage;
    }
    public virtual void Update()
    {
        if (health <= 0)
        {
            DestroyDestructible();
        }
    }

    public void takeDamage(int damage, Destructible destructible)
    {
        if (destructible == this)
            health -= damage;
    }

    public abstract void DestroyDestructible();
}
