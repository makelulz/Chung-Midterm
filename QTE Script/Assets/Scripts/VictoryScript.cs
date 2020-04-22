using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VictoryScript : MonoBehaviour
{
    // Start is called before the first frame update

    AudioSource Audio;
    void Awake()
    {
        gameObject.transform.Find("VictoryText").gameObject.SetActive(false);
        gameObject.transform.Find("NextLevel").gameObject.SetActive(false);
    }

    // Update is called once per frame

    public void Update()
    {

        if (FindObjectOfType<DialogueSystem>().victory == 1)
        {
            gameObject.transform.Find("VictoryText").gameObject.SetActive(true);
            gameObject.transform.Find("NextLevel").gameObject.SetActive(true);

            Audio = GetComponent<AudioSource>();
            Audio.Play(0);

        }
        
    }
}
