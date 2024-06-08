using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPC : MonoBehaviour
{
    bool playerDetected = false;
    public TextMeshProUGUI text;
    List<string> textArray = new List<string>();
    public GameObject dialogueUi;
    int i = 0;

    private void Start()
    {
        textArray.Add("Hello traveler!");
        textArray.Add("You are in a loop.");
        textArray.Add("You have to destroy boss to exit loop!");
        //Add dialogues here
    }

    // Update is called once per frame
    void Update()
    {
        
        if(playerDetected && Input.GetKeyDown(KeyCode.E))
        {
            dialogueUi.SetActive(true);
            if (i < textArray.Count)
            {
                text.text = textArray[i];
            }
            else
            {
                playerDetected = false;
                dialogueUi.SetActive(false);
            }

            i++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerDetected = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerDetected = false;
        dialogueUi.SetActive(false);
    }
}
