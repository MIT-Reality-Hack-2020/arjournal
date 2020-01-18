using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Journal.Duck {
    public class Manager : MonoBehaviour {
        public CanvasGroup baseCanvas, inputCanvas, journalCanvas;
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
            
        }

        void Update() {
            // anim.speed = depending on distance
        }

        public void DisplayTooltip() {
            baseCanvas.alpha = 1.0f;
        }

        public void GetCreate() {
            baseCanvas.alpha = 0.0f;
            inputCanvas.alpha = 1.0f;
        }

        public void GetJournal() {
            baseCanvas.alpha = 0.0f;
            journalCanvas.alpha = 1.0f;
        }

        public void HideTooltip() {
            baseCanvas.alpha = 0.0f;
            inputCanvas.alpha = 0.0f;
            journalCanvas.alpha = 0.0f;
        }
    }
}