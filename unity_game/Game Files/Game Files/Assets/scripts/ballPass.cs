using UnityEngine;
using System.Collections;

public class ballPass : MonoBehaviour
{



    GameObject otherplayer;
	bool hasTar = false;
	public Camera camera;


    //bool isselected = false;


    public GameObject ball;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                if (hit.collider.tag == "player1" || hit.collider.tag == "player2" || hit.collider.tag == "player3" || hit.collider.tag == "player4" || hit.collider.tag == "player5")
                {
                    Debug.Log(hit.collider.tag);
                    otherplayer = hit.collider.gameObject;
					hasTar = true;
                    //isselected = true;
                }
				

            }


        }
		
		
		if(Input.GetKeyDown(KeyCode.F)){
		
			ball.GetComponent<ballScript>().isTaken = false;
			ball.rigidbody.isKinematic = false;
			ball.rigidbody.useGravity = true;
			ball.rigidbody.AddForce(Vector3.forward * 8000);
			//ball.rigidbody.AddForce(Vector3.back * 20);
			//ball.rigidbody.AddForce(Vector3.right * 20);
			//ball.rigidbody.AddForce(Vector3.left * 20);
				
			
			
		}

        if (Input.GetKeyUp(KeyCode.T) && ((otherplayer.transform.position.x != transform.position.x )&& (otherplayer.transform.position.z != transform.position.z)))
        {
			
            //ball.GetComponent<ballScript>().isPass = true;
			camera.GetComponent<SmoothFollow>().target = otherplayer.transform;
            ball.GetComponent<ballScript>().isTaken = false;
            ball.GetComponent<passMove>().target = new Vector3(otherplayer.transform.position.x, otherplayer.transform.position.y + 1, otherplayer.transform.position.z);
            ball.GetComponent<passMove>().canmove = true;
			hasTar = false;

        }




    }
}
