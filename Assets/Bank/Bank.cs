using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingGoldBalance = 150;

    [SerializeField] int currentGoldBalance;
    public int CurrentGoldBalance { get { return startingGoldBalance; } }

    [SerializeField] TextMeshProUGUI text;

    private void Awake()
    {
        currentGoldBalance = startingGoldBalance;
        UpdateDisplay();
    }

    public void Deposit(int amount)
    {
        currentGoldBalance += Mathf.Abs(amount);
        UpdateDisplay();
    }

    public void Withdraw(int amount)
    {
        currentGoldBalance -= Mathf.Abs(amount);
        UpdateDisplay();

        if(currentGoldBalance < 0)
        {
            ReloadScene();
        }
    }

    private void UpdateDisplay()
    {
        text.text = "Gold: " + currentGoldBalance;
    }

    private void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }


}
