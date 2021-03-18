using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public bool hasChild = false;

    private void Update()
    {
        if(transform.childCount <= 0)
        {
            hasChild = false;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<DragDrop>().hoveringOver = true;
            eventData.pointerDrag.GetComponent<DragDrop>().gameObject.transform.parent = gameObject.transform;
            hasChild = true;
            eventData.pointerDrag.GetComponent<DragDrop>().isChild = true;
        }
    }

}
