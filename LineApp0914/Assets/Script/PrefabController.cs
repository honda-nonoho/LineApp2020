using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabController : MonoBehaviour
{
    
   public Text _OutputText;
   public Image _MyImage;  //自分のアイコンの写真の宣言
    
   
    

 
    public void SetText(string text)
    {
        
        Debug.Log(text);
        Debug.Log(_OutputText);
        _OutputText.text = text;
    }


    //自分のアイコンの写真
     public void SetSprite(Sprite sprite)
    {
        Debug.Log(sprite);
        _MyImage.sprite = sprite;

    }

    

}
