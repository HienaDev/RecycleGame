using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    [SerializeField]
    private string colour;

    public string GetColour()
    {
        return colour;
    } 
}
