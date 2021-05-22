using UnityEngine;

public class PersistentGameObjects : MonoBehaviour
{
    public static PersistentGameObjects current;
    public GameObject[] pGameObjects;

    private void OnEnable()
    {
        GameEvents.OnPlayerDeath += destroyPersistentObjects;
    }

    private void OnDisable()
    {
        GameEvents.OnPlayerDeath -= destroyPersistentObjects;
    }
    void Awake()
    {
        if (!current)
            current = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        foreach (GameObject pObject in pGameObjects)
            DontDestroyOnLoad(pObject);
    }

    void destroyPersistentObjects()
    {
        Destroy(gameObject);

        foreach (GameObject pObject in pGameObjects)
            Destroy(pObject);
    }
}
