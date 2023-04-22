using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnTrash : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject canPrefab;
    [SerializeField] private GameObject boardPrefab;
    [SerializeField] private GameObject paperPrefab;
    [SerializeField] private GameObject[] listOfTrash;

    private void Start()
    {
        listOfTrash = new GameObject[] { canPrefab, boardPrefab, paperPrefab};
    }

    // Update is called once per frame
    private void Update()
    {

    }

    public void SpawnTrash()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 tempPos = new Vector3(Random.Range(-10f, 20f), Random.Range(-10f, 20f), 0f);
            GameObject can = Instantiate(listOfTrash[Random.Range(0, 3)], gameObject.transform);
            can.transform.position += tempPos;
        }

    }
}
