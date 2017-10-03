using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour {

    public Text MajorProficiencyText;
    public int MajorProficiencyValue;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void UpdateMajorProficiency(int value)
    {
        MajorProficiencyValue = MajorProficiencyValue + value;
        MajorProficiencyText.text = "Major Proficiency: " + MajorProficiencyValue.ToString() + "/12320";
    }

    void RequestTakeTest()
    {
        print("Taking Test -IRIS");
        BroadcastMessage("TakeTest", MajorProficiencyValue);
    }
}
