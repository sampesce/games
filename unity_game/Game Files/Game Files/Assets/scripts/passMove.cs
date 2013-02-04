using UnityEngine;
using System.Collections;

public class passMove : MonoBehaviour
{
    public Vector3 target;
    public bool canmove = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canmove)
        {
            transform.LookAt(target);
            transform.Translate(Vector3.forward * 0.5f);
        }


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player1" || other.tag == "player2" || other.tag == "player3" || other.tag == "player4" || other.tag == "player5")
        {
            canmove = false;
        }
    }
}