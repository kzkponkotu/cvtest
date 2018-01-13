using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(MeshRenderer))]
[RequireComponent (typeof(MeshFilter))]
public class ModelTransmit : MonoBehaviour {
	[SerializeField]
	private Material Mat;
	public float Scale;
	private List<Vector3> PolygonList = new List<Vector3>();
	private List<int> PolygonTypeList = new List<int>();
	private List<Vector3> ResultPolygonList = new List<Vector3>();
	private int PushCount = 0;
	private Vector3 PushVec = new Vector3(0,0,0);

	void Awake(){
		gameObject.transform.localScale = new Vector3 (gameObject.transform.localScale.x * Scale,gameObject.transform.localScale.y * Scale,gameObject.transform.localScale.z * Scale);
		//Unityが起動したかどうか
		Application.ExternalCall("UnityAwake");
	}

	//OpenJSCADのポリゴンの三角形が
	public void PushPolygonType(int num){
		PolygonTypeList.Add(num);
	}

	//SendMessageは引数が1つだけなので，xyzの順に送信してポリゴンを作る
	public void PushVertex(float num){
		PushCount++;
		if (PushCount == 1) {
			PushVec = new Vector3 (num,PushVec.y,PushVec.z);
		} else if (PushCount == 2) {
			PushVec = new Vector3 (PushVec.x,num,PushVec.z);			
		} else if (PushCount == 3) {
			PushVec = new Vector3 (PushVec.x,PushVec.y,num);
			PolygonList.Add (PushVec);
			PushCount=0;
		}
	}

	//OpenJSCADのモデルをUnityにもってくる
	public void MakeModel(){
		int LoopNum = PolygonList.Count;
		int count = 0;
		//ポリゴンの調整
		for (int i = 0; i < LoopNum;) {
			if (PolygonTypeList[count] == 3) {
				ResultPolygonList.Add (PolygonList [i]);
				ResultPolygonList.Add (PolygonList [i + 1]);
				ResultPolygonList.Add (PolygonList [i + 2]);
				i += 3;
			}
			if (PolygonTypeList[count] == 4) {
				ResultPolygonList.Add (PolygonList [i]);
				ResultPolygonList.Add (PolygonList [i + 1]);
				ResultPolygonList.Add (PolygonList [i + 2]);

				ResultPolygonList.Add (PolygonList [i]);
				ResultPolygonList.Add (PolygonList [i + 2]);
				ResultPolygonList.Add (PolygonList [i + 3]);
				i += 4;
			}
			count++;
		}
		count = 0;

		LoopNum = ResultPolygonList.Count;

		int[] Triangles = new int[LoopNum];

		for (int i = 0; i<Triangles.Length; i++) {
			Triangles[i] = i;
		}

		//Unityに反映
		var Mesh = new Mesh ();
		Mesh.vertices = ResultPolygonList.ToArray ();
		Mesh.triangles = Triangles;
		Mesh.RecalculateNormals ();
		var Filter = GetComponent<MeshFilter> ();
		Filter.sharedMesh = Mesh;
		var Renderer = GetComponent<MeshRenderer> ();
		Renderer.material = Mat;

		//初期化して2回目の関数呼び出しに影響が出ないようにする
		PolygonList = new List<Vector3>();
		ResultPolygonList = new List<Vector3>();
		PolygonTypeList = new List<int>();
	}

}
