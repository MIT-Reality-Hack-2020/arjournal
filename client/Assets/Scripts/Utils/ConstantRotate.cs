using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Journal.Utils {
    public class ConstantRotate : MonoBehaviour
    {
        void Update()
        {
            transform.rotation *= Quaternion.Euler(0, 0.15f, 0);
        }
    }
}
