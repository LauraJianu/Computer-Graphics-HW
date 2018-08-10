/*using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour
{
    public Transform target; public int moveSpeed; public int rotationSpeed; public int maxDistance;

    private Transform myTransform;

    void Awake()
    {
        myTransform = transform;
    }
    // Use this for initialization
    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");

        target = go.transform;

        maxDistance = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(target.position, myTransform.position, Color.yellow);

        //Look at target
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);

        if (Vector3.Distance(target.position, myTransform.position) > maxDistance)
        {
            //Move towards target
            myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
        }
    }

}*/

using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour
{

    Transform tr_Player;
    float f_RotSpeed = 2.0f, f_MoveSpeed = 3.0f;

    // Use this for initialization
    void Start()
    {

        tr_Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame

    void Update()
    {

        //Look at Player rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(tr_Player.position - transform.position,Vector3.up),f_RotSpeed * Time.deltaTime);

        
    // Move at Player
    transform.position += transform.forward * f_MoveSpeed * Time.deltaTime;
    }
}

