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
        textArray.Add("Welcome traveler! It's a pleasure to see you in these mysterious lands.");
        textArray.Add("Long ago, these lands were peaceful and serene. But a shadowy force began to take over the planets.");
        textArray.Add("The master of darkness created powerful bosses on each planet, spreading terror.");
        textArray.Add("Our duty is to defeat these bosses, activate the portals, and restore light.");
        textArray.Add("Each planet has its own unique challenges and secrets. Are you ready to explore?");
        textArray.Add("This will be a difficult quest, but I know you have the spirit of a hero within you.");
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
