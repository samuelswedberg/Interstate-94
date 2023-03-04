using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cosmetics : MonoBehaviour
{

    public string vehicle;
    public GameObject delorean, copcar, corolla, tanker;
    public TMP_Text v0t, v1t, v2t, v3t;

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
            tanker.SetActive(false);
            copcar.SetActive(false);
            corolla.SetActive(false);
            v0t.SetText("Selected");
            v1t.SetText("Corolla");
            v2t.SetText("Tanker");
            v3t.SetText("Cop Car");
            DataManager.SaveCharacterInfo();
        }

        if(vehicle == "corolla")
        {
            delorean.SetActive(false);
            tanker.SetActive(false);
            copcar.SetActive(false);
            corolla.SetActive(true);
            v0t.SetText("Delorean");
            v1t.SetText("Selected");
            v2t.SetText("Tanker");
            v3t.SetText("Cop Car");
            DataManager.SaveCharacterInfo();
        }

        if(vehicle == "tanker")
        {
            delorean.SetActive(false);
            copcar.SetActive(false);
            corolla.SetActive(false);
            tanker.SetActive(true);
            v0t.SetText("Delorean");
            v1t.SetText("Corolla");
            v2t.SetText("Selected");
            v3t.SetText("Cop Car");
            DataManager.SaveCharacterInfo();
        }
        
        if(vehicle == "copcar")
        {
            delorean.SetActive(false);
            tanker.SetActive(false);
            corolla.SetActive(false);
            copcar.SetActive(true);
             v0t.SetText("Delorean");
            v1t.SetText("Corolla");
            v2t.SetText("Tanker");
            v3t.SetText("Selected");
            DataManager.SaveCharacterInfo();
        }
    }
}
