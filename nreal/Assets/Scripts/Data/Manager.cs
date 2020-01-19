using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Journal.Data {
    public class Manager : MonoBehaviour {
        List<Bubble> bubbles = new List<Bubble>();
        void Start() {
            
        }

        void Update() {
            
        }

        public void InsertBubble(Bubble bubble) {
            bubbles.Add(bubble);
        }

        //public void Add
    }
}