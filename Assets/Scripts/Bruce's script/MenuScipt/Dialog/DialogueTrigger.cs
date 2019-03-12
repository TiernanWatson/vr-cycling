using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;
    public Dialogue invalidInputErrorMessage;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void TriggerErrorMessage()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(invalidInputErrorMessage);
    }

}
