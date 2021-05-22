using TMPro;
using UnityEngine;

public class EnemyHealthUI : MonoBehaviour
{
    private int health;
    private TextMeshPro txt;

    private void OnEnable()
    {
        GameEvents.OnEnemyTakeDamage += takeDamage;
    }
    private void OnDisable()
    {
        GameEvents.OnEnemyTakeDamage -= takeDamage;
    }
    private void Start()
    {
        health = gameObject.GetComponentInParent<Enemy>().health;
        txt = gameObject.GetComponent<TextMeshPro>();

        txt.text = health.ToString();
    }

    void takeDamage(int damage, Enemy enemy)
    {
        if (enemy == gameObject.GetComponentInParent<Enemy>())
        {
            health -= damage;
            if (health < 0) health = 0;
            txt.text = health.ToString();
        }
    }
}
