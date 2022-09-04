using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyController : MonoBehaviour
{
    [SerializeField] private Text moneyText;
    private static float _startMoney = 0;
    private static float _money;

    private void Start()
    {
        Money = _startMoney;
    }

    void Update()
    {     
        moneyText.text = " " + Money.ToString();
    }

    public static float Money { 
        get { return _money; } 
        set { _money = value; } }

}
