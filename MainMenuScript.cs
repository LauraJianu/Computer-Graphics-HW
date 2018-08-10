using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour 
{
	public GUISkin myskin;  
	public string gameLevel;
	public string optionsLevel;

	private void OnGUI()
	{
		GUI.skin=myskin;   

		GUI.Box(new Rect(Screen.width/4, Screen.height/4, Screen.width/2, Screen.height/2), "MAIN MENU");

		if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+Screen.height/10+10, Screen.width/2-20, Screen.height/10), "PLAY")){
			Application.LoadLevel(gameLevel);
			//SceneManager.LoadScene("MAIN MENU");
		}

		if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+2*Screen.height/10+10, Screen.width/2-20, Screen.height/10), "CREDITS")){
			Application.LoadLevel(optionsLevel);
			//SceneManager.LoadScene("CREDITS");
		}

		if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+3*Screen.height/10+10, Screen.width/2-20, Screen.height/10), "EXIT")){
			Application.Quit();
			//SceneManager.LoadScene("EXIT");
		}
	}
}