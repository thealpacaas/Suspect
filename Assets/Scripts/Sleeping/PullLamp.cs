using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PullLamp : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public static GameObject itemBeingDragged;
    Vector3 startPosition;
    Vector3 endPosition;
    private SleepingManager manager;

    private void Awake()
    {
        manager = GameObject.FindObjectOfType<SleepingManager>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;
        startPosition = transform.localPosition;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if ((!manager.LightOff) && (manager.BlanketOn))
            if ((gameObject.transform.localPosition.y >= 2)&&(gameObject.transform.localPosition.y <= 2.5))
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, transform.localPosition.z);

            if (gameObject.transform.localPosition.y <= 1)
            {
                Debug.Log("Lamp Off");
                manager.TurnOffLight();
            }
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeingDragged = null;
        transform.localPosition = startPosition;
    }

}
