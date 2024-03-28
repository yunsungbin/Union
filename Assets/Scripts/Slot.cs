using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            ItemDrag itemDrag = eventData.pointerDrag.GetComponent<ItemDrag>();
            itemDrag.parentAfterDrag = transform;
        }
    }
}
