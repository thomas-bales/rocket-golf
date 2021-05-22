using System;
using UnityEngine;

public static class GameEvents
{
    public static Action<int> OnPlayerTakeDamage;
    public static void PlayerTakeDamage(int damage)
    {
        Debug.Log("Player has taken damage.");
        OnPlayerTakeDamage?.Invoke(damage);
    }




    public static Action<int, Enemy> OnEnemyTakeDamage;
    public static void EnemyTakeDamage(int damage, Enemy enemy)
    {
        Debug.Log("Enemy has taken damage.");
        OnEnemyTakeDamage?.Invoke(damage, enemy);
    }




    public static Action<int, Destructible> OnDestructibleTakeDamage;
    public static void DestructibleTakeDamage(int damage, Destructible destructible)
    {
        Debug.Log("Destructible took damage.");
        OnDestructibleTakeDamage?.Invoke(damage, destructible);
    }




    public static Action<Enemy> OnEnemyDeath;
    public static void EnemyDeath(Enemy enemy)
    {
        Debug.Log("Enemy has died.");
        OnEnemyDeath?.Invoke(enemy);
    }



    public static Action OnPlayerDeath;
    public static void PlayerDeath()
    {
        Debug.Log("Player has died.");
        OnPlayerDeath?.Invoke();
    }


    public static Action OnLoadLevel;
    public static void LoadLevel()
    {
        Debug.Log("Loading Level.");
        OnLoadLevel?.Invoke();
    }

}


