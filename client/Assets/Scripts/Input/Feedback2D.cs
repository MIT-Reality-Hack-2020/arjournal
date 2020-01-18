using UnityEngine;
using UnityEngine.UI;

namespace Journal.Input {
    public class Feedback2D : MonoBehaviour {
        public Global global;
        public Image feedbackRectangle;
        private float timer;
        private bool focused = false;

        void Update() {
            if(focused) {
                feedbackRectangle.material.color = Color.Lerp(feedbackRectangle.material.color, Color.white, timer / global.gazeTimeout);
                timer += Time.deltaTime;
            }
            else {
                feedbackRectangle.material.color = new Color(0, 0, 0, 0);
            }
        }

        public void focus() {
            focused = true;
            timer = 0.0f;
        }

        public void defocus(){
            focused = false;
        }
    }
}