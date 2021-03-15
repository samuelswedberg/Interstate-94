using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundBox : MonoBehaviour
{
    public GameObject Top;
    public GameObject Left;
    public GameObject Right;
    public GameObject Bottom;
    public void DisableBounds()
    {
        gameObject.SetActive(false);
    }
    public void EnableBounds()
    {
        gameObject.SetActive(true);
    }

    public void DisableVertical()
    {
        Left.SetActive(false);
        Right.SetActive(false);
    }

    public void EnableVertical()
    {
        Left.SetActive(true);
        Right.SetActive(true);
    }

    public void DisableHorizontal()
    {
        Top.SetActive(false);
    }

    public void EnableHorizontal()
    {
        Top.SetActive(true);
    }
}
