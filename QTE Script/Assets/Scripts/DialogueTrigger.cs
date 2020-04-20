using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueSystem>().StartDialogue(dialogue);
       

        FindObjectOfType<QTESystem>().numGen();
        FindObjectOfType<QTESystem>().CountingDown = 1;
        FindObjectOfType<QTESystem>().startCountDown();

    }


 
}
