using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailureScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        gameObject.transform.Find("FailureText").gameObject.SetActive(false);
        gameObject.transform.Find("TryAgain").gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void Update()
    {
        if (FindObjectOfType<DialogueSystem>().victory == 2)
        {
            gameObject.transform.Find("FailureText").gameObject.SetActive(true);
            gameObject.transform.Find("TryAgain").gameObject.SetActive(true);
        }
    }

    public void Failsafe()
    {
        if (FindObjectOfType<DialogueSystem>().victory == 2)
        {
            gameObject.transform.Find("FailureText").gameObject.SetActive(true);
            gameObject.transform.Find("TryAgain").gameObject.SetActive(true);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
