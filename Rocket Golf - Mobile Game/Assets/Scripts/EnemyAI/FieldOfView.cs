using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class FieldOfView : MonoBehaviour
{
    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public float sightRadius = 1f;

    [HideInInspector] public Transform target;
    [HideInInspector] public bool canSeePlayer = false;


    void Start()
    {
        target = PlayerController.current.gameObject.transform;
        StartCoroutine(searchPlayerRoutine());
    }

    IEnumerator searchPlayerRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (GetComponent<Enemy>().active)
        {
            searchPlayer();
            yield return wait;
        }
        yield return null;
    }

    void searchPlayer()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, sightRadius, targetMask);

        if (hit)
        {
            Vector2 tempDirection = (target.position - transform.position).normalized;
            float distance = Vector2.Distance(transform.position, target.position);

            if (!Physics2D.Raycast(transform.position, tempDirection, distance, obstructionMask))
                canSeePlayer = true;     
        }
        else if (canSeePlayer) canSeePlayer = false;
    }
}
