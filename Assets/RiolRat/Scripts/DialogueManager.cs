using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Localization.Settings;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI dialogueText;

    public Animator animator;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);

        dialogue = LocalizeDialogue(dialogue);

        titleText.text = dialogue.title;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.01f);
            //yield return null;
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("isOpen", false);
    }

    private Dialogue LocalizeDialogue(Dialogue dialogue)
    {
        dialogue.title = LocalizeString(dialogue.title);

        for (int i = 0; i < dialogue.sentences.Length; i++)
        {
            dialogue.sentences[i] = LocalizeString(dialogue.sentences[i]);
        }

        return dialogue;
    }

    private string LocalizeString(string key)
    {//https://forum.unity.com/threads/localizating-strings-on-script.847000/

        if (key[0] != '#')
        {//We only want to translate certain strings, strings that don't start with a '#', don't need to be translated
            return key;
        }

        var op = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("UI Text", key);
        if (op.IsDone)
            return op.Result;
        else
            op.Completed += (op) => Debug.LogWarning(op.Result);
        return "Couldn't get translation for key: " + key;
    }
}
