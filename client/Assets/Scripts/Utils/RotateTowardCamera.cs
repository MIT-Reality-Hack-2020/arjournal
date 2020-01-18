using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Journal.Utils {
    public class RotateTowardCamera : MonoBehaviour {
    public Global global;
    void Update()
    {
        transform.LookAt(global.cameraRig.transform);
    }
    }
}
