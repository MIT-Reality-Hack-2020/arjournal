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
            Vector3 duckPosition2D = transform.parent.position;
            Vector3 cameraPosition2D = global.cameraRig.transform.position;
            cameraPosition2D.y = duckPosition2D.y;

            float dist = Vector3.Distance(duckPosition2D, cameraPosition2D);

            if(dist > 1.8f) {
                transform.parent.position = Vector3.MoveTowards(transform.parent.position, cameraPosition2D, 0.02f);
            }
            else if(dist < 1.2f) {
                transform.parent.position = Vector3.MoveTowards(transform.parent.position, cameraPosition2D, -0.02f);
            }

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