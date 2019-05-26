using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelMove : MonoBehaviour
{
    RectTransform UIGameobject;
    [SerializeField]
    Text btnText;


    float width;
    float changeX;
    float speedPanel;
    float scal;
    

    AudioSource hide;
    bool plays = false;


    enum states { open, close, opening, closing }
    states state = states.open;

   
    // Start is called before the first frame update
    void Start()
    {
        UIGameobject = gameObject.GetComponent<RectTransform>();
        scal = UIGameobject.localScale.x;
        width = UIGameobject.rect.size.x * scal;
        speedPanel = 3;

    }

    // Update is called once per frame
    void Update()
    {
        if (state == states.closing)
        {
            float x = UIGameobject.anchoredPosition.x;
            float y = UIGameobject.anchoredPosition.y;
            x -= speedPanel;
            changeX += speedPanel;
            UIGameobject.anchoredPosition = new Vector2(x, y);

            if (Input.GetMouseButton(0))
            {
                hide.Play();
                plays = true;
            }

            if (changeX > width)
            {
                state = states.close;
                btnText.text = "Открыть";

                

                
            }
        }

      
        if (state == states.opening)
        {
            float x = UIGameobject.anchoredPosition.x;
            float y = UIGameobject.anchoredPosition.y;
            x += speedPanel;
            changeX += speedPanel;
            UIGameobject.anchoredPosition = new Vector2(x, y);

            if (changeX > width)
            {
                state = states.open;
                btnText.text = "Скрыть";

                
            }
        }

        

        
    }

    

    public void ChangePanel()
    {
        if (state == states.open)
            state = states.closing;
        if (state == states.close)
            state = states.opening;
        changeX = 0;
    }

   
}
