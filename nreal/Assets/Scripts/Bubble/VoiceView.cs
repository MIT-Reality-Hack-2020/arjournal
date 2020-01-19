using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Journal.Bubble {
    public class VoiceView : MonoBehaviour
    {
        public TextMeshProUGUI text;
        public AudioSource source;
        private Global global;
        public SpriteRenderer smileyRend;
        public Sprite blue, green, yellow, pink;
        void Awake() {
            global = FindObjectOfType<Global>();
        }

        public void SetVoice(AudioClip clip) {
            source.clip = clip;
            
        }

        public void SetClip(AudioClip clip) {
            text.text = System.DateTime.Now.ToString("MM/dd/yyyy") + "\n" + System.DateTime.Now.ToString("h:mm tt");
            source.clip = clip;

            switch(global.duckManager.emotion) {
                case "blue":
                    smileyRend.sprite = blue;
                    transform.parent.GetComponent<MeshRenderer>().material.color = new Color(0.506f, 0.816f, 0.847f, 1.0f);
                    break;
                case "green":
                    smileyRend.sprite = green;
                    transform.parent.GetComponent<MeshRenderer>().material.color = new Color(0.573f, 0.792f, 0.427f, 1.0f);
                    break;
                case "yellow":
                    smileyRend.sprite = yellow;
                    transform.parent.GetComponent<MeshRenderer>().material.color = new Color(0.996f, 0.875f, 0.353f, 1.0f);
                    break;
                default:
                    smileyRend.sprite = pink;
                    transform.parent.GetComponent<MeshRenderer>().material.color = new Color(0.965f, 0.604f, 0.569f, 1.0f);
                    break;
            }
        }

        public void Play() {
            source.Play();
        }

        public void Stop() {
            source.Stop();
        }
        
    }
}