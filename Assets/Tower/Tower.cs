using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int goldCost = 25;

    public bool CreateTower(Tower towerPrefab, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();

        if (bank == null)
            return false;

        if (bank.CurrentGoldBalance - goldCost < 0)
            return false;

        Instantiate(towerPrefab, position, Quaternion.identity);
        bank.Withdraw(goldCost);
        return true;
    }
}
