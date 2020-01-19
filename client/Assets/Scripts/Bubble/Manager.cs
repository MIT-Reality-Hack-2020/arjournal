using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Journal.Bubble {
    public class Manager : MonoBehaviour
    {
        public enum bubbleType {
            image, voice
        };

        private ImageView imageView;
        private VoiceView voiceView;
        private MeshRenderer mesh;
        public bubbleType type;
        public GameObject headphonesModel, cameraModel;

        void Start()
        {
            imageView = gameObject.GetComponentInChildren<ImageView>();
            voiceView = gameObject.GetComponentInChildren<VoiceView>();
            mesh = GetComponent<MeshRenderer>();
            imageView.gameObject.SetActive(false);
            voiceView.gameObject.SetActive(false);
        }

        public void ExpandBubble() {
            headphonesModel.SetActive(false);
            cameraModel.SetActive(false);
            switch(type) {
                case bubbleType.image:
                    imageView.gameObject.SetActive(true);
                    break;
                default:
                    voiceView.gameObject.SetActive(true);
                    voiceView.Play();
                    break;
            }
            mesh.enabled = false;
        }

        public void CloseBubble() {
            imageView.gameObject.SetActive(false);
            voiceView.gameObject.SetActive(false);
            voiceView.Stop();
            mesh.enabled = true;
            switch(type) {
                case bubbleType.image:
                    cameraModel.SetActive(true);
                    break;
                default:
                    headphonesModel.SetActive(true);
                    break;
            }
        }
    }
}