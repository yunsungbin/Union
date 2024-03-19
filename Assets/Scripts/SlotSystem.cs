using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotSystem : MonoBehaviour
{
    public Stack<Item> slot;
    public Text text;
    public Sprite DefaultImg;

    private Image ItemImg;
    private bool isSlot;

    public Item ItemReturn() { return slot.Peek(); }
    public bool ItemMax(Item item) { return ItemReturn().MaxCount > slot.Count; }
    public bool isSlots() { return isSlot; }
    public void SetSlots(bool isSlot) { this.isSlot = isSlot; }

    // Start is called before the first frame update
    void Start()
    {
        slot = new Stack<Item>();

        isSlot = false;

        float Size = text.gameObject.transform.parent.GetComponent<RectTransform>().sizeDelta.x;
        text.fontSize = (int)(Size * 0.5f);

        ItemImg = transform.GetChild(0).GetComponent<Image>();
    }

    public void AddItem(Item item)
    {
        slot.Push(item);
        UpdateInfo(true, item.DefaultImg);
    }

    public void ItemUse()
    {
        if (slot.Count == 1)
            return;

        if(slot.Count == 2)
        {
            UpdateInfo(true, DefaultImg);
            return;
        }

        slot.Pop();
        UpdateInfo(isSlot, ItemImg.sprite);
    }

    public void UpdateInfo(bool isSlot, Sprite sprite)
    {
        SetSlots(isSlot);
        ItemImg.sprite = sprite;
        text.text = slot.Count > 0 ? slot.Count.ToString() : "";
        //ItemIO.SaveDate();
    }
}
