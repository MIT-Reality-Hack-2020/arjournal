using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour
{

    public GameObject giField;
    public InputField iField;
    public GameObject add, submit, addedText, newTextPanel, textDate, textIcon;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hiding textiNPUT");
        giField.SetActive(false);
        submit.SetActive(false);
        newTextPanel.SetActive(false);
        textDate.SetActive(false);
        textIcon.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.allCameras[0].ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Mouse clicked");
                //case 1
                if (hit.collider.tag == "add")
                {
                    Debug.Log("Trying to add text");
                    giField.SetActive(true);
                    submit.SetActive(true);
                    add.SetActive(false);
                }

                //case 2
                if (hit.collider.tag == "submit")
                {
                    Debug.Log("Submitting text");
                    giField.SetActive(false);
                    submit.SetActive(false);
                    add.SetActive(true);
                    Debug.Log("Trying to add text");
                    addedText.GetComponent<TextMesh>().text = iField.text.ToString();
                    Debug.Log("Set Text");
                    giField.SetActive(false);
                    newTextPanel.SetActive(true);
                    textDate.SetActive(true);
                    textIcon.SetActive(true);
                }
            }
        }
    }
}
