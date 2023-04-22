using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerProgress : MonoBehaviour
{

    [SerializeField]
    private GameObject GameManager;

    public void collectCans()
    {
        GameManager.SendMessage("collectCans");
    }

    public void collectBoards()
    {
        GameManager.SendMessage("collectBoards");
    }

    public void collectPaper()
    {
        GameManager.SendMessage("collectPaper");
    }
}

