using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Journal.Duck {
    public class Positioner : MonoBehaviour {
        public Global global;
        public Manager manager;
        void Start() {
            
        }

        void Update() {
            if(manager.interactedWith) {
                Vector3 direction = global.cameraRig.transform.position - transform.position;
                Vector3 newDirection = Vector3.RotateTowards(transform.transform.forward, direction, Time.deltaTime, 0.0f);
                transform.rotation = Quaternion.LookRotation(newDirection);
            }
            else {
                
            }
        }
    }
}