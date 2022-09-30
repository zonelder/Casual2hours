using UnityEngine;
using System;

public class Wallet : MonoBehaviour
{
    public Action<uint> ChangeAmount;
    private uint _coinAmount;

    public void AddCoin()
    {
        _coinAmount++;
        ChangeAmount?.Invoke(_coinAmount);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<CoinEntity>(out CoinEntity coin))
        {
            AddCoin();
            coin.gameObject.SetActive(false);
        }
    }
}
