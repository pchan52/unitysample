//  CircleDeployer.cs
//  http://kan-kikuchi.hatenablog.com/entry/CircleDeployer
//
//  Created by kan.kikuchi on 2016.01.12.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 子にあるオブジェクトを円状に配置するクラス
/// </summary>
public class Circle: MonoBehaviour {

	//半径
//	[SerializeField]
//	private float _radius;

	public float radius;
	float radiusvelocity;
	bool limit = false;
	float x;
	float y;
	float z;
	public float speed;
	public float velocity;
	float anglevelocity = 0f;
	float ringvelocity;

	//=================================================================================
	//初期化
	//=================================================================================

//	private void Awake(){
//		Deploy ();
//	}
//
//	//Inspectorの内容(半径)が変更された時に実行
//	private void OnValidate (){
//		Deploy ();
//	}
//
	void Update(){
		Deploy ();

	}

	//子を円状に配置する(ContextMenuで鍵マークの所にメニュー追加)
	[ContextMenu("Deploy")]
	private void Deploy(){

		//子を取得
		List<GameObject> childList = new List<GameObject> ();
		foreach(Transform child in transform) {
			childList.Add (child.gameObject);
		}

		//数値、アルファベット順にソート
		childList.Sort (
			(a, b) => {
				return string.Compare(a.name, b.name);
			}
		);
			
		//オブジェクト間の角度差
		float angleDiff = 360f / (float)childList.Count;

		//半径を徐々に広げ，最大半径で止める
		radiusvelocity += Time.deltaTime;
		if (radiusvelocity > radius) {
			radiusvelocity = radius;
			limit = true;
		}

		//角度を増やす
		anglevelocity += Time.deltaTime * speed; 

		//各オブジェクトを円状に配置
		for (int i = 0; i < childList.Count; i++)  {
			if (limit) {
				Vector3 childPostion = childList[i].transform.position;
				float angle = (90 - angleDiff * i) * Mathf.Deg2Rad + anglevelocity;
				Vector3 offset = new Vector3(Mathf.Sin(angle) , Mathf.Cos(angle), ringvelocity);
				childList [i].transform.position = offset * radius;

			} else {
				Vector3 childPostion = transform.position;

				float angle = (90 - angleDiff * i) * Mathf.Deg2Rad;
	//			childPostion.x += _radius * Mathf.Cos (angle);
	//			childPostion.y += _radius * Mathf.Sin (angle);
				childPostion.x += radiusvelocity * Mathf.Cos (angle);
				childPostion.y += radiusvelocity * Mathf.Sin (angle);
				childList [i].transform.position = childPostion;
			}
		}
		if (limit) {
			ringvelocity += Time.deltaTime * velocity;
			Vector3 ringposition = new Vector3 (0f, 0f, ringvelocity);
			gameObject.transform.position = ringposition;
		}

	}

}  
