using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basic behavior for all enemies
/// </summary>
public class BaseEnemyBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnPlayerHit()
    {
        Debug.Log("Enemy hit");
    }
}
