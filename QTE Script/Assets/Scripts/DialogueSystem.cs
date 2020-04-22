using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    
    // public Text nameText;
    public Text dialogueText;
    public GameObject qTEController;
    QTESystem qTESystem;
    private Queue<string> sentences;

    public GameObject startButton;
    public GameObject nextButton;
    public GameObject nextPlayerButton;

    public int interaction = 1;

    private string greeting = "Hey there bud! Where ya headed?";
    private string driverResponse1 = "So what do you do for work bud?";
    private string driverResponse2 = "Oh that's interesting. I'm currently going to school for that.";
    private string driverResponse3 = "Yeah, I go to the New York City College of Technology.";

    private string goodEnding = "You know what? I liked talking to you. The ride is free man.";
    private string badEnding = "Anyways, we're here. That'll be $38.47.";

    public int victory = 0;



    private void Awake()
    {
        qTEController = GameObject.Find("QTEController");
        qTESystem = qTEController.GetComponent<QTESystem>();
        nextButton = GameObject.Find("Continue Dialogue");
        startButton = GameObject.Find("Start Dialogue");
        nextPlayerButton = GameObject.Find("Continue Player Dialogue");
        nextButton.SetActive(false);
        nextPlayerButton.SetActive(false);
        interaction = 1;
        qTESystem.pass = 0;



    }

    void Start()
    {
        sentences = new Queue<string>();

    }

    public void StartDialogue (Dialogue dialogue)
    {
      //  Debug.Log ("Starting conversation with " + dialogue.name);

       // nameText.text = dialogue.name;

        sentences.Clear();
        nextButton.SetActive(true);
        startButton.SetActive(false);
        

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);

        }

        dialogueText.text = greeting;

    }

    public void DisplayNextSentence()
    {
        /*if (sentences.Count == 0)
          {
              EndDialogue();
              return;
          }*/

        nextPlayerButton.SetActive(true);
        nextButton.SetActive(false);

        if (interaction == 1)
        {


            if (qTESystem.pass == 0)
            {
                string sentence = sentences.Dequeue();

            }

            else if (qTESystem.pass == 1)
            {
                string sentence = sentences.Dequeue();
                sentence = sentences.Dequeue();
                dialogueText.text = sentence;
                qTESystem.CorrectKey = 5;
                return;
            }

            else if (qTESystem.pass == 2)
            {
                string sentence = sentences.Dequeue();
                sentence = sentences.Dequeue();
                dialogueText.text = sentence;
                qTESystem.CorrectKey = 5;
                return;
            }

            //   interaction = 2;
        }

        else if (interaction == 2)
        {
            if (qTESystem.pass == 0)
            {
                dialogueText.text = driverResponse1;
            }

            else if (qTESystem.pass == 1)
            {
                dialogueText.text = driverResponse2;
            }

            else if (qTESystem.pass == 2)
            {
                dialogueText.text = driverResponse2;
            }
        }
        else if (interaction == 3)
        {
            if (qTESystem.pass == 0)
            {
                dialogueText.text = driverResponse3;
            }

            else if (qTESystem.pass == 1)
            {
                if(qTESystem.passCount> qTESystem.failCount)
                {
                    dialogueText.text = goodEnding;
                    victory = 1;
                }
                
                else if (qTESystem.passCount<= qTESystem.failCount)
                {
                    victory = 2;
                    dialogueText.text = badEnding;
                }

            }

            else if (qTESystem.pass == 2)
            {
                if (qTESystem.passCount > qTESystem.failCount)
                {
                    dialogueText.text = goodEnding;
                    victory = 1;
                }

                else if (qTESystem.passCount <= qTESystem.failCount)
                {
                    victory = 2;
                    dialogueText.text = badEnding;
                }

            }

        }



        // string sentence = sentences.Dequeue();
        //dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        Debug.Log("End of conversation");

    }

    public void TurnOnNextButton()
    {
        nextButton.SetActive(true);
    }
}
