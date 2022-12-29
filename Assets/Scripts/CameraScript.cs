using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject marco;

    // Update is called once per frame
    void Update()
    {
        if (marco != null)
        {
            Vector3 position = transform.position;
            position.x = marco.transform.position.x;
            transform.position = position;
        }
           
    }
}
