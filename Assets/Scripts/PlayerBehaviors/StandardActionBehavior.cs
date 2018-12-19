using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardActionBehavior : MonoBehaviour
{
    public BoxCollider actionEffectArea;
    public float actionSustainTime = 0.25f;
    public PlayerActionEnum action;
    public string actionButton;

    void Start()
    {
        actionEffectArea.enabled = false;
    }

    void Update()
    {
        if (Input.GetButtonDown(actionButton))
        {
            actionEffectArea.enabled = true;
            Invoke("DisableActionEffectArea", actionSustainTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Can not target self for action
        if (!other.GetComponent<Collider>().CompareTag("Player"))
        {
            other.SendMessage(action.ToString(), SendMessageOptions.DontRequireReceiver);
        }
    }

    private void DisableActionEffectArea()
    {
        actionEffectArea.enabled = false;
    }
}
