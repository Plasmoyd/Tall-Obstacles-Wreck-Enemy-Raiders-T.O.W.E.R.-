using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingGoldBalance = 150;

    [SerializeField] int currentGoldBalance;
    public int CurrentGoldBalance { get { return startingGoldBalance; } }

    private void Awake()
    {
        currentGoldBalance = startingGoldBalance;
    }

    public void Deposit(int amount)
    {
        currentGoldBalance += Mathf.Abs(amount);
    }

    public void Withdraw(int amount)
    {
        currentGoldBalance -= Mathf.Abs(amount);

        if(currentGoldBalance < 0)
        {
            ReloadScene();
        }
    }

    private void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }


}
