using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] float attackRange = 15f;
    [SerializeField] ParticleSystem projectileSystem;

    Transform target;


    // Update is called once per frame
    void Update()
    {
        FindClosestTarget();
        AimAtTarget();
    }

    private void FindClosestTarget()
    {
        float minDistance = Mathf.Infinity;
        Transform closestTarget = null;

        Enemy[] enemies = FindObjectsOfType<Enemy>();

        foreach(Enemy enemy in enemies)
        {
            float currentDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if(currentDistance < minDistance)
            {
                closestTarget = enemy.transform;
                minDistance = currentDistance;
            }

            target = closestTarget;
        }
    }

    private void AimAtTarget()
    {
        if (target == null)
        {
            Attack(false);
            return;
        }

        float currentDistance = Vector3.Distance(transform.position, target.transform.position);

        weapon.LookAt(target);


        if (currentDistance <= attackRange)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

    private void Attack(bool isActive)
    {
        var emissionModule = projectileSystem.emission;
        emissionModule.enabled = isActive;
    }
}
