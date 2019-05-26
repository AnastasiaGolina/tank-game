using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class cha : MonoBehaviour, IPointerEnterHandler
{
  

  
    public void OnPointerEnter(PointerEventData eventData)
    {

        gameObject.GetComponent<Image>().color = new Color(1, 0, 1);
      
    }
}
