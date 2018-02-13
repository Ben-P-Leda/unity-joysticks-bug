using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StickCountReporter : MonoBehaviour {

    private Text _text;

	// Use this for initialization
	void Start () {
        _text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        string[] sticks = Input.GetJoystickNames();
        string text = "Stick name count: " + sticks.Length;
        
        if (sticks.Length > 0)
        {
            foreach (string s in sticks)
            {
                text += " :: " + (string.IsNullOrEmpty(s) ? "--UNKNOWN--" : s);
            }
        }

        _text.text = text;
	}
}
