using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyController : MonoBehaviour
{
    [SerializeField] private Text moneyText;
    private static float _money;

    void Update()
    {     
        moneyText.text = "$" + Money.ToString();
    }

    public static float Money { 
        get { return _money; } 
        set { _money = value; } }

}
