using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitCoin : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter2D(Collider2D coll){

		if (coll.gameObject.tag == "Player") {
			GameManager.addBitCoin ();
			GameManager.nextScene ();
			Destroy (this.gameObject);
		}
	}
}
