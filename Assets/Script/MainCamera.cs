using System.Collections;
using UnityEngine;

public class MainCamera : MonoBehaviour {
	
	static private Camera mainCam; // the camera attacched on this gameObject ( the main camera of unity )
	Vector3 velocity = Vector3.zero; // the initial velocity of the camera when it have to follow the player
	static private float dampTime = 0.0f; // the time that will pass untill the camera will reach the player

	// Use this for initialization
	void Start () {
		mainCam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if (!Player.self) {
			
		} else {
			Vector3 point = mainCam.WorldToViewportPoint (Player.self.transform.position);
			Vector3 delta = Player.self.transform.position - mainCam.ViewportToWorldPoint (new Vector3 (0.5f , 0.40f, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp (transform.position, destination, ref velocity, dampTime);
		}
	}

	public void goFar(float increment){
			mainCam.orthographicSize += increment;
		}

	static public float damp_time {
		get { return dampTime; }
		set { dampTime = value; }
	}

	static public bool onPosition {
		get { 
			bool y = (mainCam.transform.position.y - 1.0f) > (Player.self.transform.position.y - 0.01f) && (mainCam.transform.position.y - 1.0f) < (Player.self.transform.position.y + 0.01f);
			bool x = (mainCam.transform.position.x) > (Player.self.transform.position.x - 0.01f) && (mainCam.transform.position.x) < (Player.self.transform.position.x + 0.01f);
			return y && x;
		}
	}

}
