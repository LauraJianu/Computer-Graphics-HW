using UnityEngine;
using System.Collections;

public class PickupCoins : MonoBehaviour
{
	public int puncte = 10;

	void start (){
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //other.gameObject.SetActive(false);
			Destroy (gameObject);
        }
    }
}