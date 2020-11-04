using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LineController : MonoBehaviour
{
    //①各UIの説明
     public InputField inputField;   //自分の入力するテキスト(InptField)
     private Text text;  //テキストの宣言
     [SerializeField] private GameObject _ScrollViewContent = null; //ScrollViewのコンテンツの宣言
     [SerializeField] private Button _SentButton = null; //送信ボタン


    //②MyMessageの宣言
    const string _From = "Prefab/MyMessege";  //MyMessageのプレハブの場所の宣言
    private PrefabController _PrefabContent = null; //Prefab(Object)の説明
   

    //③BotMessegeの宣言
     const string _FromBot = "Prefab/BotMessage"; //Botのプレハブの場所の宣言
     private PrefabController _PrefabBotContent = null; //BotのPrefab(Object)の説明
     private Dictionary<int,string> dic = new Dictionary<int, string>();  //BotMessageの内容(Dictionary)
    int _Loop = 0; //dicを何回繰り返したら？の時その数字はint型
    
    //④最初の処理(Start)
    void Start()
    {
       _SentButton.onClick.AddListener(OnClickSentButton); //送信ボタンのイベント登録
          
       if(inputField.text != "") //もし入力したテキストに何かしらの文字が入っていたら
       {
           OnClickSentButton();      //OnClickSentButtonの処理を行って
       }

        Debug.Log("Start");      //スタート関数のデバッグログ表示

        //BotのDictionary
        dic.Add(0, "こんにちわ");
        dic.Add(1, "なに？");
        dic.Add(2, "へ〜");
        dic.Add(3, "それな");
        dic.Add(4, "無理w");

        
        _PrefabBotContent = Resources.Load<PrefabController>(_FromBot);   //Botのリソーシズ
        //Botのプレハブ(Object)はリソーシズでロードしてBotPrefabControllerからコンポーネントをアタッチしてUIを_FromBotから持ってくる
            
        
    }

    //送信ボタンの処理メゾット
     private void OnClickSentButton()
    {
       Debug.Log(inputField.text); //自分の入力した文字
       Load();  //ロード関数を呼び出す
       StartCoroutine("Test"); //ボタンを押した時にこの処理が行われる（１秒後に表示）
      
        inputField = inputField.GetComponent<InputField> ();  //inputFieldのコンポーネントの説明
        inputField.text = ""; //inputField内のテキストをボタン送信後に空にする
    }

    //イナム
    IEnumerator Test()
    {
        yield return new WaitForSeconds(1);   //何秒後に

        Debug.Log(dic[_Loop]); //dicの中のKeyの値をDebugLogで表示、表示されるのはvalue
            //インスタンスのクローンの生成 
        var PrefabClone = Instantiate<PrefabController>(_PrefabBotContent, Vector3.zero, Quaternion.identity, _ScrollViewContent.transform);
        PrefabClone.SetTextBot(dic[_Loop]);//インスタンスにテキストを渡して表示する

        if(_Loop == 4)
         {
           _Loop = 0; //dicのkeyが４までいったら０になる
          }else{
           _Loop++; //4じゃなければカウントアップの処理をする
          }

        var BotSprite = Resources.Load<Sprite>("Image/icon2"); //相手側のアイコンの写真
        PrefabClone.SetSpriteBot(BotSprite);        
    }

    void Load()
    {

        //ResourcesLoad
        _PrefabContent = Resources.Load<PrefabController>(_From);   //MyMessageのリソーシズ
        var Sprite = Resources.Load<Sprite>("Image/icon1");  //MyMessageのアイコンの写真
    
        //Instantiate
        var Prefab  = Instantiate<PrefabController>(_PrefabContent, Vector3.zero, Quaternion.identity, _ScrollViewContent.transform);
        
        Prefab.SetText(inputField.text); //MyMessageのプレハブに渡すテキスト
        Prefab.SetSprite(Sprite);        //MyMessageのプレハブに渡すスプライト
    
        Debug.Log("Load");
    }
    
}
