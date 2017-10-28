using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	static private GameManager instance;
	static private ControlManager control;
	static private int number_of_bitCoin;
	static private int number_of_deaths;

	void Awake (){
		control = GameObject.Find("GameManager").GetComponent<ControlManager> ();
		if (instance == null) {
			DontDestroyOnLoad (transform.gameObject);
			instance = this;
		} else if (this != instance) {
			Destroy (this.gameObject);
		}
	}

	static public void nextScene (){
		control.loadScene ();
	}
		
	static public void addBitCoin (){
		number_of_bitCoin++;
	}

	static public void addDeath (){
		number_of_deaths++;
		View.updateDeathText();
	}

	static public int deaths {
		get { return number_of_deaths; }
	}

}
