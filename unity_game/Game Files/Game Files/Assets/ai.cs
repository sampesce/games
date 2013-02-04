using UnityEngine;
using System.Collections;

public class ai : MonoBehaviour {

	// Use this for initialization
	//bool offensive=false;
	public GameObject playertofollow;
	public GameObject goal;
	public GameObject ball;
	public GameObject[] listofteamates= new GameObject[4];
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//spreadteammates();
		if(ball.transform.position.x==-36 && ball.transform.position.z==-15){
			transform.LookAt(ball.transform);
			//spreadteammates();
			transform.Translate(Vector3.forward * 0.07F);
			//Debug.Log ();
		}
		else if(ball.transform.position.x==transform.position.x && ball.transform.position.z==transform.position.z){
			//Debug.Log(GetComponent<playerMove>().hasBall);
			//Debug.Log("water here");
			transform.LookAt(goal.transform);
			transform.Translate(Vector3.forward * 0.07F);		
		}
		else if(ball.transform.position.x!=transform.position.x && ball.transform.position.z!=transform.position.z){
			//transform.LookAt(playertofollow.transform);
			//transform.LookAt(ball.transform);
			//spreadteammates();
			if(teammatehasball()){
				spreadteammates();
				transform.LookAt(goal.transform);
				transform.Translate(Vector3.forward *.07f);
			}
			else{
				spreadteammates();
				transform.LookAt(ball.transform);
				transform.Translate(Vector3.forward*.09f);
			}
				/*else{
					transform.LookAt(playertofollow.transform);
					transform.LookAt(Vector3.forward*.05f);
				}*/
				/*if((listofteamates[i].transform.position.x-transform.position.x)*(listofteamates[i].transform.position.x-transform.position.x)-(listofteamates[i].transform.position.z-transform.position.z)*(listofteamates[i].transform.position.x-transform.position.x)<40){
					transform.Translate(Vector3.back*.025f);
				}*/	
			}	
	}
	void spreadteammates(){
		for(int i=0;i<listofteamates.Length;i++){
				//transform.LookAt(listofteamates[i].transform);
				/*if((listofteamates[i].transform.position.x-transform.position.x)*(listofteamates[i].transform.position.x-transform.position.x)+ (listofteamates[i].transform.position.z-transform.position.z)*(listofteamates[i].transform.position.z-transform.position.z)<100){
					transform.LookAt(listofteamates[i].transform);
					transform.Translate(Vector3.back*05f);
					listofteamates[i].transform.LookAt(this.transform);
					listofteamates[i].transform.Translate(Vector3.back*.05f);
					//transform.LookAt(goal.transform);
					//transform.Translate(Vector3.forward *.5f);
					//return true;
				}*/
				if(Vector3.Distance(listofteamates[i].transform.position,this.transform.position)<10){
					transform.LookAt(listofteamates[i].transform);
					transform.Translate(Vector3.back*.05f);
				}	
				
		}	
	}
	bool teammatehasball(){
		for(int i=0;i<listofteamates.Length;i++){
				//transform.LookAt(listofteamates[i].transform);
				if(listofteamates[i].transform.position.x==ball.transform.position.x&& listofteamates[i].transform.position.z==ball.transform.position.z){
					//transform.LookAt(goal.transform);
					//transform.Translate(Vector3.forward *.5f);
					return true;
				}
		}
		return false;
	}
}
