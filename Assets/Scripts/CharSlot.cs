using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSlot : MonoBehaviour
{
    public static CharSlot instance;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public delegate void OnUnionItem();
    public OnUnionItem onUnionItem;

    //public 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
