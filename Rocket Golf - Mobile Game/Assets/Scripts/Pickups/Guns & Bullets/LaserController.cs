using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public LineRenderer laser;
    void Update()
    {
        laser.SetPosition(0, GetComponentInParent<Transform>().position);
    }
}
