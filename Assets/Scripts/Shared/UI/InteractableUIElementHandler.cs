using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractableUIElementHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public event Action OnMouseOver;
    public event Action OnMouseExit;
    public event Action OnMouseClick;
    
    public void OnPointerEnter(PointerEventData eventData) => OnMouseOver?.Invoke();
    public void OnPointerExit(PointerEventData eventData) => OnMouseExit?.Invoke();
    public void OnPointerClick(PointerEventData eventData) => OnMouseClick?.Invoke();
}
