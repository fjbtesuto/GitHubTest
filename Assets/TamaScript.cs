using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamaScript : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//衝突判定を設定する
	void OnCollisionEnter(Collision other)
	{
		//7-②MainScriptの変数を利用するため、MainScript用の関数を準備する
		TextDisp TxtDis;
		MainScript MainSc;

		//7-③MainScriptを取得する
		MainSc = GetComponent<MainScript>();
		TxtDis = GetComponent<TextDisp>();

		//7-④MainScriptのモードによる分岐
		if(MainSc.mode != 2)								//モードが2以外のとき
		{
			if(other.gameObject.name=="mato") 				//衝突した.オブジェクトの.名前が　mato　ならば
			{
				TxtDis.score = 100;							//真の場合、スコアに100を代入
			} else {
				TxtDis.score = 0;							//偽の場合、スコアに0を代入
			}
			MainSc.mode = 2;								//モードを2に切り替える
		}
	}
}
