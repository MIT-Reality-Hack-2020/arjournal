using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Journal.Bubble {
    public class VoiceView : MonoBehaviour
    {
        public TextMeshProUGUI text;
        public AudioSource source;

        public void SetVoice(AudioClip clip) {
            source.clip = clip;
            text.text = System.DateTime.Now.ToString("MM/dd/yyyy") + "\n" + System.DateTime.Now.ToString("h:mm tt");
        }

        public void SetClip(AudioClip clip) {
            source.clip = clip;
        }

        public void Play() {
            source.Play();
        }

        public void Stop() {
            source.Stop();
        }
        
    }
}