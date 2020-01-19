using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Journal.Create {
    public class Voice : MonoBehaviour
    {
        public GameObject progressbarBack, progressbar, recordingIndicator;
        private float timer, timeTillFinish = 5.0f;
        private AudioClip clip;
        public GameObject bubble;
        private bool recording = false;
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if(recording) {
                timer += Time.deltaTime;
                Vector3 barScale = progressbar.transform.localScale;
                barScale.x = ((timeTillFinish - timer) / timeTillFinish) * progressbarBack.transform.localScale.x;
                Vector3 barPos = progressbar.transform.localPosition;
                progressbar.transform.localScale = barScale;

                if(timer > timeTillFinish) {
                    FinishRecording();
                }
            }
        }

        public void StartRecording() {
            clip = Microphone.Start(null, true, (int)timeTillFinish, 44100);
            progressbarBack.SetActive(true);
            progressbar.SetActive(true);
            recordingIndicator.SetActive(true);
            timer = 0;
            recording = true;
        }

        public void FinishRecording() {
            recording = false;
            GameObject newBubble = Instantiate(bubble);
            newBubble.GetComponentInChildren<Bubble.Manager>().type = Bubble.Manager.bubbleType.voice;
            newBubble.SetActive(true);
            newBubble.transform.position = progressbarBack.transform.position;
            progressbarBack.SetActive(false);
            progressbar.SetActive(false);
            recordingIndicator.SetActive(false);
            newBubble.GetComponentInChildren<Bubble.VoiceView>().SetClip(clip);
            newBubble.GetComponentInChildren<Bubble.VoiceView>().Play();
        }
    }
}