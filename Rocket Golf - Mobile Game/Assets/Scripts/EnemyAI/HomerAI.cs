using UnityEngine;
using System.Collections;

[RequireComponent(typeof(FieldOfView))]
public class HomerAI : Enemy
{
    public float speed = 1f;

    private Transform target;
    private Vector2 direction;

    void Start()
    {
        target = PlayerController.current.gameObject.transform;
    }
    void Update()
    {
        if (GetComponent<FieldOfView>().canSeePlayer)
            moveEnemy();

        base.Update();
    }

    void moveEnemy()
    {
        direction = (target.position - transform.position).normalized;
        transform.up = direction;

        if (transform.position != target.position)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
