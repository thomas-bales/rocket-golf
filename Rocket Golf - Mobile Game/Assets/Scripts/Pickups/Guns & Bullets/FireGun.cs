using UnityEngine;


public abstract class FireGun : MonoBehaviour
{
    protected void Start()
    {
        
    }
    protected void OnFire()
    {
        if (this.enabled)
            Fire();
    }

    protected abstract void Fire();
}
