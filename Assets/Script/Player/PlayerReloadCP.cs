using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReloadCP : Player {

	// Use this for initialization
	void Start () {
		enabled = false;
	}

	void OnEnable(){
	}

	void FixedUpdate () {
		StartCoroutine (increaseCameraDampTime());
		StartCoroutine (waitAndReload(0.8f));
		enabled = false;
	}

	IEnumerator increaseCameraDampTime(){
		while (MainCamera.damp_time < 0.3f) {
			MainCamera.damp_time = Mathf.Lerp (MainCamera.damp_time, 0.6f, 0.01f);
			yield return new WaitForEndOfFrame ();
		}
	}

	IEnumerator waitAndReload(float s){
		GameManager.addDeath();
		yield return new WaitForSeconds (s);
		StopAllCoroutines ();
		rb.Sleep ();
		transform.rotation = cp.rotation;
		transform.position = cp.position;
		StartCoroutine( decreaseCameradampTime () );
		StartCoroutine (waitCameraOnPositionAndEnableMovement ());
	}

	IEnumerator decreaseCameradampTime(){
		while (!MainCamera.onPosition) {
			MainCamera.damp_time = Mathf.Lerp(MainCamera.damp_time, 0.0f, 0.01f);
			yield return new WaitForEndOfFrame();
		}
	}

	IEnumerator waitCameraOnPositionAndEnableMovement(){
		yield return new WaitUntil (() => MainCamera.onPosition);
		MainCamera.damp_time = 0.0f;
		pl_mov.enabled = true;
	}

}
