using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentPattern : MonoBehaviour
{
    private void OnEnable()
    {
        BroadcastMessage("enableFragment");
        gameObject.SetActive(false);
    }
}
