using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogues : MonoBehaviour
{

    public List<Dialogue> dialogues = new List<Dialogue>();
    public IDictionary<string, Dialogue> dialogueArchive = new Dictionary<string, Dialogue>();


    private int mainDialogueProgress = 0;
    private int defaultDialogueProgress = 0;
    private int specialDialogueProgress = 0;

    public bool canSepcialDialogue;
    public bool alreadyTalked;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Dialogue dialogue in dialogues)
        {
            dialogueArchive.Add(dialogue.dialogueName, dialogue);
        }

        canSepcialDialogue = (getDialogueTypeCount("special") - 1 > specialDialogueProgress) ? false :  true;

        alreadyTalked = (getDialogueTypeCount("main") - 1 > mainDialogueProgress) ? false : true;
        // mit gameobject.Name 
    }

    public int getDialogueProgress(string dialogueType)
    {
        switch (dialogueType)
        {
            case "main": return mainDialogueProgress;

            case "default":
                return defaultDialogueProgress;

            case "special":
                return specialDialogueProgress;

            default: return -1;
        }
    }

    public void setDialogueProgress(string dialogueType)
    {
        switch (dialogueType)
        {
            case "main":
                mainDialogueProgress=+1;
                break;

            case "default":
                defaultDialogueProgress+=1;
                break;

            case "special":
                specialDialogueProgress+=1;
                break;
        }
    }

    public int getDialogueTypeCount(string dialogueType)
    {
        int dtCount = 0;
        foreach(Dialogue dialogue in dialogues)
        {
            if (dialogue.dialogueName.Contains(dialogueType))
            {
                dtCount += 1;
            }
        }

        return dtCount;
    }
}
