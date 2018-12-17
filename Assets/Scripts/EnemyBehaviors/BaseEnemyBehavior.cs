using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basic behavior for all enemies
/// </summary>
public class BaseEnemyBehavior : MonoBehaviour {

    public int CurrentHealth;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // All enemies lose health on hit
    public void OnPlayerHit()
    {
        CurrentHealth--;

        if (CurrentHealth == 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
