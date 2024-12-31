using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractivePanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public event Action<Vector2> pointerDown;
    public event Action<Vector2> pointerUp;
    public event Action<Vector2> dragged;

    public void OnDrag(PointerEventData eventData)
    {
        dragged?.Invoke(eventData.position);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown?.Invoke(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pointerUp?.Invoke(eventData.position);
    }
}