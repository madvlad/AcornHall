using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerBehavior : MonoBehaviour {
    public GameObject contents;

    private bool isOpen = false;

	void OnPlayerUse()
    {
        if (!isOpen)
        {
            isOpen = true;
            Debug.Log("Got " + contents.name);
        }
    }
}
