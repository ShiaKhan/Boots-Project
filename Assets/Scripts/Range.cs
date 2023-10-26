using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{
    public GameObject cubePrefab;

    [SerializeField] float maxX = 1f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxZ = 1f;
    [SerializeField] float minZ = 1f;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            Vector3 random = new Vector3(Random.Range(maxX ,minX), 5, Random.Range(maxZ,minZ));
            Instantiate(cubePrefab, random, Quaternion.identity);
        }    
    }
}
