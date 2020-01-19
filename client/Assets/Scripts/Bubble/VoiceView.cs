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
                    break;
                case "green":
                    smileyRend.sprite = green;
                    break;
                case "yellow":
                    smileyRend.sprite = yellow;
                    break;
                default:
                    smileyRend.sprite = pink;
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