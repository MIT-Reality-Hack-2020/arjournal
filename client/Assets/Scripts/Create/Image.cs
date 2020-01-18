using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Journal.Create {
    public class Image : MonoBehaviour
    {

        public GameObject cameraFrame, progressbarBack, progressbar;
        private float timer, timeTillShot = 5.0f;
        private bool shooting = false;
        private GameObject lastBubble;
        public GameObject bubble;
        private Global global;

        void Start()
        {
            global = FindObjectOfType<Global>();
        }

        void Update()
        {
            if(shooting) {
                timer += Time.deltaTime;
                Vector3 barScale = progressbar.transform.localScale;
                barScale.x = ((timeTillShot - timer) / timeTillShot) * progressbarBack.transform.localScale.x;
                Vector3 barPos = progressbar.transform.localPosition;
                progressbar.transform.localScale = barScale;

                if(timer > timeTillShot - 0.3f) {
                    cameraFrame.SetActive(false);
                    progressbarBack.SetActive(false);
                    progressbar.SetActive(false);
                    global.duckMesh.enabled = false;
                }
                if(timer > timeTillShot) {
                    ShootPicture();
                }
            }
        }
        public void StartImageCountdown() {
            cameraFrame.SetActive(true);
            progressbarBack.SetActive(true);
            progressbar.SetActive(true);
            timer = 0;
            shooting = true;
        }

        public void ShootPicture() {
            shooting = false;

            GameObject newBubble = Instantiate(bubble);
            lastBubble = newBubble;
            newBubble.transform.position = cameraFrame.transform.position;
            GetComponentInChildren<NRKernal.NRExamples.PhotoCaptureExample>().TakeAPhoto();
            newBubble.SetActive(true);
            global.duckMesh.enabled = true;
        }

        public void SetPhotoTransform() {
            GetComponentInChildren<NRKernal.NRExamples.PhotoCaptureExample>().newQuad.transform.SetParent(lastBubble.transform.GetComponentInChildren<Bubble.ImageView>().gameObject.transform);
            GetComponentInChildren<NRKernal.NRExamples.PhotoCaptureExample>().newQuad.transform.localPosition = new Vector3(0, 2.0f, 0.1f);
            GetComponentInChildren<NRKernal.NRExamples.PhotoCaptureExample>().newQuad.transform.rotation = Quaternion.Euler(0, 180.0f, 0);
            GetComponentInChildren<NRKernal.NRExamples.PhotoCaptureExample>().newQuad.transform.localScale = new Vector3(8.667639f, 4.875546f, 0f);
        }
    }
}