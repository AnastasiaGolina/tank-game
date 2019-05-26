using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hea : MonoBehaviour
{
    public Canvas Lose;
    public Canvas Win;
    public Text LifeText;
    public float life = 3;

    void Update()
    {
        LifeText.text = "Жизнь танка: " + life.ToString();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("shell"))
        {
            if (gameObject.CompareTag("bot"))
            {
                if (--life < 1)
                {
                    if (GameObject.FindGameObjectsWithTag("bot").Length <= 1)
                    {
                        if (Lose.enabled == false)
                        {
                            Win.enabled = true;
                        }
                    }
                    Destroy(gameObject);
                }
            }

            if (gameObject.CompareTag("Player"))
            {
                if (--life < 1)
                {
                    gameObject.tag = "Untagged";
                    if (Win.enabled == false)
                    {
                        Lose.enabled = true;
                        GetComponent<tank>().enabled = false;
                    }
                }
            }
        }
    }
}

