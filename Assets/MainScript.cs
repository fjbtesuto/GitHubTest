using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour {

	public int mode = 0;
	//7-①得点用の変数を準備する
	public int score = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		GameObject tamaObj = GameObject.Find("tama");

		//モード切替
		if(mode==0)
		{
			//玉を飛ばす前の処理
			//3-①マウスの位置を取得
			Vector3 screenPoint = Input.mousePosition;

			//3-②z座標は画面に映るよう固定値にしておく(カメラからの距離)
			screenPoint.z = 10.0f;

			//3-③マウスの座標を今写っているカメラからみたゲーム座標に変換する
			Vector3 worldPoint = GetComponent<Camera>().ScreenToWorldPoint(screenPoint);	//カメラにMainScriptがAddされていることが前提となる

			//3-④変換した座標を動かしたいオブジェクトの座標に入れる
			tamaObj.transform.position = worldPoint;

			//4-①何かキーが押されたならば、玉を打つ
			if(Input.GetMouseButtonDown(0))		//左クリックが押された瞬間を条件とする
			{
				mode=1;							//モードを１へ切り替え
				tamaObj.GetComponent<Rigidbody>().useGravity=true;	//tamaの重力設定を真にする
				Vector3 speed;										//玉の移動用にVector3型のspeedを作成
				speed.x=0;											//x軸は固定
				speed.y=0;											//y軸も固定
				speed.z=100;										//z軸に100移動
				tamaObj.GetComponent<Rigidbody>().AddForce(speed,ForceMode.Impulse);	//z軸に100の力で玉を発射
			}
		}
		else if(mode==1)
		{
			//5-①玉を飛ばした後の処理
			Vector3 tamapos = tamaObj.transform.position;		//玉の座標を取得
			//5-②とちゅうからカメラが玉をおう
			if(tamapos.z>20)									//玉のｚ座標が20を超えた場合
			{
				tamapos.z -= 10.0f;								//ｚ座標を固定する
				this.transform.position = tamapos;				//玉の位置をこのオブジェクトの位置に変更する
			}

			//6-①玉が下にそれた場合の処理
			if(tamapos.y<-1)									//玉が的よりも下に移動したら
			{
				mode=2;											//モード2に切り替える
			}

			//得点を表示する

		
		}
		else if(mode==2)
		{
			//判定後の処理

		}

	}
}
