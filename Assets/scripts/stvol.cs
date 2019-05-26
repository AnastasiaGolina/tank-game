using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stvol : MonoBehaviour
{
    float min = -35;
    float max = 10;
    float current_angle = 180;
    public GameObject shell;
    Quaternion startRotation;
    // Start is called before the first frame update
    void Start()
    {
        startRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        current_angle += Input.GetAxis("Mouse Y");
        current_angle = Mathf.Clamp(current_angle, min, max);
        Quaternion newRotation = Quaternion.AngleAxis(current_angle, new Vector3(1, 0, 0));
        transform.localRotation = startRotation * newRotation;

        if (Input.GetKeyDown(KeyCode.R))
        {
            Vector3 forwardOfStvol = transform.position + transform.TransformDirection(Vector3.forward * 20f);
            GameObject newShell = Instantiate(shell, forwardOfStvol, transform.rotation);
           // newShell.transform.LookAt(forwardOfStvol);

        }
    }

   


}
