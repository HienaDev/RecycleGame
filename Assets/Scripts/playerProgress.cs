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

    public void collectBoards()
    {
        if (isHolding == false)
        {
            isHolding = true;
            GameManager.SendMessage("collectBoards");
        }
    }

    public void collectPaper()
    {
        if (isHolding == false)
        {
            isHolding = true;
            GameManager.SendMessage("collectPaper");
        }
    }

    public void collectBottle()
    {
        if (isHolding == false)
        {
            isHolding = true;
            GameManager.SendMessage("collectBottle");
        }
    }

    public void stopHolding()
    {
        isHolding = false;
    }

    public bool getHolding() => isHolding;
}

