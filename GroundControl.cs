using UnityEngine;
using System.Collections;

public class GroundControl : MonoBehaviour {
	
	float speed = .5f;//material texture rate

	void Update () {
		float offset = Time.time * speed;//offset at a constant rate, counter
		GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, -offset);
	}
}
