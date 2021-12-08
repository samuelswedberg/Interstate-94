using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject shopMenu;
    CoinSystem CoinSystem;
    public TMP_Text coinText;

    void Start()
    {
        CoinSystem = FindObjectOfType<CoinSystem>();
        CoinAmount();
    }

    public void OpenShop()
    {
        mainMenu.SetActive(false);
        shopMenu.SetActive(true);
    }

    public void CloseShop()
    {
        mainMenu.SetActive(true);
        shopMenu.SetActive(false);
    }

    public void CoinAmount()
    {
        coinText.SetText("Coins: " + CoinSystem.coins);
    }
}
