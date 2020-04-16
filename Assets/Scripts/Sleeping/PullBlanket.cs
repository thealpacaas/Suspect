using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PullBlanket : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler
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
        startPosition = transform.position;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if ((!manager.LightOff)&&(!manager.BlanketOn))
        {
            if ((gameObject.transform.position.y >= -3) && (gameObject.transform.position.y <= -2))
            {
                transform.position = new Vector3(transform.position.x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, transform.position.z);

                if (gameObject.transform.position.y <= -3)
                {
                    transform.position = startPosition;
                }

                if (gameObject.transform.position.y >= -2)
                {
                    Debug.Log("Blanket On");
                    manager.PutOnBlanket();
                }
            }
        }
        
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeingDragged = null;
        //transform.position = startPosition;
    }
}
