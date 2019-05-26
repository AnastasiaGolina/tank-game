using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bashya : MonoBehaviour
{
    float bashnyaSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, Input.GetAxis("Mouse X") * bashnyaSpeed, 0f );
    }
}
