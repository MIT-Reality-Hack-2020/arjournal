using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Videoplayer : MonoBehaviour
{
    public GameObject videoplayer, play;
    bool video_toggle;
    // Start is called before the first frame update
    void Start()
    {
        play.SetActive(true);
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);
        video_toggle = true;

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
                if (hit.collider.tag == "video-player")
                {
                    Debug.Log("Mouse clicked play");
                    if (video_toggle)
                    {
                        videoplayer.GetComponent<VideoPlayer>().Play();
                    }
                    else
                    {
                        videoplayer.GetComponent<VideoPlayer>().Pause();
                    }
                    video_toggle = !video_toggle;
                }
            }
        }
    }
}
