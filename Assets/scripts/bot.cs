using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bot : MonoBehaviour
{

    float moveSpeed = 0.2f;
    float rotSpeedTank = 0.5f;
    float rotSpeedTurret = 0.5f;

    [SerializeField]
    Transform turret, cannon;
    [SerializeField]
    GameObject shell;
    bool canShoot = true;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Зашел в коллайдер");
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("в коллайдере Player");
            float distance = Vector3.Distance(other.transform.position, transform.position); //дистанция
            print(distance);
            Vector3 relativePos = (other.transform.position - transform.position); //вектор направления
            Quaternion newRot = Quaternion.LookRotation(relativePos);
            if (distance > 30)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, newRot, Time.deltaTime * rotSpeedTank);
                transform.position = Vector3.Lerp(transform.position, other.transform.position, Time.deltaTime * moveSpeed);
            }

            turret.transform.rotation = Quaternion.Slerp(turret.rotation, newRot, Time.deltaTime * rotSpeedTurret);

            RaycastHit hit;
            if (Physics.Raycast(turret.position, turret.TransformDirection(Vector3.forward), out hit))
            {
                if (hit.transform.CompareTag("Player") && canShoot) {
                    StartCoroutine(botShoot());
                }
               
            }
        }
    }

    IEnumerator botShoot()
    {
        canShoot = false;
        Vector3 forwardofstvol = cannon.position + cannon.TransformDirection(Vector3.forward * 30f);
        GameObject newShell = Instantiate(shell, forwardofstvol, cannon.rotation);
        newShell.transform.LookAt(forwardofstvol);
        yield return new WaitForSeconds(3f);
        canShoot = true;
    }
}

