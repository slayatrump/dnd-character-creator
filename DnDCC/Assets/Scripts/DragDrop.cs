using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, 
    IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField]
    private Canvas canvas;

    private RectTransform i1;
    private RectTransform i2;
    private RectTransform i3;
    private RectTransform i4;
    private RectTransform i5;
    private RectTransform i6;
    private CanvasGroup cg1;
    private CanvasGroup cg2;
    private CanvasGroup cg3;
    private CanvasGroup cg4;
    private CanvasGroup cg5;
    private CanvasGroup cg6;

    private string isSelected;

    private void Awake()
    {
        i1 = GameObject.Find("n1").GetComponent<RectTransform>();
        i2 = GameObject.Find("n2").GetComponent<RectTransform>();
        i3 = GameObject.Find("n3").GetComponent<RectTransform>();
        i4 = GameObject.Find("n4").GetComponent<RectTransform>();
        i5 = GameObject.Find("n5").GetComponent<RectTransform>();
        i6 = GameObject.Find("n6").GetComponent<RectTransform>();

        cg1 = GameObject.Find("n1").GetComponent<CanvasGroup>();
        cg2 = GameObject.Find("n2").GetComponent<CanvasGroup>();
        cg3 = GameObject.Find("n3").GetComponent<CanvasGroup>();
        cg4 = GameObject.Find("n4").GetComponent<CanvasGroup>();
        cg5 = GameObject.Find("n5").GetComponent<CanvasGroup>();
        cg6 = GameObject.Find("n6").GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isSelected = eventData.pointerDrag.name;

        switch (isSelected)
        {
            case "n1":
                {
                    cg1.blocksRaycasts = false;
                    break;
                }
            case "n2":
                {
                    cg2.blocksRaycasts = false;
                    break;
                }
            case "n3":
                {
                    cg3.blocksRaycasts = false;
                    break;
                }
            case "n4":
                {
                    cg4.blocksRaycasts = false;
                    break;
                }
            case "n5":
                {
                    cg5.blocksRaycasts = false;
                    break;
                }
            case "n6":
                {
                    cg6.blocksRaycasts = false;
                    break;
                }
        }
        Debug.Log("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        isSelected = eventData.pointerDrag.name;

        switch (isSelected)
        {
            case "n1":
                {
                    i1.anchoredPosition += eventData.delta / canvas.scaleFactor;
                    break;
                }
            case "n2":
                {
                    i2.anchoredPosition += eventData.delta / canvas.scaleFactor;
                    break;
                }
            case "n3":
                {
                    i3.anchoredPosition += eventData.delta / canvas.scaleFactor;
                    break;
                }
            case "n4":
                {
                    i4.anchoredPosition += eventData.delta / canvas.scaleFactor;
                    break;
                }
            case "n5":
                {
                    i5.anchoredPosition += eventData.delta / canvas.scaleFactor;
                    break;
                }
            case "n6":
                {
                    i6.anchoredPosition += eventData.delta / canvas.scaleFactor;
                    break;
                }
        }
        Debug.Log("OnDrag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isSelected = eventData.pointerDrag.name;

        switch (isSelected)
        {
            case "n1":
                {
                    cg1.blocksRaycasts = true;
                    break;
                }
            case "n2":
                {
                    cg2.blocksRaycasts = true;
                    break;
                }
            case "n3":
                {
                    cg3.blocksRaycasts = true;
                    break;
                }
            case "n4":
                {
                    cg4.blocksRaycasts = true;
                    break;
                }
            case "n5":
                {
                    cg5.blocksRaycasts = true;
                    break;
                }
            case "n6":
                {
                    cg6.blocksRaycasts = true;
                    break;
                }
        }
        Debug.Log("OnEndDrag");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnDrop(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
