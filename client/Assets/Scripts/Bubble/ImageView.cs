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


        public void SetImage(Texture texture) {
            imageRend.texture = texture;
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
