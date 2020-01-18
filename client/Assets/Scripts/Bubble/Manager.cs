using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Journal.Bubble {
    public class Manager : MonoBehaviour
    {
        private ImageView imageView;
        private MeshRenderer mesh;
        // Start is called before the first frame update
        void Start()
        {
            imageView = gameObject.GetComponentInChildren<ImageView>();
            imageView.gameObject.SetActive(false);
        }

        public void ExpandBubble() {
            imageView.gameObject.SetActive(true);
            mesh.enabled = false;
        }

        public void CloseBubble() {
            imageView.gameObject.SetActive(false);
            mesh.enabled = true;
        }
    }
}