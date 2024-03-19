using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum TYPE { Ball }

    public TYPE type;
    public Sprite DefaultImg;
    public int MaxCount;

    private Slot slot;

    private void Awake()
    {
        slot = GameObject.FindGameObjectWithTag("Slot").GetComponent<Slot>();
    }

    void AddItem()
    {
        if (!slot.AddItem(this))
            Debug.Log("NO");
        else
            CreateItem();
    }

    void CreateItem()
    {
        AddItem();
    }
}
