using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    CoinSystem CoinSystem;

    void Start()
    {
        CoinSystem = FindObjectOfType<CoinSystem>();
        LoadCharacterInfo();

    }

    public void SaveCharacterInfo()
    {
        PlayerPrefs.SetInt("Coins_Key", CoinSystem.coins);
        Debug.Log("Character saved. Coins: " + CoinSystem.coins + ". Level: " + "n/a" + ". Vehicle: " + "n/a"+ ".");
    }

    public void LoadCharacterInfo()
    {
        CoinSystem.coins = PlayerPrefs.GetInt("Coins_Key");
        Debug.Log("Character loaded. Coins: " + CoinSystem.coins + ". Level: " + "n/a" + ". Vehicle: " + "n/a"+ ".");
    }

    public void DeleteCharacterInfo()
    {
        PlayerPrefs.DeleteAll();
    }
}
