using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{
    AudioSource hide;
   // bool plays = false;
    // Start is called before the first frame update
    void Start()
    {
        hide = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            hide.Play();
            //plays = true;
        }
    }
}
