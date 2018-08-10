using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
	public GameObject obstacle;
	public GameObject coin;
	public GameObject powerup;

	float timeElapsed = 0;
	float spawnCycle = 0.5f;
	bool spawnPowerup = true;

	void Update () {
		timeElapsed += Time.deltaTime;
		if (timeElapsed > spawnCycle) {
			GameObject temp;
			if (spawnPowerup) {
				temp = (GameObject)Instantiate (coin);//powerup before
				Vector3 pos = temp.transform.position;
				temp.transform.position = new Vector3 (Random.Range (-3, 4), pos.y, pos.z);
			} else {
				temp = (GameObject)Instantiate (obstacle);
				Vector3 pos = temp.transform.position;
				temp.transform.position = new Vector3 (Random.Range (-3, 4), pos.y, pos.z);
			}

			timeElapsed -= spawnCycle;
			spawnPowerup = !spawnPowerup;
		}
		/*if (timeElapsed > spawnCycle)
		{
			GameObject temp;
			if (spawnPowerup) 
			{
				temp = (GameObject)Instantiate (powerup);
				Vector3 pos = temp.transform.position;
				temp.transform.position = new Vector3 (Random.Range (-3, 4), pos.y, pos.z);
			} 
			else {
				temp = (GameObject)Instantiate (coin);
				Vector3 pos = temp.transform.position;
				temp.transform.position = new Vector3 (Random.Range (-3, 4), pos.y, pos.z);
			}

			timeElapsed -= spawnCycle;
			spawnPowerup = !spawnPowerup;
		}*/
	}
}