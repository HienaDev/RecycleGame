using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collectables : MonoBehaviour
{

    [SerializeField] private int cansCollected = 0;

    [SerializeField] private int boardsCollected = 0;

    [SerializeField] private int paperCollected = 0;


    public static collectables Instance;


    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(1);
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
