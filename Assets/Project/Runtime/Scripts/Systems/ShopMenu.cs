using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopMenu : MonoBehaviour
{
    public GameObject mainMenu, shopMenu;

    Cosmetics Cosmetics;
    CoinSystem CoinSystem;
    DataManager DataManager;
    public TMP_Text coinText, responseText, v1, v2, v3;

    public string copcarUnlocked;

    void Start()
    {
        CoinSystem = FindObjectOfType<CoinSystem>();
        Cosmetics = FindObjectOfType<Cosmetics>();
        DataManager = FindObjectOfType<DataManager>();
        CoinAmount();
        VerifyUnlocks();
    }

    private void VerifyUnlocks()
    {
        if(copcarUnlocked == "true")
            v1.SetText("Unlocked");
        else
            v1.SetText("1 coin");

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

    public void DefaultVehicle()
    {
        Cosmetics.setVehicle("delorean");
    }
    public void Vehicle1()
    {
        if(copcarUnlocked == "true")
        {
            responseText.SetText("You have already unlocked this vehicle");
            ClearResponse();
        }
        else if(CoinSystem.coins >= 1)
        {
            CoinSystem.coins = CoinSystem.coins - 1;
            CoinAmount();
            copcarUnlocked = "true";
            v1.SetText("Unlocked");
            Cosmetics.setVehicle("delorean"); // .setVehicle saves 

        }
        else
        {
            if(CoinSystem.coins == 1)
                responseText.SetText("You need 1 coin. You have " + CoinSystem.coins + " coin.");
            else
                responseText.SetText("You need 1 coin. You have " + CoinSystem.coins + " coins.");

            ClearResponse();
        }
        
    }

    public void Vehicle2()
    {
        if(CoinSystem.coins >= 2)
        {
            CoinSystem.coins = CoinSystem.coins - 2;
            CoinAmount();
            Cosmetics.setVehicle("copcar"); // .setVehicle saves 
        }
        else
        {
            if(CoinSystem.coins == 1)
                responseText.SetText("You need 2 coins. You have " + CoinSystem.coins + " coin.");
            else
                responseText.SetText("You need 2 coins. You have " + CoinSystem.coins + " coins.");

            StartCoroutine(ClearResponse());
        }
    }

    public void Vehicle3()
    {
        if(CoinSystem.coins >= 3)
        {
            CoinSystem.coins = CoinSystem.coins - 3;
            CoinAmount();
            Cosmetics.setVehicle("corolla"); // .setVehicle saves 
        }
        else
        {
            if(CoinSystem.coins == 1)
                responseText.SetText("You need 3 coins. You have " + CoinSystem.coins + " coin.");
            else
                responseText.SetText("You need 3 coins. You have " + CoinSystem.coins + " coins.");
            
            StartCoroutine(ClearResponse());
        }
    }

    IEnumerator ClearResponse()
    {
        yield return new WaitForSeconds(5);
        responseText.SetText("");
    }
}
