using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartController : MonoBehaviour
{
    public static StartController current;

    private void Awake()
    {
        if (!current)
            current = this;
        else Destroy(gameObject);
    }
}
