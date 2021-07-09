using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public bool RunOnlyOnce;

    public bool RunWhenActivedInHierachy;

    public int SavingID;



    public Dialogue dialogue;

    public void Start()
    {
        if (RunWhenActivedInHierachy)
        {
            if (!RunOnlyOnce)
            {
                DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();

                dialogueManager.StartDialogue(dialogue);
            }

            else if (RunOnlyOnce)//Show the dialogue window only one time, then never show it again to the user
            {
                if (!GPGSAutenthicator.GPGSZelf.LoadBool(SavingID))
                {
                    DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();

                    dialogueManager.StartDialogue(dialogue);

                    GPGSAutenthicator.GPGSZelf.Save(SavingID, true);
                }

                else if (GPGSAutenthicator.GPGSZelf.LoadBool(SavingID))
                {
                    return;
                }
            }
        }
    }

    public void TriggerDialogueCheckIfRanBefore()//Only open the dialogue when calling his function if
        //                                         It hasn't been opened before
    {
        if (!RunOnlyOnce)
        {
            DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();

            dialogueManager.StartDialogue(dialogue);
        }

        else if (RunOnlyOnce)//Show the dialogue window only one time, then never show it again to the user
        {
            if (!GPGSAutenthicator.GPGSZelf.LoadBool(SavingID))
            {
                DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();

                dialogueManager.StartDialogue(dialogue);

                GPGSAutenthicator.GPGSZelf.Save(SavingID, true);
            }

            else if (GPGSAutenthicator.GPGSZelf.LoadBool(SavingID))
            {
                return;
            }
        }
    }

    public void TriggerDialogue()//Open The dialogue when calling this function
    {
        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();

        dialogueManager.StartDialogue(dialogue);
    }
}
