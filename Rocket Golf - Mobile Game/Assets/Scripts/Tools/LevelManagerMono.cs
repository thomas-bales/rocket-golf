using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManagerMono : MonoBehaviour
{
    public int levelToLoad = 0;
    public void loadLevelMono(int levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad);
        GameEvents.LoadLevel();
    }
}
