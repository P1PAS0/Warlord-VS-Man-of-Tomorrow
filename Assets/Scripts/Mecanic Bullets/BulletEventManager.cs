using System;
using System.Collections.Generic;
using UnityEngine;

public class BulletEventManager : MonoBehaviour
{
    public static BulletEventManager Instance { get; private set; }

    public event Action OnBulletsSpawned;
    public event Action OnAllBulletsDestroyed;

    private List<GameObject> activeBullets = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SpawnBullets(Transform[] spawnPoints, int bulletCount, Transform player)
    {
        for (int i = 0; i < bulletCount; i++)
        {
            Transform spawnPoint = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];
            GameObject bullet = BulletPool.Instance.GetBullet();
            bullet.transform.position = spawnPoint.position;
            bullet.GetComponent<Bullet>().SetTarget(player);
            activeBullets.Add(bullet);
        }

        OnBulletsSpawned?.Invoke();
    }

    public void BulletDestroyed(GameObject bullet)
    {
        activeBullets.Remove(bullet);
        BulletPool.Instance.ReturnBullet(bullet);

        if (activeBullets.Count == 0)
        {
            OnAllBulletsDestroyed?.Invoke();
        }
    }
}
