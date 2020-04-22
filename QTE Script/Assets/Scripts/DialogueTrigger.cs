using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    public Dialogue dialogue;
    public GameObject dialogueSystem;
    DialogueSystem DialogueSystem;
    

    private void Awake()
    {
        dialogueSystem = GameObject.Find("DialogueSystem");
        DialogueSystem = dialogueSystem.GetComponent<DialogueSystem>();

        
    }

    public void TriggerDialogue()
    {
        // FindObjectOfType<DialogueSystem>().StartDialogue(dialogue);
        DialogueSystem.StartDialogue(dialogue);

        FindObjectOfType<QTESystem>().numGen();
        FindObjectOfType<QTESystem>().CountingDown = 1;
        FindObjectOfType<QTESystem>().startCountDown();

    }

    public void TriggerNextInteraction()
    {
        DialogueSystem.interaction += 1;

        if (DialogueSystem.interaction >= 4)
        {
            gameObject.SetActive(false);
           // FindObjectOfType<FailureScript>().Failsafe();
            
        }

        else if (DialogueSystem.interaction < 4)
        {
            FindObjectOfType<QTESystem>().WaitingForKey = 0;
            FindObjectOfType<QTESystem>().pass = 0;
            DialogueSystem.DisplayNextSentence();

            gameObject.SetActive(false);
            FindObjectOfType<QTESystem>().PassBox.GetComponent<Text>().text = "";
            FindObjectOfType<QTESystem>().DisplayBox.GetComponent<Text>().text = "";

            FindObjectOfType<QTESystem>().numGen();
            FindObjectOfType<QTESystem>().CountingDown = 1;
            FindObjectOfType<QTESystem>().startCountDown();
        }
    }

 
}
