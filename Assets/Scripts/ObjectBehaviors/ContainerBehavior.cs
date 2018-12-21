using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerBehavior : MonoBehaviour {
    public BaseItem contents;

    private bool isOpen = false;
    private PlayerInventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = GameObject.FindGameObjectWithTag("Managers").GetComponent<PlayerInventoryManager>();
    }

    void OnPlayerUse()
    {
        if (!isOpen)
        {
            isOpen = true;
            inventoryManager.AddItem(contents);
        }
    }
}
