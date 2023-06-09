using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collectables : MonoBehaviour
{

    [SerializeField] private int cansCollected = 0;

    [SerializeField] private int boardsCollected = 0;

    [SerializeField] private int paperCollected = 0;

    [SerializeField] private int bottleCollected = 0;

    [SerializeField] private GameObject[] trashList;

    private float timeSinceLastSpawn;

    [SerializeField] private float spawnTimer;

    private GameController gameController;
    //public static collectables Instance;
    private void Awake()
    {
        timeSinceLastSpawn = spawnTimer;
        gameController = GetComponent<GameController>();
    }

    private void Update()
    {
        timeSinceLastSpawn -= Time.deltaTime;
        Debug.Log(timeSinceLastSpawn);
        if (timeSinceLastSpawn < 0)
        {
            timeSinceLastSpawn = spawnTimer;
            SpawnTrash();
        }
    }

    private void SpawnTrash()
    {
        gameController.increaseIdleStrash();
        Vector3 tempPos = new Vector3(Random.Range(-170f, 170f), Random.Range(-100f, 120f), 0f);
        GameObject can = Instantiate(trashList[Random.Range(0, trashList.Length)], gameObject.transform); //-7 - -18 -55 - -66 41 - 30
        
        if ((tempPos.y >= -20 && tempPos.y <= -4) || (tempPos.y >= -70 && tempPos.y <= -50) || (tempPos.y >= 26 && tempPos.y <= 47))
        {
            tempPos.y += 20;
            Debug.Log("uh oh");
        }
        can.transform.position += tempPos;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector3(-240f, -20f, 0f), new Vector3(240f, -20f, 0f));
        Gizmos.DrawLine(new Vector3(-240f, -4f, 0f), new Vector3(240f, -4f, 0f));
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(-240f, -70f, 0f), new Vector3(240f, -70f, 0f));
        Gizmos.DrawLine(new Vector3(-240f, -50f, 0f), new Vector3(240f, -50f, 0f));
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(new Vector3(-240f, 26f, 0f), new Vector3(240f, 26f, 0f));
        Gizmos.DrawLine(new Vector3(-240f, 47f, 0f), new Vector3(240f, 47f, 0f));
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }

    public void collectCans()
    {
        cansCollected++;
        //Debug.Log(cansCollected);
    }

    public void collectBoards()
    {
        boardsCollected++;
        //Debug.Log(boardsCollected);
    }

    public void collectPaper()
    {
        paperCollected++;
        //Debug.Log(paperCollected);
    }

    public void collectBottle()
    {
        bottleCollected++;
        //Debug.Log(bottleCollected);
    }

    
}
