using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [SerializeField] int currentHitPoits;

    void Start()
    {
        currentHitPoits = maxHitPoints;
    }

    private void OnParticleCollision(GameObject other)
    {
        currentHitPoits--;

        if(currentHitPoits <= 0)
        {
            Destroy(gameObject);
        }
    }
}
