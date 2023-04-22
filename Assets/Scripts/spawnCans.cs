using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCans : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject canPrefab;
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void SpawnCans()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 tempPos = new Vector3(Random.Range(-10f, 20f), Random.Range(-10f, 20f), 0f);
            GameObject can = Instantiate(canPrefab, gameObject.transform);
            can.transform.position += tempPos;
        }
        
    }
}
