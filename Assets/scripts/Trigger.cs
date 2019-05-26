using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField]
    AudioClip clipIN;

    [SerializeField]
    AudioClip clipOUT;

    bool scale = false;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("shell") || col.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), 0, 0);
            GetComponent<AudioSource>().PlayOneShot(clipIN);
            StartCoroutine(Scaler());
            
        }
    }
    void Update()
    {
        if (scale)
        {
            transform.localScale *= 1.005f;
        }
    }
    IEnumerator Scaler()
    {
        scale = true;
        yield return new WaitForSeconds(3f);
        scale = false;
        GetComponent<AudioSource>().PlayOneShot(clipOUT);
        Destroy(gameObject, clipOUT.length);

    }


}
