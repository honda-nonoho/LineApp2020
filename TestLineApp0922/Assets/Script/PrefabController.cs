using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabController : MonoBehaviour
{
    public Text _OutputText;
    public Image _MyImage;  //自分のアイコンの写真の宣言
    public Text _BotText; //相手側のテキスト
    public Image _BotImage; //相手側のアイコンの写真の宣言
    
    public void SetText(string text) //MyMessageのテキストはsrring型
    {
        Debug.Log(text);
        Debug.Log(_OutputText);
        _OutputText.text = text;
    }
     public void SetSprite(Sprite sprite) //MyMessageのImageはSprite
    {
        Debug.Log(sprite);
        _MyImage.sprite = sprite;
    }

     public void SetTextBot(string text) //BotのテキストはString型
    {
        Debug.Log(text);
        Debug.Log(_BotText);
         _BotText.text = text;
        
    }
    public void SetSpriteBot(Sprite sprite) //BotのImageはSprite
    {
         Debug.Log(sprite);
        _BotImage.sprite = sprite;
    }

}
