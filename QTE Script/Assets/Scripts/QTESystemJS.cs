using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTESystemJS : MonoBehaviour
{
    public GameObject DisplayBox;
    public GameObject PassBox;
    public Text playerText;
    public int QTEGen;
    public int WaitingForKey;
    public int CorrectKey;
    public int CountingDown;
    public int pass = 0;

    public int passCount = 0;
    public int failCount = 0;

    public GameObject dialogueSystem;
    DialogueSystem DialogueSystem;

    public GameObject nextButton;

    private string badResponse1 = "Hey! I wasn't done with that water";
    private string badResponse2 = "Come back here";
    private string badResponse3 = "Hmm";
    private string goodResponse1 = "Excuse me, I was not done with that water";
    private string goodResponse2 = "Thank you so much for doing your job.";
    private string goodResponse3 = "Oh nice man! I went to school there too! We have a lot in common.";


    private void Awake()
    {
        dialogueSystem = GameObject.Find("DialogueSystem");
        DialogueSystem = dialogueSystem.GetComponent<DialogueSystem>();
        nextButton = GameObject.Find("Continue Dialogue");
    }

    private void Update()
    {
        if (WaitingForKey == 0)
        {
            // QTEGen = Random.Range(1, 4);
            //  CountingDown = 1;
            // StartCoroutine(CountDown());

            if (QTEGen == 1)
            {
                WaitingForKey = 1;
                DisplayBox.GetComponent<Text>().text = "[E]";
            }
            if (QTEGen == 2)
            {
                WaitingForKey = 1;
                DisplayBox.GetComponent<Text>().text = "[R]";
            }
            if (QTEGen == 3)
            {
                WaitingForKey = 1;
                DisplayBox.GetComponent<Text>().text = "[T]";
            }
        }

        if (QTEGen == 1)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetButtonDown("EKey"))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }

        if (QTEGen == 2)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetButtonDown("RKey"))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }

        if (QTEGen == 3)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetButtonDown("TKey"))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }

    }

    IEnumerator KeyPressing()
    {
        QTEGen = 4;
        if (CorrectKey == 1)
        {
            CountingDown = 2;
            PassBox.GetComponent<Text>().text = "Pass!";
            pass = 1;
            passCount += 1;
            DialogueSystem.TurnOnNextButton();
            if (DialogueSystem.interaction == 1)
            {
                playerText.text = goodResponse1;

            }
            else if (DialogueSystem.interaction == 2)
            {
                playerText.text = goodResponse2;
                //  nextButton.SetActive(true);

            }
            else if (DialogueSystem.interaction == 3)
            {
                playerText.text = goodResponse3;

            }
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<Text>().text = "";
            DisplayBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;

            //   CountingDown = 1;
        }

        if (CorrectKey == 2)
        {
            CountingDown = 2;
            PassBox.GetComponent<Text>().text = "FAIL!";
            DialogueSystem.TurnOnNextButton();
            pass = 2;
            failCount += 1;
            if (DialogueSystem.interaction == 1)
            {
                playerText.text = badResponse1;

            }
            else if (DialogueSystem.interaction == 2)
            {
                playerText.text = badResponse2;

            }

            else if (DialogueSystem.interaction == 3)
            {
                playerText.text = badResponse3;

            }

            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<Text>().text = "";
            DisplayBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;

            // CountingDown = 1;
        }
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(5f);
        if (CountingDown == 1)
        {
            QTEGen = 4;
            CountingDown = 2;
            PassBox.GetComponent<Text>().text = "FAIL!";
            DialogueSystem.TurnOnNextButton();
            pass = 2;
            failCount += 1;
            if (DialogueSystem.interaction == 1)
            {
                playerText.text = badResponse1;

            }
            else if (DialogueSystem.interaction == 2)
            {
                playerText.text = badResponse2;

            }

            else if (DialogueSystem.interaction == 3)
            {
                playerText.text = badResponse3;

            }
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<Text>().text = "";
            DisplayBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;
            // CountingDown = 1;
        }
    }

    public int numGen()
    {
        return QTEGen = Random.Range(1, 4);
    }

    public void startCountDown()
    {
        StartCoroutine(CountDown());
    }
}
