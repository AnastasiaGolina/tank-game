using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tank : MonoBehaviour
{
    AudioSource source_tank;
    bool isPlaying = false;
    float MoveSpeed = 0;
    float shellSpeed = 1;
    float RotateSpeed = 1f;


    [SerializeField]
    GameObject sliderMy;
    float sliderValue;
    

    [SerializeField]
    Text tankText;

    [SerializeField]
    Text shellText;

   


    // Start is called before the first frame update
    void Start()
    {
        
        source_tank = GetComponent<AudioSource>();
        sliderValue = sliderMy.GetComponent<Slider>().value;
        tankText.text = "СКОРОСТЬ	ТАНКА : " + sliderValue;
        MoveSpeed = sliderValue;    


    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.TransformDirection(Vector3.forward* MoveSpeed * Input.GetAxis("Vertical"));
        transform.Rotate(0f, Input.GetAxis("Horizontal") * RotateSpeed, 0f);


        if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && !isPlaying)
        {
            source_tank.Play();
            isPlaying = true;
        }
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 && isPlaying)
        {
            source_tank.Stop();
            isPlaying = false;
        }

        
    }

    public void ChangeTankSpeed(float value)
    {
       MoveSpeed = value / 5;
       tankText.text = "СКОРОСТЬ	ТАНКА:" + value;

        
    }

    public void ChangeShellSpeed(float value)
    {
        shellSpeed = value / 110;

        shellText.text = "СКОРОСТЬ	СНАРЯДА	:	" + value;
    }

   
}
