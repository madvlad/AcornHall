using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardAttackBehavior : MonoBehaviour {

    public GameObject hitBox;
    public float attackSustainTime = 0.25f;

	void Start () {
        hitBox.SetActive(false);
	}
	
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            hitBox.SetActive(true);
            Invoke("DisableWeaponHitbox", attackSustainTime);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        // Can not hit self
        if (!other.GetComponent<Collider>().CompareTag("Player"))
        {
            other.SendMessage("OnPlayerHit");
        }
    }

    private void DisableWeaponHitbox()
    {
        this.hitBox.SetActive(false);
    }
}
