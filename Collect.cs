using UnityEngine;
using System.Collections;

public class Collect : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coin")
        {
            other.gameObject.SetActive(false);

            // sa mai adaug elemente si sa retin cumva starea in care sunt atunci cand ma lovesc de masini

        }

    }

}
