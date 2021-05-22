using UnityEngine.SceneManagement;


public static class LevelManager
{
    public static void loadLevel(int levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad);
        GameEvents.LoadLevel();
    }
}