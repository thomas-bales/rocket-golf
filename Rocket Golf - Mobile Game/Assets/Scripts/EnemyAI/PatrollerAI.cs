using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollerAI : Enemy
{
    [SerializeField] float speed;
    [SerializeField] Transform[] Navpoints;

    private int navPointIndex = 0;
    void Update()
    {
        if (active)
            transform.position = Vector2.MoveTowards(transform.position, Navpoints[navPointIndex].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, Navpoints[navPointIndex].position) < 0.2f)
        {
            navPointIndex++;
            if (navPointIndex >= Navpoints.Length)
                navPointIndex = 0;
        }

        base.Update();
    }
}
