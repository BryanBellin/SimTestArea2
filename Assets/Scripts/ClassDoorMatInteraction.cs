using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClassDoorMatInteraction : MonoBehaviour {

    public Transform Player;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject Background;
    public GameObject ResultText;
    public GameObject ContinueReminder;
    public int MajorProficiencyIncreaseValue;

    private static int Prompt = 0;
    private static int Continue = 0;

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
                ResultText.SetActive(true);
                ContinueReminder.SetActive(true);
            }
            if (Input.GetButtonUp ("Interact"))
            {
                print("Attending Class");
                MajorProficiencyIncreaseValue = Mathf.RoundToInt(Random.Range(1, 5));
                SendMessageUpwards("UpdateMajorProficiency", MajorProficiencyIncreaseValue);
                //UpdateMajorProficiency();
                Continue = 1;
            }
            if(Continue == 1)
            {
                if (Input.anyKeyDown)
                {
                    Background.SetActive(false);
                    ResultText.SetActive(false);
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

}
