using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ReciveObjectController : MonoBehaviour
{

   public Text _ReciveObjectText; //相手側のテキスト
   public Image _ReciveObjectImage; //相手側のアイコンの写真の宣言
    // Start is called before the first frame update
    public void SetTextReciveObject(string text)
    {
        

        Debug.Log(text);
        Debug.Log(_ReciveObjectText);
       
         _ReciveObjectText.text = text;
        
    }

    public void SetSpriteReciveObject(Sprite sprite)
    {
         Debug.Log(sprite);
        _ReciveObjectImage.sprite = sprite;
    }
}
