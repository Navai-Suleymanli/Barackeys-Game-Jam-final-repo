using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IPointerDownHandler,IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("MouseDown");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("MouseEnter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("MouseExit");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("MouseUP");
    }

  
}
