using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Journal.Input {
    public class Selector : MonoBehaviour {
        public Global global;
        private Interactable target;
        private float timer;

        void Start() {
            timer = global.gazeTimeout;
        }

        void Update() {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity)) {
                target = hit.transform.gameObject.GetComponent<Interactable>();
                target.focus.Invoke();
                timer -= Time.deltaTime;
                if(target == null) {
                    timer = global.gazeTimeout;
                }
                else if(timer < 0) {
                    target.action.Invoke();
                }
            }
            else if(target != null) {
                target.defocus.Invoke();
                target = null;
                timer -= Time.deltaTime;
                if(timer < 0) {
                    global.duckManager.EndInteraction();
                }
            }
        }
    }
}