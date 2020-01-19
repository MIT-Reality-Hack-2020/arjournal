using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class transcript : MonoBehaviour
{
    public GameObject transcriptPanel, typingText, b_showTranscript, b_close;
    public Button showTranscript, close;
    string story;

    void Start()
    {
        story = "I really love how quiet it is here. I feel like I can think.I should go for my walks this winter.";
        print("here");
        typingText.GetComponent<TextMesh>().text = "";
        showTranscript.onClick.AddListener(onClickShowTranscript);
        close.onClick.AddListener(onClickClose);
        b_showTranscript.SetActive(true);
        b_close.SetActive(false);
        transcriptPanel.SetActive(false);
        typingText.SetActive(false);
    }

    void onClickShowTranscript()
    {
        typingText.GetComponent<TextMesh>().text = "";
        Debug.Log("Trying to show transcript");
        b_close.SetActive(true);
        b_showTranscript.SetActive(false);
        transcriptPanel.SetActive(true);
        typingText.SetActive(true);
        StartCoroutine("PlayText");
    }

    void onClickClose()
    {
        Debug.Log("Closing transcript");
        b_showTranscript.SetActive(true);
        b_close.SetActive(false);
        transcriptPanel.SetActive(false);
        typingText.SetActive(false);
    }

    IEnumerator PlayText()
    {
        int i = 0;
        foreach (char c in story)
        {
            if (i > 30)
            {
                typingText.GetComponent<TextMesh>().text += "\n";
                i = 0;
            }
            typingText.GetComponent<TextMesh>().text += c;
            yield return new WaitForSeconds(0.125f);
            i = i + 1;
        }
    }

}
