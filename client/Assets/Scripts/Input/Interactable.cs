using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Journal.Input {
    public class Interactable : MonoBehaviour {
        public UnityEvent focus, defocus, action;
    }
}