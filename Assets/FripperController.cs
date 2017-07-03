using UnityEngine;
using System.Collections;

public class FripperController : MonoBehaviour {
	//HingiJointコンポーネントを入れる
	private HingeJoint myHingeJoint;

	//初期の傾き
	private float defaultAngle = 20;
	//弾いた時の傾き
	private float flickAngle = -20;

	// Use this for initialization
	void Start () {
		//HinjiJointコンポーネント取得
		this.myHingeJoint = GetComponent<HingeJoint>();

		//フリッパーの傾きを設定
		SetAngle(this.defaultAngle);
	}

	// Update is called once per frame
	void Update () {

		//左矢印キーを押した時左フリッパーを動かす
		if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.flickAngle);
		}
		//右矢印キーを押した時右フリッパーを動かす
		if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.flickAngle);
		}

		//矢印キー離された時左フリッパーを元に戻す
		if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.defaultAngle);
		}
		//矢印キー離された時右フリッパーを元に戻す
		if (Input.GetKeyUp (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.defaultAngle);
		}

		//最初のタップがされた時にフリッパーを動かす
		if (Input.touchCount > 0) {
			Touch touch0 = Input.GetTouch (0);
			if (touch0.phase == TouchPhase.Began) {
				//画面の真ん中より左側でタップした時は左フリッパーを動かす
				if (touch0.position.x < Screen.width / 2 && tag == "LeftFripperTag") {
					SetAngle (this.flickAngle);
				}
				//画面の真ん中より右側でタップした時は右フリッパーを動かす
				if (touch0.position.x > Screen.width / 2 && tag == "RightFripperTag") {
					SetAngle (this.flickAngle);
				}
			} else if (touch0.phase == TouchPhase.Ended) {
				//タップが終わった時に左フリッパーを元の位置に戻す
				if (touch0.position.x < Screen.width / 2 && tag == "LeftFripperTag") {
					SetAngle (this.defaultAngle);
				}
				//タップが終わった時に右フリッパーを元の位置に戻す
				if (touch0.position.x > Screen.width / 2 && tag == "RightFripperTag") {
					SetAngle (this.defaultAngle);
				}
			}
		}

		//最初のタップが画面を押している中で、次のタップがされた時にフリッパーを動かす
		if (Input.touchCount > 1) {
			Touch touch1 = Input.GetTouch (1);
			if (touch1.phase == TouchPhase.Began) {
				//画面の真ん中より左側でタップした時は左フリッパーを動かす
				if (touch1.position.x < Screen.width/2 && tag == "LeftFripperTag") {
					SetAngle (this.flickAngle);
				}
				//画面の真ん中より右側でタップした時は右フリッパーを動かす
				if (touch1.position.x > Screen.width/2 && tag == "RightFripperTag") {
					SetAngle (this.flickAngle);
				}
			} else if (touch1.phase == TouchPhase.Ended) {
				//画面の真ん中より左側でタップした時は左フリッパーを動かす
				if (touch1.position.x < Screen.width/2 && tag == "LeftFripperTag") {
					SetAngle (this.defaultAngle);
				}
				//画面の真ん中より右側でタップした時は右フリッパーを動かす
				if (touch1.position.x > Screen.width/2 && tag == "RightFripperTag") {
					SetAngle (this.defaultAngle);
				}
			}
		}
	}

	//フリッパーの傾きを設定
	public void SetAngle (float angle){
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;
	}
}
