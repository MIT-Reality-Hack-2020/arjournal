using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Journal.Utils {
    public class RotateTowardCamera : MonoBehaviour {
        public Global global;
        public bool active = true;
        void Update()
        {
            if(active) {
                transform.LookAt(global.cameraRig.transform);
            }
        }
    }
}
