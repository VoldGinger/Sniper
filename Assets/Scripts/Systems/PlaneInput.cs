using System;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlaneInput : MonoBehaviour, IPointerClickHandler, IPointerUpHandler
{
    public bool IsClicked;
    public Vector3 StartPosition;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        IsClicked = true;
        StartPosition = eventData.position;
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        IsClicked = false;
    }
}