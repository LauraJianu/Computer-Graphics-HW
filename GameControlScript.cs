using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameControlScript : MonoBehaviour {

	public GUISkin skin;
	float timeRemaining = 10;
	float timeExtension = 3f;
	float timeDeduction = 2f;
	float totalTimeElapsed = 0;
	float score=0f;
	public bool isGameOver = false;

	void Start(){
		Time.timeScale = 1;  
	}

	void Update () { 
		if(isGameOver)
			return;

		totalTimeElapsed += Time.deltaTime;
		score = totalTimeElapsed*100;
		timeRemaining -= Time.deltaTime;
		if(timeRemaining <= 0){
			isGameOver = true;
		}
	}

	public void PowerupCollected()
	{
		timeRemaining += timeExtension;
	}

	public void Obstacles()
	{
		timeRemaining -= timeDeduction;
	}

	void OnGUI()
	{
		GUI.skin=skin; 
		if(!isGameOver)    
		{
			GUI.Label(new Rect(10, 10, Screen.width/5, Screen.height/6),"TIME LEFT: "+((int)timeRemaining).ToString());
			GUI.Label(new Rect(Screen.width-(Screen.width/6), 10, Screen.width/6, Screen.height/6), "SCORE: "+((int)score).ToString());
		}

		else
		{
			Time.timeScale = 0; 


			GUI.Box(new Rect(Screen.width/4, Screen.height/4, Screen.width/2, Screen.height/2), "GAME OVER\nYOUR SCORE: "+(int)score);


			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+Screen.height/10+10, Screen.width/2-20, Screen.height/10), "RESTART")){
				Application.LoadLevel(Application.loadedLevel);
				//SceneManager.LoadScene("RESTART");
			}


			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+2*Screen.height/10+10, Screen.width/2-20, Screen.height/10), "MAIN MENU")){
				Application.LoadLevel(1);
				//SceneManager.LoadScene("MAIN MENU");
			}


			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+3*Screen.height/10+10, Screen.width/2-20, Screen.height/10), "EXIT GAME")){
				Application.Quit();
			}
		}
	}
}