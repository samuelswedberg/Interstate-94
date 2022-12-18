using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cosmetics : MonoBehaviour
{

    public string vehicle;
    public GameObject delorean, copcar, corolla;

    DataManager DataManager;

    void Start()
    {
        DataManager = FindObjectOfType<DataManager>();
        setVehicle(vehicle);
    }

    void Update()
    {
        
    }

    public void setVehicle(string s) 
    {
       vehicle = s;
        if(vehicle == "" || vehicle == null)
            vehicle = "delorean";

        if(vehicle == "delorean")
        {
            delorean.SetActive(true);
            copcar.SetActive(false);
            corolla.SetActive(false);
            DataManager.SaveCharacterInfo();
        }

        if(vehicle == "copcar")
        {
            delorean.SetActive(false);
            copcar.SetActive(true);
            corolla.SetActive(false);
            DataManager.SaveCharacterInfo();
        }
        
        if(vehicle == "corolla")
        {
            delorean.SetActive(false);
            copcar.SetActive(false);
            corolla.SetActive(true);
            DataManager.SaveCharacterInfo();
        }
    }
}
