using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public abstract class PickupItem : MonoBehaviour
{
    public abstract void Pickup();
    protected GameObject player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            Pickup();
            Destroy(gameObject);
        }
    }
}
