using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] trashObjects;
/*    private Dictionary<int, GameObject> trashObjects;

    [SerializeField]
    private GameObject B_Trash_1;
    [SerializeField]
    private GameObject B_Trash_2;
    [SerializeField]
    private GameObject B_Trash_3;
    [SerializeField]
    private GameObject B_Trash_4;

    [SerializeField]
    private GameObject G_Trash_1;
    [SerializeField]
    private GameObject G_Trash_2;
    [SerializeField]
    private GameObject G_Trash_3;

    [SerializeField]
    private GameObject Y_Trash_1;
    [SerializeField]
    private GameObject Y_Trash_2;*/

    // Start is called before the first frame update
    void Start()
    {
/*        trashObjects = new Dictionary<int, GameObject>();
        trashObjects.Add(0, B_Trash_1);
        trashObjects.Add(1, B_Trash_2);
        trashObjects.Add(2, B_Trash_3);
        trashObjects.Add(3, B_Trash_4);
        
        trashObjects.Add(4, G_Trash_1);
        trashObjects.Add(5, G_Trash_2);
        trashObjects.Add(6, G_Trash_3);
        
        trashObjects.Add(7, Y_Trash_1);
        trashObjects.Add(8, Y_Trash_2);*/

        SpawnTrash();
    }

    public void SpawnTrash()
    {
        int choice = Random.Range(0, trashObjects.Length);
        Instantiate(trashObjects[choice], new Vector3(-150, 70, 0), Quaternion.identity);
    }    
}
