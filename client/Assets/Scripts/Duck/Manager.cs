using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Journal.Duck {
    public class Manager : MonoBehaviour {
        public GameObject baseCanvas, createCanvas, journalCanvas;
        public bool interactedWith = false;
        public Animator anim;

        public void BeginInteraction() {
            interactedWith = true;
            anim.StopPlayback();
            DisplayTooltip();
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

        public void GetCreate() {
           baseCanvas.SetActive(false);
           createCanvas.SetActive(true);
        }

        public void GetJournal() {
            baseCanvas.SetActive(false);
            journalCanvas.SetActive(true);
        }

        public void HideTooltip() {
            baseCanvas.SetActive(false);
            createCanvas.SetActive(false);
            journalCanvas.SetActive(false);
        }

        private void ToggleColliders(GameObject parent, bool on) {
            foreach(BoxCollider box in parent.GetComponentsInChildren<BoxCollider>()) {
                box.enabled = on;
            }
        }
    }
}