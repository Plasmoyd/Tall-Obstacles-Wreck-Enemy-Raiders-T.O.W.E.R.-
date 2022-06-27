using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [SerializeField] int currentHitPoits;

    Enemy enemy;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }
    void OnEnable()
    {
        ResetHitPoints();
    }

    private void ResetHitPoints()
    {
        currentHitPoits = maxHitPoints;
    }

    private void OnParticleCollision(GameObject other)
    {
        currentHitPoits--;

        if(currentHitPoits <= 0)
        {
            gameObject.SetActive(false);
            enemy.RewardGold();
        }
    }
}
