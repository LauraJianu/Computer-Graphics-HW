using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
	public int scoreCount;



    

	// Use this for initialization
	void Start () {
		scoreCount = 0;
		UpdateScore ();
	
	}

    public void AddScore(int pointsToAdd)
    {
        scoreCount += pointsToAdd;
		UpdateScore ();
    }

void UpdateScore ()
	{
	scoreText.text = "Score:" + scoreCount;
	}
}
