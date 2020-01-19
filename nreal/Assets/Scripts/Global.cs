using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Journal {
    public class Global : MonoBehaviour {
        public GameObject cameraRig;
        public Duck.Manager duckManager;
        public MeshRenderer duckMesh;
        public float gazeTimeout = 0.5f;
    }
}