using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDrag : MonoBehaviour
{
    public Transform Img;

    private Image EmptyImg;
    private SlotSystem slotSystem;

    Slot slot;

    // Start is called before the first frame update
    void Start()
    {
        slotSystem = GetComponent<SlotSystem>();

        Img = GameObject.FindGameObjectWithTag("DragImg").transform;

        EmptyImg = Img.GetComponent<Image>();
    }

    public void Down()
    {
        if (!slotSystem.isSlots())
            return;

        Img.gameObject.SetActive(true);

        float Size = slotSystem.transform.GetComponent<RectTransform>().sizeDelta.x;
        EmptyImg.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Size);
        EmptyImg.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Size);

        EmptyImg.sprite = slotSystem.ItemReturn().DefaultImg;
        Img.transform.position = Input.mousePosition;
        slotSystem.UpdateInfo(true, slotSystem.DefaultImg);
        slotSystem.text.text = "";
    }

    public void Drag()
    {
        if (!slotSystem.isSlots())
            return;

        Img.transform.position = Input.mousePosition;
    }

    public void DragEnd()
    {
        if (!slotSystem.isSlots())
            return;

        //slot.Swap
    }
}
