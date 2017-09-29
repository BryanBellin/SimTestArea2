using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassDoorMatInteraction : MonoBehaviour {

    public GameObject ActionDisplay;
    public GameObject ActionText;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
        }
    }
}
