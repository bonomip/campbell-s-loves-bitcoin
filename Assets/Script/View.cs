using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour {

	static private Text death_text;
	static private Text central_text;
    static private Text help_text;
    static private Text help_info;

	void Start () {
		death_text = GameObject.Find ("n_Death").GetComponent<Text> ();
		central_text = GameObject.Find("central_text").GetComponent<Text> ();
        help_text = GameObject.Find("help").GetComponent<Text>();
        help_text.text = "";

		if (GameManager.deaths > 0) { death_text.text = "Deaths: " + GameManager.deaths; }

        if (ControlManager.scene == 0)
        {
            help_info = GameObject.Find("help_info").GetComponent<Text>();
            help_info.text = "Press H for Help";
            StartCoroutine(hideText(help_info, 5f));
        }
	}

	static public void updateDeathText(){
		death_text.text = "Deaths: " + GameManager.deaths;
	}

	static public void changeCentralText(string s){
		central_text.text = s;
        help_text.text = "";
        help_info.text = "";
	}

    IEnumerator hideText(Text text, float time){
        yield return new WaitForSeconds(time);
        text.text = "";
    }

    static public void showHideHelp(){
        help_text.text = help_text.text == "" ? "WASD = Move Campbell's Can\nG = Update CheckPoint\nK = Restore to last CheckPoint\nH = Hide this message" : "";
        help_info.text = "";
    }
}
