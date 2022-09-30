using System;
using UnityEngine;

public class WinWatcher : MonoBehaviour
{
    public Action Win;
    [SerializeField] private Wallet _targerWallet;
    private int _allCoinsAmount;

    private void Awake()
    {
        var Coins = FindObjectsOfType<CoinEntity>();
        _allCoinsAmount =Coins.Length;
        foreach (var coin in Coins)
        {
            coin.transform.parent = transform;
        }
    }

    private void OnEnable()
    {
        _targerWallet.ChangeAmount += CheckAllCoinsTaken;
    }
    private void OnDisable()
    {
        _targerWallet.ChangeAmount -= CheckAllCoinsTaken;
    }


    private void CheckAllCoinsTaken(uint currentAmount)
    {
        if(currentAmount ==_allCoinsAmount)
        {
            Debug.Log("win");
            Win?.Invoke();
            Time.timeScale = 0;
        }
    }
}
