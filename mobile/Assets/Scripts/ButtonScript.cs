using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public Button b_duck, b_create, b_journal, b_map, b_return_b, b_audio_b, b_photo, b_video, b_smiley, b_undo, b_send, b_text;
    public GameObject duck, create, journal, map, return_b, text, audio_b, photo, video, smiley, undo, send, calm, warm, sad, textDate, textIcon, personal_panel, map_panel;
    public GameObject giField;
    public GameObject addedText, newTextPanel;
    //public test testObj;
    public InputField iField;
    bool smiley_toggle = true;
    bool journal_toggle = true;
    bool map_toggle = true;


    // Start is called before the first frame update
    void Start()
    {
        b_create.onClick.AddListener(createClick);
        b_text.onClick.AddListener(createTextClicked);
        b_return_b.onClick.AddListener(backClicked);
        b_send.onClick.AddListener(submitClicked);
        b_undo.onClick.AddListener(undoClicked);
        b_smiley.onClick.AddListener(smiley_clicked);
        b_journal.onClick.AddListener(journal_clicked);
        b_map.onClick.AddListener(map_clicked);
        giField.SetActive(false);
        newTextPanel.SetActive(false);
        addedText.SetActive(false);
        showMainMenu();
        hideCreateMenu();
        hideAudioCreate();
        hidePhotoCreate();
        hideTextCreate();
        hideVideoCreate();
        calm.SetActive(false);
        warm.SetActive(false);
        sad.SetActive(false);
        personal_panel.SetActive(false);
        map_panel.SetActive(false);
        duck.SetActive(true);
        textDate.SetActive(false);
        textIcon.SetActive(false);
    }

    void journal_clicked()
    {
        personal_panel.SetActive(journal_toggle);
        journal_toggle = !journal_toggle;
    }

    void map_clicked()
    {
        map_panel.SetActive(map_toggle);
        map_toggle = !map_toggle;
    }

    void smiley_clicked()
    {
        calm.SetActive(smiley_toggle);
        warm.SetActive(smiley_toggle);
        sad.SetActive(smiley_toggle);
        smiley_toggle = !smiley_toggle;
    }

    void hideMainMenu()
    {
        create.SetActive(false);
        journal.SetActive(false);
        map.SetActive(false);
    }

    void showMainMenu()
    {
        duck.SetActive(true);
        create.SetActive(true);
        journal.SetActive(true);
        map.SetActive(true);
    }

    void hideCreateMenu()
    {
        return_b.SetActive(false);
        text.SetActive(false);
        audio_b.SetActive(false);
        photo.SetActive(false);
        video.SetActive(false);
    }

    void showCreateMenu()
    {
        duck.SetActive(true);
        return_b.SetActive(true);
        text.SetActive(true);
        audio_b.SetActive(true);
        photo.SetActive(true);
        video.SetActive(true);
    }

    void showTextCreate()
    {
        duck.SetActive(true);
        return_b.SetActive(true);
        text.SetActive(true);
        smiley.SetActive(true);
        undo.SetActive(true);
        send.SetActive(true);

        giField.SetActive(true);

    }

    void createTextClicked()
    {
        showTextCreate();
        audio_b.SetActive(false);
        photo.SetActive(false);
        video.SetActive(false);
        giField.SetActive(true);
        //testObj.createTextClicked();
    }

    void hideTextCreate()
    {
        return_b.SetActive(false);
        text.SetActive(false);
        smiley.SetActive(false);
        undo.SetActive(false);
        send.SetActive(false);
    }

    void hideAudioCreate()
    {
        return_b.SetActive(false);
        audio_b.SetActive(false);
        smiley.SetActive(false);
        undo.SetActive(false);
        send.SetActive(false);
    }

    void showAudioCreate()
    {
        duck.SetActive(true);
        return_b.SetActive(true);
        audio_b.SetActive(true);
        smiley.SetActive(true);
        undo.SetActive(true);
        send.SetActive(true);
    }

    void showPhotoCreate()
    {
        duck.SetActive(true);
        return_b.SetActive(true);
        photo.SetActive(true);
        smiley.SetActive(true);
        undo.SetActive(true);
        send.SetActive(true);
    }

    void hidePhotoCreate()
    {
        duck.SetActive(true);
        return_b.SetActive(true);
        photo.SetActive(true);
        smiley.SetActive(true);
        undo.SetActive(true);
        send.SetActive(true);
    }

    void showVideoCreate()
    {
        duck.SetActive(true);
        return_b.SetActive(true);
        video.SetActive(true);
        smiley.SetActive(true);
        undo.SetActive(true);
        send.SetActive(true);
    }

    void hideVideoCreate()
    {
        return_b.SetActive(false);
        video.SetActive(false);
        smiley.SetActive(false);
        undo.SetActive(false);
        send.SetActive(false);
    }

    void backFromCreateSpecific()
    {
        showCreateMenu();
        hidePhotoCreate();
        hideTextCreate();
        hideVideoCreate();
        hideAudioCreate();
    }

    void backFromCreate()
    {
        showMainMenu();
        hideCreateMenu();
        smiley.SetActive(false);
        undo.SetActive(false);
        send.SetActive(false);
        giField.SetActive(false);
        calm.SetActive(false);
        warm.SetActive(false);
        sad.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void createClick()
    {
        Debug.Log("create Clicked");
        hideMainMenu();
        showCreateMenu();
    }

    public void backClicked()
    {
        Debug.Log("back clicked Clicked");
        backFromCreate();
    }

    void submitClicked()
    {
        Debug.Log("Trying to submit text");
        addedText.GetComponent<TextMesh>().text = iField.text.ToString();
        Debug.Log("1: " + iField.text.ToString());
        Debug.Log("2: " + iField.text.ToString());
        newTextPanel.SetActive(true);
        giField.SetActive(false);
        newTextPanel.SetActive(true);
        addedText.SetActive(true);
        textDate.SetActive(true);
        textIcon.SetActive(true);
        backClicked();
    }

    void undoClicked()
    {
        iField.text = "";
    }

}
