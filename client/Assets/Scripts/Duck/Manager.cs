using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Journal.Duck {
    public class Manager : MonoBehaviour {
        public GameObject baseCanvas, createCanvas, journalCanvas, emotionCanvas;
        public bool interactedWith = false;
        public Animator anim;
        public string emotion = "green";
        public AudioSource quackSource;

        public void BeginInteraction() {
            interactedWith = true;
            anim.StopPlayback();
            DisplayTooltip();
            quackSource.Play();
        }

        public void EndInteraction() {
            interactedWith = false;
            anim.Play("Duck");
            HideTooltip();
        }

        void Start() {
            HideTooltip();
        }

        void Update() {
            // anim.speed = depending on distance
        }

        public void DisplayTooltip() {
            baseCanvas.SetActive(true);
        }

        public void GetEmotions() {
           baseCanvas.SetActive(false);
           emotionCanvas.SetActive(true);
           foreach(Input.Feedback2D feedback in emotionCanvas.GetComponentsInChildren<Input.Feedback2D>()) {
                feedback.Defocus();
            }
        }

        public void GetCreate() {
           emotionCanvas.SetActive(false);
           createCanvas.SetActive(true);
           foreach(Input.Feedback2D feedback in createCanvas.GetComponentsInChildren<Input.Feedback2D>()) {
                feedback.Defocus();
            }
        }

        public void SetEmotion(string _emotion) {
            emotion = _emotion;
        }

        public void GetJournal() {
            baseCanvas.SetActive(false);
            journalCanvas.SetActive(true);
            foreach(Input.Feedback2D feedback in journalCanvas.GetComponentsInChildren<Input.Feedback2D>()) {
                feedback.Defocus();
            }
        }

        public void HideTooltip() {
            baseCanvas.SetActive(false);
            createCanvas.SetActive(false);
            journalCanvas.SetActive(false);
            emotionCanvas.SetActive(false);
        }

        private void ToggleColliders(GameObject parent, bool on) {
            foreach(BoxCollider box in parent.GetComponentsInChildren<BoxCollider>()) {
                box.enabled = on;
            }
        }
    }
}