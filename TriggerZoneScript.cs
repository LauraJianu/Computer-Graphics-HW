using UnityEngine;
using System.Collections;

public class TriggerZoneScript : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		Destroy (other.gameObject);
	}

	void Start () {
	
	}	

	void Update () {
	
	}
}
