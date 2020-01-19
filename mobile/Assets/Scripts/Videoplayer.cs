using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Videoplayer : MonoBehaviour
{
    public GameObject videoplayer, play, pause;

    // Start is called before the first frame update
    void Start()
    {
        play.SetActive(true);
        pause.SetActive(false);
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Enable rendering:
        foreach (var component in rendererComponents)
            component.enabled = true;

        // Enable colliders:
        foreach (var component in colliderComponents)
            component.enabled = true;

        // Enable canvas':
        foreach (var component in canvasComponents)
            component.enabled = true;
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
                if (hit.collider.tag == "play")
                {
                    Debug.Log("Mouse clicked play");
                    videoplayer.GetComponent<VideoPlayer>().Play();
                    play.SetActive(false);
                    pause.SetActive(true);
                }

                //case 2
                if (hit.collider.tag == "pause")
                {
                    Debug.Log("Mouse clicked pause");
                    videoplayer.GetComponent<VideoPlayer>().Pause();
                    pause.SetActive(false);
                    play.SetActive(true);
                }
            }
        }
    }
}
