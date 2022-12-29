using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Generador : MonoBehaviour
{
    public GameObject EnemigoPrefab;

    public float generatorTimer = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateEnemy",0f ,generatorTimer);
    }

        // Update is called once per frame
    void Update()
    {
        
    }

    void CreateEnemy()
    {
        Instantiate(EnemigoPrefab, transform.position, Quaternion.identity);

    }
}
