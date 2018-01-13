using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebGLInputFlag : MonoBehaviour {

	public bool UnityForcusFlag=false;

	// Use this for initialization
	void Awake () {
		//Unityのフォーカスを無効にする
		#if !UNITY_EDITOR && UNITY_WEBGL
		WebGLInput.captureAllKeyboardInput = UnityForcusFlag;
		#endif
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
