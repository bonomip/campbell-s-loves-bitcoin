using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlManager : MonoBehaviour {

	static private int sceneAt = 0;
	static private MainCamera cam;
	static private bool sceneIsLoading;

	void Start (){
		cam = GameObject.Find("Main Camera").GetComponent<MainCamera> ();
	}

	public void loadScene(){
		sceneIsLoading = true;
		StartCoroutine (disablePlayerMovementAndGoFarWithCamera ());
		StartCoroutine (waitAndThenShowText ());
		StartCoroutine (waitAndLoadNextScene ());
	}

	private IEnumerator disablePlayerMovementAndGoFarWithCamera(){
		Player.pl_mov.enabled = false;
		while (sceneIsLoading) {
			cam.goFar (0.1f);
			yield return new WaitForEndOfFrame();
		}
	}

	private IEnumerator waitAndThenShowText(){
		yield return new WaitForSeconds (.5f);
		View.changeCentralText ( randomChangeSceneText() );
	}

	private IEnumerator waitAndLoadNextScene (){
		yield return new WaitForSeconds (2.0f);
		sceneIsLoading = false;
        SceneManager.LoadScene ( (++sceneAt).ToString() );
	}
		
	private string randomChangeSceneText(){
		return "YOU DID IT!";
	}

    static public int scene {
        get { return sceneAt; }
    }

}
