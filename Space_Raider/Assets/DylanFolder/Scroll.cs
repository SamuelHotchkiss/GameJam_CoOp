using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Time.time * 0.5f, Time.time * 0.5f);
	}
}
