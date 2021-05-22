using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public static PlayerController current;

    public Rigidbody2D rb;

    public int maxHealth = 3;
    [HideInInspector] public static int health;

    [SerializeField] private float speed;

    private void Awake()
    {
        if (!current)
            current = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        health = maxHealth;
    }
    private void OnEnable()
    {
        GameEvents.OnLoadLevel += resetPlayerHandle;
    }

    private void OnDisable()
    {
        GameEvents.OnLoadLevel -= resetPlayerHandle;
    }
    private void Update()
    {
        if (health <= 0)
            playerDeath();
    }
    void OnFire()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos.z = 10;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        transform.up = direction;

        rb.AddForce(-transform.up * speed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            takeDamage(collision.gameObject.GetComponent<Enemy>().attackPower);
        if (collision.gameObject.CompareTag("Hazard"))
            takeDamage(collision.gameObject.GetComponent<Hazard>().attackPower);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Goal")
        {
            GoalController gc = collision.gameObject.GetComponent<GoalController>();
            if (!gc.disable)
                LevelManager.loadLevel(gc.nextLevelID);
        }
    }

    void takeDamage(int damage)
    {
        health -= damage;
        GameEvents.PlayerTakeDamage(damage);
    }

    void playerDeath()
    {
        GameEvents.PlayerDeath();
        LevelManager.loadLevel(0);

        health = maxHealth;
    }

    void resetPlayerHandle()
    {
        StartCoroutine("resetPlayer");
    }

    IEnumerator resetPlayer()                            //Temporary fix, actually beating the level should trigger a "win state", coroutine will not be necessary
    {
        rb.velocity = Vector2.zero;

        yield return new WaitForSeconds(0.05f);

        if (StartController.current)
            transform.position = StartController.current.transform.position;
        else
            Debug.LogWarning("No start point found!");
    }
}



