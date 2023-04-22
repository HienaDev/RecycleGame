using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerProgress : MonoBehaviour
{

    public int cansCollected = 0;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void collectCans()
    {
        cansCollected++;
        Debug.Log(cansCollected);
    }
}
