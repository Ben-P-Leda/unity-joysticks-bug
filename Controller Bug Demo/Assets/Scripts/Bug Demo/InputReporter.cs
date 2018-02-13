using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputReporter : MonoBehaviour
{

    public GameObject[] DisplayTexts;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < DisplayTexts.Length; i++)
        {
            float axisValue = Input.GetAxis("Joystick " + (i + 1) + " Horizontal");
            DisplayTexts[i].GetComponent<Text>().text = "Joystick " + (i + 1) + " value: " + axisValue;
        }
    }
}
