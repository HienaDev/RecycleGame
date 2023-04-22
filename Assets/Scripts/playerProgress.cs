using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerProgress : MonoBehaviour
{

    [SerializeField] private int cansCollected = 0;

    [SerializeField] private int boardsCollected = 0;

    [SerializeField] private int paperCollected = 0;





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

    public void collectBoards()
    {
        boardsCollected++;
        Debug.Log(boardsCollected);
    }

    public void collectPaper()
    {
        paperCollected++;
        Debug.Log(paperCollected);
    }
}

