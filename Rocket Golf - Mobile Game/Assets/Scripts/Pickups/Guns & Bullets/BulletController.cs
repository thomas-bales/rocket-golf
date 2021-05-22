using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float lifeTime = 5f;
    [SerializeField] int attackPower = 1;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Player Bullet"))
            Destroy(gameObject);

        if (collision.gameObject.CompareTag("Enemy"))
            GameEvents.EnemyTakeDamage(attackPower, collision.gameObject.GetComponent<Enemy>());

        if (collision.gameObject.CompareTag("Destructible"))
            GameEvents.DestructibleTakeDamage(attackPower, collision.gameObject.GetComponent<Destructible>());

    }
}
