using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public List<GameObject> AllSlot; //��� ������ ���� ���� ����Ʈ
    public RectTransform InvenRect; //�κ��丮 Rect
    public GameObject OriginSlot;

    public float slotSize;
    public float slotGap;       //���԰� ����
    public float slotCountX;    //������ ���� ����
    public float slotCountY;    //������ ���� ����

    private float InvenWidth;
    private float InvenHeight;
    private float EmptySlot;    //�� ������ ����

    private void Awake()
    {
        InvenWidth = (slotCountX * slotSize) + (slotCountX * slotGap) + slotGap;
        InvenHeight = (slotCountY * slotSize) + (slotCountY * slotGap) + slotGap;

        InvenRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, InvenWidth);
        InvenRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, InvenHeight);

        for(int y = 0; y < slotCountY; y++)
        {
            for(int x = 0; x < slotCountX; x++)
            {
                //������ ����
                GameObject slot = Instantiate(OriginSlot) as GameObject;
                RectTransform slotRect = slot.GetComponent<RectTransform>();
                RectTransform item = slot.transform.GetChild(0).GetComponent<RectTransform>();

                slot.name = "slot_" + y + "_" + x; //���� �̸� ����
                slot.transform.parent = transform; //������ �θ� ����

                slotRect.localPosition = new Vector3((slotSize * x) + (slotSize * (slotGap * x + 1)), -(slotSize * y) + (slotGap * (y + 1)), 0);

                item.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotSize - slotSize * 0.3f);
                item.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotSize - slotSize * 0.3f);

                AllSlot.Add(slot);
            }
        }

        EmptySlot = AllSlot.Count;
    }

    //�������� �ֱ� ���� ���� �˻�
    public bool AddItem(Item item)
    {
        int slotCount = AllSlot.Count;

        for(int i = 0; i < slotCount; i++)
        {
            SlotSystem slotSystem = AllSlot[i].GetComponent<SlotSystem>();

            if (!slotSystem.isSlots())
                continue;

            if(slotSystem.ItemReturn().type == item.type && slotSystem.ItemMax(item))
            {
                slotSystem.AddItem(item);
                return true;
            }
        }

        for(int i = 0; i < slotCount; i++)
        {
            SlotSystem slotSystem = AllSlot[i].GetComponent<SlotSystem>();

            if (slotSystem.isSlots())
                continue;

            slotSystem.AddItem(item);
            return true;
        }

        return false;
    }

    void Init()
    {
        //ItemIO.Load(AllSlot);
    }

    //public SlotSystem NearDisSlot(Vector3 Pos)
    //{
    //    float Min = 10000f;

    //}
}
