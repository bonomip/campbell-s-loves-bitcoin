using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Player {

	static bool key_W;
	static bool key_G;  //use to save state
	static bool key_K;	//use to restore checkpoint
    static bool key_H;  // use to show/hide help text

	static float jumpForce;
	static float speed;
	static float ariControl;
	static float fallingTime;
	static float starvingTime;

	void Start () {
		jumpForce = 25.0f;
		speed = 225.0f;
		ariControl = 15.0f;
		starvingTime = 1.0f;
		fallingTime = 3.0f;
	}

	void OnEnable (){
		if (Input.GetKey (KeyCode.W)) { key_W = true; }
	}



	// FixedUpdate is called when physics engine updates
	void FixedUpdate () {

        if( key_H ) {
            key_H = false;
            View.showHideHelp();
        }
		
		if (key_G) {
			key_G = false;
			cp.transform.position = transform.position;
		}

		if (key_K) { 
			key_K = false;
			PlayerDeathTransitionToCheckpoint ();
		}

		if (Physics2D.OverlapCircle (c_check.position, 0.09f, ground) || Physics2D.OverlapCircle (l_check.position, 0.09f, ground) || Physics2D.OverlapCircle (r_check.position, 0.09f, ground)) {
			starvingTime = 1.0f;
			fallingTime = 3.0f;
			if (key_W) {
				key_W = false;
				rb.AddForce (new Vector2 (0, jumpForce), ForceMode2D.Impulse);
			} else {
				rb.velocity = new Vector2 (speed * Input.GetAxis ("Horizontal")*Time.deltaTime, rb.velocity.y);
			}

		} else {
			if (!bc.IsTouchingLayers ()) {
				fallingTime -= Time.deltaTime;
				rb.AddForce (new Vector2 (Input.GetAxis ("Horizontal") * ariControl, 0));
			} else { starvingTime -= Time.deltaTime; }
			if (starvingTime <= 0 || fallingTime <= 0) { PlayerDeathTransitionToCheckpoint (); }
		}
	}

	// Update is called once per frame
	void Update () {
		if ( ( Physics2D.OverlapCircle (c_check.position, 0.09f, ground) || Physics2D.OverlapCircle (l_check.position, 0.09f, ground) || Physics2D.OverlapCircle (r_check.position, 0.09f, ground) ) && Input.GetKeyDown (KeyCode.W) ) { key_W = true; }
		if ( Physics2D.OverlapCircle (c_check.position, 0.09f, ground) && Physics2D.OverlapCircle (l_check.position, 0.09f, ground) && Physics2D.OverlapCircle (r_check.position, 0.09f, ground) && Input.GetKeyDown (KeyCode.G) ) { key_G = true; }
		if ( Input.GetKeyDown (KeyCode.K) ) { key_K = true; }
        if ( Input.GetKeyDown ( KeyCode.H ) ) { key_H = true; }
	}
		
	private void PlayerDeathTransitionToCheckpoint(){
		starvingTime = 1.0f;
		fallingTime = 3.0f;
		pl_reload.enabled = true;
		pl_mov.enabled = false;
	}
}