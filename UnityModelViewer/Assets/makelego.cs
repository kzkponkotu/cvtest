using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makelego : MonoBehaviour {

	public GameObject lego;

	// Use this for initialization
	void Start () {
		for (int x = 0; x < 5; x++) {
			for (int y = 0; y < 10; y++) {
				for (int z = 0; z < 5; z++) {				
					Instantiate (lego,new Vector3(-15.8f*x,9.6f*y,15.8f*z),Quaternion.identity);
				}
			}
		}
	}
	
}
