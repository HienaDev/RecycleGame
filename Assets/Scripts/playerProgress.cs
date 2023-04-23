using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerProgress : MonoBehaviour
{

    [SerializeField]
    private GameObject GameManager;

    [SerializeField] private bool isHolding = false;

    public void collectCans()
    {
        if (isHolding == false)
        {
            isHolding = true;
            GameManager.SendMessage("collectCans");
        }
    }

    public void stopHolding()
    {
        isHolding = false;
    }

    public bool getHolding() => isHolding;
}

