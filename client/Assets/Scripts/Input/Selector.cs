using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Journal.Input {
    public class Selector : MonoBehaviour {
        public Global global;
        public GameObject recticle;
        private Interactable target;
        private float timer;
        private bool justTriggered = false;
        private bool justDefocused = false;
        private Vector3 recticleBaseScale;

        void Start() {
            timer = global.gazeTimeout;
            recticleBaseScale = recticle.transform.localScale;
        }

        private void UpdateRecticleSize() {
            recticle.transform.localScale = Mathf.Sin(timer / global.gazeTimeout) * recticleBaseScale;
        }

        void Update() {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity)) {
                if(target == hit.transform.gameObject.GetComponent<Interactable>()) {
                    if(timer < 0) {
                        if(justTriggered) {
                            return;
                        }
                        else {
                            target.action.Invoke();
                            Debug.Log("Triggered action on " + target.gameObject.ToString());
                            justTriggered = true;
                        }
                    }
                }
                else {
                    if(target) {
                        Debug.Log("Defocused on " + target.gameObject.ToString());
                        target.defocus.Invoke();
                    }
                    target = hit.transform.gameObject.GetComponent<Interactable>();
                    target.focus.Invoke();
                    Debug.Log("Focused on " + target.gameObject.ToString());
                    timer = global.gazeTimeout;
                }
                recticle.SetActive(true);
                recticle.transform.position = hit.point;
                timer -= Time.deltaTime;
                UpdateRecticleSize();
            }
            else if(target) {
                recticle.SetActive(false);
                if(!justDefocused) {
                    justDefocused = true;
                    Debug.Log("Defocused on " + target.gameObject.ToString());
                    target.defocus.Invoke();
                    timer = global.gazeTimeout;
                }
                else {
                    timer -= Time.deltaTime;
                }
                if(timer < 0) {
                    justDefocused = false;
                    global.duckManager.EndInteraction();
                    target = null;
                }
            }
            else {
                recticle.SetActive(false);
                if(target == null) {
                    timer = global.gazeTimeout;
                }
            }
        }
    }
}