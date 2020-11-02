using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TestController : MonoBehaviour
{
    //InputFieldを格納するための変数
    //オブジェクトと結びつける
    public InputField inputField;

    private Text text;
    //コンテンツ(ScrollView)
   [SerializeField] private GameObject _ScrollContent = null;

   //PrefabContent
   private PrefabController _PrefabContent = null;
    const string _From = "Prefab/GameObject";
    

    
  
   
   //Dicの宣言
   private Dictionary<int,string> dic = new Dictionary<int, string>();
    //相手側のprefab
   private ReciveObjectController _PrefabReciveContent = null;
   const string _FromReciveObject = "Prefab/ReceiveObject";
   
   int _Loop = 0;
   
   //送信ボタン
    [SerializeField] private Button _Button = null;
    void Start()
    {
          _Button.onClick.AddListener(OnClickButton);
          
    
       if(inputField.text != "")
       {
           OnClickButton();
       }

        Debug.Log("Start");

        //相手側のdic
        dic.Add(0, "こんにちわ");
        dic.Add(1, "知らんけど");
        dic.Add(2, "へ〜");
        dic.Add(3, "それな");
        dic.Add(4, "無理w");

        //相手側のリソーシズ
        _PrefabReciveContent = Resources.Load<ReciveObjectController>(_FromReciveObject);
            
        
    }
    //送信ボタンの処理メゾット
     private void OnClickButton()
    {
       Debug.Log(inputField.text);
       Load();
       StartCoroutine("Test");
      
        inputField = inputField.GetComponent<InputField> ();
        inputField.text = ""; //inputField内のテキストをボタン送信後に空にする

        //相手側のテキストの処理,
    
        
    
    }

    IEnumerator Test()
        {
            yield return new WaitForSeconds(1);//何秒後に

            Debug.Log(dic[_Loop]); //dicの中のKeyの値をDebugLogで表示、表示されるのはvalue
            //インスタンスのクローンの生成 
            var PrefabClone = Instantiate<ReciveObjectController>(_PrefabReciveContent, Vector3.zero, Quaternion.identity, _ScrollContent.transform);
            PrefabClone.SetTextReciveObject(dic[_Loop]);//インスタンスにテキストを渡して表示する
            if(_Loop == 4)
            {
                _Loop = 0; //dicのkeyが４までいったら０になる
            }else{
                _Loop++; //4じゃなければカウントアップの処理をする
            }

            var ReciveSprite = Resources.Load<Sprite>("Image/icon2"); //相手側のアイコンの写真
            PrefabClone.SetSpriteReciveObject(ReciveSprite); 
        

            
        }


    

    void Load()
    {

        //ResourcesLoad
        _PrefabContent = Resources.Load<PrefabController>(_From);

        var Sprite = Resources.Load<Sprite>("Image/icon1"); //アイコンの写真
    
        

        //Instantiate
        var Prefab  = Instantiate<PrefabController>(_PrefabContent, Vector3.zero, Quaternion.identity, _ScrollContent.transform);
        
        Prefab.SetText(inputField.text); 
        Prefab.SetSprite(Sprite);       //インスタンス.PrefabControllerのSetSprite(スプライトのリソーシズ）
        

        Debug.Log("Load");

        
        
    }
}
