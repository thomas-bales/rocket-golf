using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    private int health;
    private TextMeshProUGUI txt;

    private void OnEnable()
    {
        GameEvents.OnPlayerTakeDamage += takeDamage;
    }
    private void OnDisable()
    {
        GameEvents.OnPlayerTakeDamage -= takeDamage;
    }
    void Start()
    {
        health = PlayerController.health;
        txt = gameObject.GetComponent<TextMeshProUGUI>();

        txt.text = health.ToString();
    }
    void takeDamage(int damage)
    {
        health -= damage;
        if (health < 0) health = 0;
        txt.text = health.ToString();
    }
}
