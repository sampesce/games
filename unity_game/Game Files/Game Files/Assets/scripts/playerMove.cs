using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour {


    public GameObject player;
	public GameObject goal;
	public GameObject ball;
	public GameObject playertofollow;
	public GameObject camera=null;
    float speed = 10.0f;
    float jumpForce = 5.0f;
    public bool hasBall = false;

	// Use player for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void aimethod(){
		if(ball.transform.position.x==-36 && ball.transform.position.z==-15){
			transform.LookAt(ball.transform);
			transform.Translate(Vector3.forward * 0.07F);
			//Debug.Log ();
		}
		else if(ball.transform.position.x==transform.position.x && ball.transform.position.z==transform.position.z){
			//Debug.Log(GetComponent<playerMove>().hasBall);
			Debug.Log("water here");
			transform.LookAt(goal.transform);
			transform.Translate(Vector3.forward * 0.05F);		
		}
		else if(ball.transform.position.x!=transform.position.x && ball.transform.position.z!=transform.position.z){
			transform.LookAt(playertofollow.transform);
			if((playertofollow.transform.position.x-transform.position.x)*(playertofollow.transform.position.x-transform.position.x)+(playertofollow.transform.position.z-transform.position.z)*(playertofollow.transform.position.z-transform.position.z)<10){
				transform.Translate(Vector3.forward * -0.01F);
			}
			else{
				transform.Translate(Vector3.forward *.05f);
			}
			
		}	
	}
	void FixedUpdate () {
		//Debug.Log(transform.gameObject);
		//Debug.Log(camera.GetComponent<SmoothFollow>().target);
		///*this==camera.GetComponent<SmoothFollow>().target*/hasBall){
		if(camera.GetComponent<SmoothFollow>().target.CompareTag(this.tag)){
	        if (Input.GetKey(KeyCode.A))
	        {
	
	            player.transform.Rotate(Vector3.down * 3);
	
	        }
	        if (Input.GetKey(KeyCode.D))
	        {
	
	            player.transform.Rotate(Vector3.up * 3);
	
	        }
	        if (Input.GetKey(KeyCode.W))
	        {
	
	            player.transform.Translate(Vector3.forward * 0.09F);
	
	        }
	        if (Input.GetKey(KeyCode.S))
	        {
	
	            player.transform.Translate(Vector3.back * 0.09F);
	
	        }
	
	        if (Input.GetKeyUp(KeyCode.Space) && Physics.Raycast(transform.position, -transform.up, 2))
	        {
	            player.rigidbody.AddRelativeForce(transform.up * jumpForce, ForceMode.Impulse);
	            //player.transform.Translate(Vector3.up * 1F);
	        }
		}	
		else{
			aimethod();
		}
 
    

	
	}
}
