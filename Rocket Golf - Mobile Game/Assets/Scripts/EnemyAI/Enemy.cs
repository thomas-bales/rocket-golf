using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class Enemy : MonoBehaviour
{
    public int health = 3;
    public int attackPower = 1;

    public bool active = true;

    private void OnEnable()
    {
        GameEvents.OnEnemyTakeDamage += takeDamage;
    }

    private void OnDisable()
    {
        GameEvents.OnEnemyTakeDamage -= takeDamage;
    }
    protected void Update()
    {
        if (health <= 0)
            enemyDeath();
    }

    public void takeDamage(int damage, Enemy enemy)
    {
        if (enemy == this)
            health -= damage;
    }

    public virtual void enemyDeath()
    {
        GameEvents.EnemyDeath(this);
        Destroy(gameObject);
    }
}
