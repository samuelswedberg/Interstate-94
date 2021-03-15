using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjKillZone : MonoBehaviour
{

    public void DisableKillZone()
    {
        gameObject.SetActive(false);
    }

    public void EnableKillZone()
    {
        gameObject.SetActive(true);
    }
}
