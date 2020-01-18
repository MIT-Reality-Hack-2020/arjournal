using UnityEngine;
using UnityEngine.UI;

namespace Journal.Input {
    public class Feedback2D : MonoBehaviour {
        public Global global;
        public SpriteRenderer feedbackRectangle;
        private float timer;
        private bool focused = false;

        void Update() {
            if(focused) {
                feedbackRectangle.enabled = true;
                timer += Time.deltaTime;
            }
            else {
                feedbackRectangle.enabled = false;
            }
        }

        public void Focus() {
            focused = true;
            timer = 0.0f;
        }

        public void Defocus(){
            focused = false;
        }
    }
}