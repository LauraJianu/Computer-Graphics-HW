using UnityEngine;
using System.Collections;

public class CountdownScript : MonoBehaviour {

	public GameObject character;
	public GameObject wall1;
	public GameObject wall2;
	public GameObject ground;
	public AudioSource countdownSound; 
	public bool isCountDown = false; 
	public int countMax;  
	private int countDown;  
	public GUIText guiTextCountdown;

	void Start () {
		MonoBehaviour[] scriptComponentsGameControl = gameObject.GetComponents<MonoBehaviour>();   

		foreach(MonoBehaviour script in scriptComponentsGameControl) {
			script.enabled = false;
		}

		wall1.GetComponent<GroundControl>().enabled = false;
		wall2.GetComponent<GroundControl>().enabled = false;
		ground.GetComponent<GroundControl>().enabled = false;
		character.GetComponent<Animation>().enabled = false;
		character.GetComponent<AudioSource>().enabled = false;

		StartCoroutine(CountdownFunction());
	}

	IEnumerator CountdownFunction() {
		countdownSound.PlayDelayed(.4f);

		for(countDown = countMax; countDown>-1;countDown--){
			if(countDown!=0){
				
				guiTextCountdown.text = countDown.ToString();

				yield return new WaitForSeconds(1);    
			}
			else{
				guiTextCountdown.text = "GO!";
				yield return new WaitForSeconds(1);

				countdownSound.Stop();
				isCountDown = true;  
			}
		}

		MonoBehaviour[] scriptComponentsGameControl = gameObject.GetComponents<MonoBehaviour>();   
		foreach(MonoBehaviour script in scriptComponentsGameControl) {
			script.enabled = true;
		}

		wall1.GetComponent<GroundControl>().enabled = true;
		wall2.GetComponent<GroundControl>().enabled = true;
		ground.GetComponent<GroundControl>().enabled = true;
		character.GetComponent<Animation>().enabled = true;
		character.GetComponent<AudioSource>().enabled = true;

		guiTextCountdown.enabled = false;
	}
}