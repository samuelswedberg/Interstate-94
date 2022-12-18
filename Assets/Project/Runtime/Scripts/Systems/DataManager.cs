using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    CoinSystem CoinSystem;
    Cosmetics Cosmetics;
    ShopMenu ShopMenu;

    void Start()
    {
        CoinSystem = FindObjectOfType<CoinSystem>();
        Cosmetics = FindObjectOfType<Cosmetics>();
        ShopMenu = FindObjectOfType<ShopMenu>();
        LoadCharacterInfo();

    }

    public void SaveCharacterInfo()
    {
        PlayerPrefs.SetInt("Coins_Key", CoinSystem.coins);
        PlayerPrefs.SetString("Vehicle_Key", Cosmetics.vehicle);
        PlayerPrefs.SetString("Corolla_Unlocked", ShopMenu.corollaUnlocked);
        PlayerPrefs.SetString("Tanker_Unlocked", ShopMenu.tankerUnlocked);
        PlayerPrefs.SetString("Copcar_Unlocked", ShopMenu.copcarUnlocked);
        Debug.Log("Character saved.");
    }

    public void LoadCharacterInfo()
    {
        CoinSystem.coins = PlayerPrefs.GetInt("Coins_Key");
        Cosmetics.vehicle = PlayerPrefs.GetString("Vehicle_Key");
        ShopMenu.corollaUnlocked = PlayerPrefs.GetString("Corolla_Unlocked");
        ShopMenu.tankerUnlocked = PlayerPrefs.GetString("Tanker_Unlocked");
        ShopMenu.copcarUnlocked = PlayerPrefs.GetString("Copcar_Unlocked");
        Debug.Log("Character loaded. Coins: " + CoinSystem.coins + ". Level: " + "n/a" + ". Vehicle: " + Cosmetics.vehicle + ".");
        Debug.Log("Unlocks> Corolla: " + ShopMenu.corollaUnlocked + ". Tanker: " + ShopMenu.tankerUnlocked + ". Copcar: " + ShopMenu.copcarUnlocked);
    }

    public void DeleteCharacterInfo()
    {
        PlayerPrefs.DeleteAll();
    }
}
