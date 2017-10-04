using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour {

    public Text GameTime;
    public Text MajorProficiencyText;
    public int MajorProficiencyValue;

    public int AttendedClass;
    public int Day;

    // Use this for initialization
    void Start () {
        AttendedClass = 0;
        Day = 1;
        print("Today is Day " + Day);
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

    void CheckClassFlag()
    {
        if (AttendedClass == 0)
        {
            print("Class Available");
            BroadcastMessage("PromptClassInteract");
        }
        else
        {
            print("Class Unavailable");
        }
    }

    void ReportAttendedClass()
    {
        print("Attended Class");
        AttendedClass = 1;
    }

    void UpdateTime()
    {
        Day = Day + 1;
        print("Today is now Day " + Day);
        GameTime.text = "Day: " + Day;
        AttendedClass = 0;
    }
}
