using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class shell : MonoBehaviour
{
    public float shellSpeed = 1f;
    public GameObject explosion;
    //public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
        shellSpeed = GameObject.Find("ShellSlider").GetComponent<Slider>().value;

        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.TransformDirection(Vector3.forward * shellSpeed);
       
    }

    void OnCollisionEnter(Collision collision)
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
    }
}
