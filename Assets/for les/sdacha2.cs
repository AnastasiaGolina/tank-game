using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sdacha2 : MonoBehaviour
{

    public GameObject cube1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
         {
            Destroy(cube1, 5f);
        }
    }

}
