using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Canvas dialogueUI;
    private bool inDialog;

    private Queue<string> sentence;
    private Queue<string> dialogueNames;
    private float dist;

    public Vector3 npcPos;
    void Start()
    {
        sentence = new Queue<string>();
        dialogueNames = new Queue<string>();
        dialogueUI.enabled = false;

    }

    private void Update()
    {

        if (inDialog)
        {
            //get distance of npc and player
            Vector3 playerPos = GameObject.Find("Barbarian").transform.position;
            
            Debug.Log(this.transform.parent.name);
            dist = Vector3.Distance(npcPos, playerPos);
            Debug.Log(dist);
            if (dist > 5.0f)
            {
                EndDialogue();
            }
        }
    }

    public void StartDialogue (Dialogue dialogue)
    {
        Debug.Log("Starting conversation with E");
        inDialog = true;

        foreach (Sentences sentences in dialogue.dialogue)
        {

            foreach (string s in sentences.sentences)
            {
                dialogueNames.Enqueue(sentences.name);
                sentence.Enqueue(s);
            }
        
        }

        dialogueUI.enabled = true;
        DisplayNextSentence();
    }
    public void DisplayNextSentence ()
    {
        if (sentence.Count == 0) { EndDialogue(); return; }
        
        string sentenc = sentence.Dequeue();
        string dialogueName = dialogueNames.Dequeue();
        Debug.Log(sentenc);
        nameText.text = dialogueName;
        dialogueText.text = sentenc;
    }
    void EndDialogue()
    {
        sentence.Clear();
        Debug.Log("End of converstaion");
        dialogueUI.enabled = false;
        inDialog = false;
    }
    public bool InDialog=>inDialog;
}
