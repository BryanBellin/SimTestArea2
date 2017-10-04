using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ClassDoorMatInteraction : MonoBehaviour {

    public Transform Player;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject Background;
    public Text ResultText;
    public GameObject ContinueReminder;
    //public Text txtref;
    public int MajorProficiencyIncreaseValue;

    private static int Prompt = 0;
    private static int Continue = 0;
    private static int score;
    private static int TestDay;

    void Start()
    {
        //txtref = GetComponent<Text>();
        ResultText.text = "";
        TestDay = 0;
        //txtref = GameObject.Find("Class Result Text").GetComponent<Text>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //print("Checking Class Availability");
            SendMessageUpwards("CheckClassFlag");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
            Prompt = 0;
        }
    }

    private void Update()
    {
        if(Prompt == 1)
        {
            if(Input.GetButtonDown ("Interact"))
            {
                
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                Background.SetActive(true);
                if(TestDay != 1)
                {
                    MajorProficiencyIncreaseValue = Mathf.RoundToInt(Random.Range(1, 5));
                    ResultText.text = "You attend class for an hour.\nYour Major Proficiency increases by " + MajorProficiencyIncreaseValue + ".";
                }
                else
                {
                    ResultText.text = "You take a test and score " + score + "%";
                    TestDay = 0;
                }

                //ResultText.SetActive(true);
                ContinueReminder.SetActive(true);
            }
            if (Input.GetButtonUp ("Interact"))
            {
                print("Attending Class");
                SendMessageUpwards("UpdateMajorProficiency", MajorProficiencyIncreaseValue);
                //UpdateMajorProficiency();
                Continue = 1;
            }
            if(Continue == 1)
            {
                if (Input.anyKeyDown)
                {
                    
                    Background.SetActive(false);
                    ResultText.text = "";
                    //ResultText.SetActive(false);
                    ContinueReminder.SetActive(false);

                    Player.position = new Vector3(0, 0, 0);
                    Continue = 0;
                    Prompt = 0;
                    SendMessageUpwards("ReportAttendedClass");
                }
            }
            
        }
    }

    void PromptClassInteract()
    {
        ActionDisplay.SetActive(true);
        ActionText.SetActive(true);
        Prompt = 1;
    }

    void ChangeUIforTest(int value)
    {
        TestDay = 1;
        ActionDisplay.SetActive(true);
        ActionText.SetActive(true);
        Prompt = 1;
        score = value * 100 / 10;
        
        //ResultText. = "You take a test and score " + score + "%";
    }

}
