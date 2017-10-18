using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class UIMove : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    , IBeginDragHandler, IDragHandler, IEndDragHandler{

    public static Action<Transform> OnEnter;
    public static Action OnExit;
    
    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerEnter.tag == "Grid")
        {
            if (OnExit != null)
                OnExit();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerEnter.tag == "Grid")
        {
            if (OnEnter != null)
                OnEnter(transform);
        }
    }

    public static Action<Transform> OnDraging;
    public static Action<Transform,Transform> EndDrag;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (OnDraging != null)
                OnDraging(transform);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("draging!");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (EndDrag != null)
            {
                if (eventData.pointerEnter == null)
                    EndDrag(transform, null);
                else
                    EndDrag(transform, eventData.pointerEnter.transform);
            }
        }
    }
}
