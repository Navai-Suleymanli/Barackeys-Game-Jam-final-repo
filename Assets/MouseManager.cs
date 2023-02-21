using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/MenuForvard");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/MenuHover");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       
       FMODUnity.RuntimeManager.PlayOneShot("event:/MenuHover2");
    }

   

  public void ExitApp()
    {
        Application.Quit();

    }
}
