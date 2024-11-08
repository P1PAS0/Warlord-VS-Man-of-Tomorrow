using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform[] spawnPoints;
    public Transform player;
    public int bulletCount = 5;

    private void OnEnable()
    {
        BulletEventManager.Instance.OnBulletsSpawned += HandleBulletsSpawned;
        BulletEventManager.Instance.OnAllBulletsDestroyed += HandleAllBulletsDestroyed;
    }

    private void OnDisable()
    {
        BulletEventManager.Instance.OnBulletsSpawned -= HandleBulletsSpawned;
        BulletEventManager.Instance.OnAllBulletsDestroyed -= HandleAllBulletsDestroyed;
    }

    void Start()
    {
        // Example to start spawning bullets
        BulletEventManager.Instance.SpawnBullets(spawnPoints, bulletCount, player);
    }

    private void HandleBulletsSpawned()
    {
        GameStateManager.Instance.ChangeState(GameState.Slowed);
    }

    private void HandleAllBulletsDestroyed()
    {
        GameStateManager.Instance.ChangeState(GameState.Normal);
    }
}
