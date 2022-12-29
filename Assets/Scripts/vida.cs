using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vida : MonoBehaviour
{
    // Start is called before the first frame update
    public int vidas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vidas <= 0)
        {
            Destroy(gameObject);
        }
    }
}
