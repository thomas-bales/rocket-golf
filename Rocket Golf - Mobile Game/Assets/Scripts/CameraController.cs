using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController current;

    public float smoothing;
    public Vector2 minPosition, maxPosition;

    public Transform focus;

    private Vector3 targetPosition;

    private void Awake()
    {
        if (!current)
            current = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
            focus = PlayerController.current.gameObject.transform;
    }
    void Update()
    {
        if (transform.position != focus.position)
        {
            targetPosition = new Vector3(focus.position.x, focus.position.y, transform.position.z);

            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
