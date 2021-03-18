using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private Canvas canvas;
    [HideInInspector] public bool hoveringOver = false;
    public bool isChild = false;
    private CanvasGroup canvasGroup;
    public GameObject originalParent;
    public GameObject hoveringParent;
    private RectTransform rectTransform; //Holds the transform of this object in the Canvas
    private Vector2 offset;
    private float originalPositionX;
    private float originalPositionY;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPositionX = rectTransform.anchoredPosition.x;
        originalPositionY = rectTransform.anchoredPosition.y;
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(name);
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position - offset;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
        transform.parent = hoveringParent.transform;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        
        //Resets the body part bak to original position if not placed properly
        if(hoveringOver == false)
        {
            transform.parent = originalParent.transform;
            isChild = false;
            rectTransform.anchoredPosition = new Vector2(originalPositionX, originalPositionY);
        }

        hoveringOver = false;
    }

    public void OnDrop(PointerEventData eventData)
    {

    }

}
