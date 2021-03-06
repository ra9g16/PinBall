﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointController : MonoBehaviour {

	//得点を表示するテキスト
	private GameObject pointText;

	//得点の変数
	private int point = 0;

	//ボールが衝突した時に得点の変数に加算する
	void OnCollisionEnter (Collision Col) {
		if (Col.gameObject.tag == "SmallStarTag") {
			point += 10;
		} else if (Col.gameObject.tag == "LargeStarTag") {
			point += 20;
		} else if (Col.gameObject.tag == "SmallCloudTag") {
			point += 30;
		} else if (Col.gameObject.tag == "LargeCloudTag") {
			point += 40;
		}
	}

	// Use this for initialization
	void Start () {
		//シーン中のPointTextオブジェクトを取得し、得点を０点と表示する
		this.pointText = GameObject.Find("PointText");	
		this.pointText.GetComponent<Text> ().text = "Score: 0";
	}
	
	// Update is called once per frame
	void Update () {
		this.pointText.GetComponent<Text> ().text = "Score: "+point;
	}
}
