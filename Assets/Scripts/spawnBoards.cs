using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBoards : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject boardPrefab;
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    public void SpawnBoards()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 tempPos = new Vector3(Random.Range(-10f, 20f), Random.Range(-10f, 20f), 0f);
            GameObject can = Instantiate(boardPrefab, gameObject.transform);
            can.transform.position += tempPos;
        }

    }
}
