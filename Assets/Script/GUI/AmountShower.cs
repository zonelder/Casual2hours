using UnityEngine;
using UnityEngine.UI;

public class AmountShower : MonoBehaviour
{
    [SerializeField] private Wallet _targerWallet;
    [SerializeField] private Text _amountTextField;

    private void OnEnable()
    {
        _targerWallet.ChangeAmount += SetAmount;
        if(_targerWallet == null)
        {
          _targerWallet=  FindObjectOfType<Wallet>();
        }
    }
    private void OnDisable()
    {
        _targerWallet.ChangeAmount -= SetAmount;
    }
    private void SetAmount(uint amount)
    {
        _amountTextField.text = amount.ToString();
    }
}
