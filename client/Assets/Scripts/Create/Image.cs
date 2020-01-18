using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Journal.Create {
    public class Image : MonoBehaviour
    {

        public GameObject cameraFrame, progressbarBack, progressbar;
        private float timer, timeTillShot = 5.0f;
        private bool shooting = false;

        public GameObject bubble;

        void Start()
        {
        }

        void Update()
        {
            if(shooting) {
                timer += Time.deltaTime;
                Vector3 barScale = progressbar.transform.localScale;
                barScale.x = ((timeTillShot - timer) / timeTillShot) * progressbarBack.transform.localScale.x;
                Vector3 barPos = progressbar.transform.localPosition;
                progressbar.transform.localScale = barScale;

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
            cameraFrame.SetActive(false);
            progressbarBack.SetActive(false);
            progressbar.SetActive(false);

            GameObject newBubble = Instantiate(bubble);
            newBubble.SetActive(true);
            newBubble.transform.position = cameraFrame.transform.position;
            newBubble.GetComponentInChildren<NRKernal.NRExamples.PhotoCapture>().TakeAPhoto();

        }
    }
}