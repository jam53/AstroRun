using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public bool RunOnlyOnce;

    public bool RunWhenActivedInHierachy;

    public string keyName;



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
                if (!(bool)typeof(AstroRunData).GetField(keyName).GetValue(SaveLoadManager.slm.astroRunData))
                {
                    DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();

                    dialogueManager.StartDialogue(dialogue);

                    save();
                }

                else if ((bool)typeof(AstroRunData).GetField(keyName).GetValue(SaveLoadManager.slm.astroRunData))
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
            if (!(bool)typeof(AstroRunData).GetField(keyName).GetValue(SaveLoadManager.slm.astroRunData))
            {
                DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();

                dialogueManager.StartDialogue(dialogue);

                save();
            }

            else if ((bool)typeof(AstroRunData).GetField(keyName).GetValue(SaveLoadManager.slm.astroRunData))
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

    private void save()
    {
        switch (keyName)
        {//Load the best time for this level
            case "dialogueBoxCoinsResetTimer":
                SaveLoadManager.slm.astroRunData.dialogueBoxCoinsResetTimer = true;
                break;

            case "dialogueBuyingNewLevels":
                SaveLoadManager.slm.astroRunData.dialogueBuyingNewLevels = true;
                break;

            default:
                Debug.LogWarning("Couldn't save that the dialogue box has been showed: " + keyName);
                break;
        }

        SaveLoadManager.slm.SaveJSONToDisk();
    }
}
