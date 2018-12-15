using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardAttackBehavior : MonoBehaviour {

    public BoxCollider hitBox;
    public float attackSustainTime = 0.25f;

	void Start () {
        hitBox.enabled = false;
	}
	
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            hitBox.enabled = true;
            Invoke("DisableWeaponHitbox", attackSustainTime);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        // Can not hit self
        if (!other.GetComponent<Collider>().CompareTag("Player"))
        {
            other.SendMessage("OnPlayerHit", SendMessageOptions.DontRequireReceiver);
        }
    }

    private void DisableWeaponHitbox()
    {
        hitBox.enabled = false;
    }
}
