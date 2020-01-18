using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Journal {
    public class Global : MonoBehaviour {
        public GameObject cameraRig;
        public Duck.Manager duckManager;
        public float gazeTimeout = 2.0f;
    }
}