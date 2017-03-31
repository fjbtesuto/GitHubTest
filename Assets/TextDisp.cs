using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisp : MonoBehaviour {

	public int score = 0;
	public int test; //gitテスト	

	// Use this for initialization
	void Start () {
		Text msg = GameObject.Find("Canvas/ScoreText").GetComponent<Text>();
		msg.text = "Score : " + score;
	}
	
	// Update is called once per frame
	void Update () {
		score = GetComponent<MainScript> ().score;
		Text msg = GameObject.Find("Canvas/ScoreText").GetComponent<Text>();
		msg.text = "Score : " + score;
		}
}


