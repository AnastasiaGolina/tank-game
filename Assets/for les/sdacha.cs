using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sdacha : MonoBehaviour
{
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
        if (col.gameObject.CompareTag("shell"))
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0, 1, 0);

            Destroy(gameObject,5f);
        }
    }

}
