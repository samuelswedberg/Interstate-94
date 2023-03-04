using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopMenu : MonoBehaviour
{
    public GameObject mainMenu, shopMenu, vehicles, vm1, vm2, vm3;

    Cosmetics Cosmetics;
    CoinSystem CoinSystem;
    DataManager DataManager;
    public TMP_Text coinText1, coinText2, responseText, v1, v2, v3;

    public string copcarUnlocked, tankerUnlocked, corollaUnlocked;
    int cost1 = 10, cost2 = 15, cost3 = 20;
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
        if(corollaUnlocked == "true")
        {
            v1.SetText("Unlocked");
            vm1.SetActive(true);
        }
        else
            v1.SetText(cost1 + " cones");

        if(tankerUnlocked == "true")
        {
            v2.SetText("Unlocked");
            vm2.SetActive(true);
        }
        else
            v2.SetText(cost2 + " cones");
            
        if(copcarUnlocked == "true")
        {
            v3.SetText("Unlocked");
            vm3.SetActive(true);
        }
        else
            v3.SetText(cost3 + " cones");        

    }
    public void OpenShop()
    {
        mainMenu.SetActive(false);
        shopMenu.SetActive(true);
        vehicles.SetActive(false);
    }

    public void Close()
    {
        mainMenu.SetActive(true);
        shopMenu.SetActive(false);
        vehicles.SetActive(false);
    }

    public void OpenVehicles()
    {
        mainMenu.SetActive(false);
        shopMenu.SetActive(false);
        vehicles.SetActive(true);
        VerifyUnlocks();
    }


    public void CoinAmount()
    {
        coinText1.SetText("Cones: " + CoinSystem.coins);
        coinText2.SetText("Cones: " + CoinSystem.coins);
    }

    public void DefaultVehicle()
    {
        Cosmetics.setVehicle("delorean");
    }
    public void Vehicle1()
    {
        
        if(corollaUnlocked == "true")
        {
            responseText.SetText("You have already unlocked this vehicle");
            ClearResponse();
        }
        else if(CoinSystem.coins >= cost1)
        {
            CoinSystem.coins = CoinSystem.coins - cost1;
            CoinAmount();
            corollaUnlocked = "true";
            v1.SetText("Unlocked");
            Cosmetics.setVehicle("corolla"); // .setVehicle saves 

        }
        else
        {
            if(CoinSystem.coins == 1)
                responseText.SetText("You need " + cost1 + " cones. You have " + CoinSystem.coins + " cone.");
            else
                responseText.SetText("You need " + cost1 + " cones. You have " + CoinSystem.coins + " cones.");

            ClearResponse();
        }
        
    }

    public void Vehicle2()
    {
        if(tankerUnlocked == "true")
        {
            responseText.SetText("You have already unlocked this vehicle");
            ClearResponse();
        }
        else if(CoinSystem.coins >= cost2)
        {
            CoinSystem.coins = CoinSystem.coins - cost2;
            CoinAmount();
            tankerUnlocked = "true";
            v2.SetText("Unlocked");
            Cosmetics.setVehicle("tanker"); // .setVehicle saves 

        }
        else
        {
            if(CoinSystem.coins == 1)
                responseText.SetText("You need " + cost2 + " cones. You have " + CoinSystem.coins + " coin.");
            else
                responseText.SetText("You need " + cost2 + " cones. You have " + CoinSystem.coins + " cones.");

            StartCoroutine(ClearResponse());
        }
    }

    public void Vehicle3()
    {
        if(copcarUnlocked == "true")
        {
            responseText.SetText("You have already unlocked this vehicle");
            ClearResponse();
        }
        else if(CoinSystem.coins >= cost3)
        {
            CoinSystem.coins = CoinSystem.coins - cost3;
            CoinAmount();
            copcarUnlocked = "true";
            v3.SetText("Unlocked");
            Cosmetics.setVehicle("copcar"); // .setVehicle saves 
        }
        else
        {
            if(CoinSystem.coins == 1)
                responseText.SetText("You need " + cost3 + " cone. You have " + CoinSystem.coins + " cone.");
            else
                responseText.SetText("You need " + cost3 + " cones. You have " + CoinSystem.coins + " cones.");
            
            StartCoroutine(ClearResponse());
        }
    }

    IEnumerator ClearResponse()
    {
        yield return new WaitForSeconds(5);
        responseText.SetText("");
    }

    public void selectV1()
    {
        Cosmetics.setVehicle("corolla");
    }

    public void selectV2()
    {
        Cosmetics.setVehicle("tanker");
    }

    public void selectV3()
    {
        Cosmetics.setVehicle("copcar");
    }
}
