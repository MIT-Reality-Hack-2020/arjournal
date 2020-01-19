using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Journal.Bubble {
    public class ImageView : MonoBehaviour
    {
        public SpriteRenderer smileyRend;
        public RawImage imageRend;
        public Sprite blue, green, yellow, pink;
        public TextMeshProUGUI text;
        private Global global;

        void Awake() {
            global = FindObjectOfType<Global>();
            
        }

        public void SetEmotion() {
            text.text = System.DateTime.Now.ToString("MM/dd/yyyy") + "\n" + System.DateTime.Now.ToString("h:mm tt");
            switch(global.duckManager.emotion) {
                case "blue":
                    smileyRend.sprite = blue;
                    transform.parent.GetComponent<MeshRenderer>().material.color = new Color(0.506f, 0.816f, 0.847f, 1.0f);
                    break;
                case "green":
                    smileyRend.sprite = green;
                    transform.parent.GetComponent<MeshRenderer>().material.color = new Color(0.573f, 0.792f, 0.427f, 1.0f);
                    break;
                case "yellow":
                    smileyRend.sprite = yellow;
                    transform.parent.GetComponent<MeshRenderer>().material.color = new Color(0.996f, 0.875f, 0.353f, 1.0f);
                    break;
                default:
                    smileyRend.sprite = pink;
                    transform.parent.GetComponent<MeshRenderer>().material.color = new Color(0.965f, 0.604f, 0.569f, 1.0f);
                    break;
            }
        }

        public void SetImage(Texture2D texture) {
            imageRend.material = Instantiate(imageRend.material);
            Texture2D _texture = Texture2D.Instantiate(texture); //new Texture2D(texture.width, texture.height);
            // Color[] pix = texture.GetPixels();
            // _texture.SetPixels(pix);
            // _texture.Apply();
            imageRend.material.mainTexture = _texture;
            imageRend.texture = _texture;
            text.text = System.DateTime.Now.ToString("MM/dd/yyyy") + "\n" + System.DateTime.Now.ToString("h:mm tt");
        }

        public void View(Data.Bubble bubble) {
            imageRend.texture = bubble.image;
            text.text = bubble.timestamp;
            switch(bubble.smiley) {
                case(1):
                    smileyRend.sprite = blue;
                    break;
                case(2):
                    smileyRend.sprite = green;
                    break;
                case(3):
                    smileyRend.sprite = yellow;
                    break;
                default:
                    smileyRend.sprite = pink;
                    break;
            }
        }
    } 
}
