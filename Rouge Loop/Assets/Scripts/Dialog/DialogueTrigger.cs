using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    private bool canTalk;
    private  Dialogues dialogues;
    public Canvas canTalkUI;
    private InputHandler inputHandler;
    private DialogueManager dialogueManager;
    private Collider collider;
    private Vector3 uiPosition;
    public Vector3 npcPos;

    void Awake ()
    {
        canTalkUI.enabled = false;
        
    }
    private void Start()
    {
        inputHandler = GetComponentInParent<InputHandler>();
        collider = GetComponentInParent<BoxCollider>();
        dialogueManager = FindObjectOfType<DialogueManager>();
        inputHandler.ButtonNordAction.started += context => StartDialog();


    }
    void StartDialog()
    {
        dialogueManager.npcPos = npcPos;
        if (dialogueManager.InDialog) {dialogueManager.DisplayNextSentence(); return; }

        if (canTalk)
        {
            Debug.Log("Main Progress: " + dialogues.getDialogueProgress("main"));
            Debug.Log(dialogues.dialogueArchive.Keys.ToString());
            Debug.Log("main" + dialogues.getDialogueProgress("main"));
            //Dialogue handling
            if (dialogues.canSepcialDialogue)
            {
                //if (dialogues.dialogueArchive["special" + dialogues.getDialogueProgress("special")]!= null) {
                dialogues.canSepcialDialogue = false;
                //sets Dialogue Progress + 1
                 
                //dialogueManager.StartDialogue(dialogues.dialogueArchive["special" + dialogues.getDialogueProgress("special")]);
                dialogueManager.StartDialogue(dialogues.dialogueArchive["special" + dialogues.getDialogueProgress("special")]);
                //dialogues.setDialogueProgress("special");
                //}
            } else if(!dialogues.alreadyTalked)
            {
                //if (dialogues.dialogueArchive["main" + dialogues.getDialogueProgress("main")] != null){
                    dialogues.alreadyTalked = true;
                    dialogueManager.StartDialogue(dialogues.dialogueArchive["main" + dialogues.getDialogueProgress("main")]);
                    //dialogues.setDialogueProgress("main");
                //}
            } else
            {
                dialogueManager.StartDialogue(dialogues.dialogueArchive["default" + dialogues.getDialogueProgress("default")]);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ChattyNPC"))
        {
            uiPosition = other.transform.position;
            uiPosition.y += 1f;
            dialogues = other.GetComponent<Dialogues>();
            canTalk = true;
            canTalkUI.transform.position = uiPosition;
            canTalkUI.enabled = true;
            Debug.Log("In Range of ");
            npcPos = other.transform.parent.position;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ChattyNPC"))
        {
            canTalk = false;
            canTalkUI.enabled = false;
        }
    }

    void UiPlacement(Collider other)
    {

    }
}
