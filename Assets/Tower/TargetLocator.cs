using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;

    Transform target;

    void Start()
    {
        target = FindObjectOfType<EnemyMover>().GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        AimAtTarget();
    }

    private void AimAtTarget()
    {
        weapon.LookAt(target);
    }
}
