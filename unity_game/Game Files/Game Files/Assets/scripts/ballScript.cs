using UnityEngine;
using System.Collections;

public class ballScript : MonoBehaviour {

	// Use this for initialization
    public bool isTaken = false;
    public bool isPass = false;
	public bool scored=true;
	public GameObject[] listofplayer=new GameObject[10];
    Collider player;


    Vector3 adding = new Vector3(0, 1, 0);
    //Vector3 gravity = new Vector3(0, -1.0F, 0);

	void Start () {
		
		/*
		listofplayer[0]=new GameObject("player1");	
		listofplayer[1]=new GameObject("player2");
		listofplayer[2]=new GameObject("player3");
		listofplayer[3]=new GameObject("player4");
		listofplayer[4]=new GameObject("player5");
		
		listofplayer[5]=new GameObject("aiteam");
		listofplayer[6]=new GameObject("aiteam2");
		listofplayer[7]=new GameObject("aiteam3");
		listofplayer[8]=new GameObject("aiteam4");
		listofplayer[9]=new GameObject("aiteam5");
		*/
		
	}
	
	// Update is called once per frame
	void Update () {

        if (isTaken)
        {

            transform.position = player.transform.position + adding;
            transform.rotation = player.transform.rotation;

        }
		
		reset();
        /*
        if (Input.GetKey(KeyCode.Z) && isTaken)
        {

            isTaken = false;
            this.transform.Translate(Vector3.forward * 1F);
            //this.rigidbody.AddRelativeForce(transform.forward * 10F, ForceMode.Impulse);
            //Physics.gravity = new Vector3(0, -1.0F, 0);

        }
        */
	
	}

    void OnTriggerEnter(Collider hit)
    {
        if ((hit.tag == "player1" || hit.tag == "player2" || hit.tag == "player3" || hit.tag == "player4" || hit.tag == "player5"|| hit.tag== "aiteam" || hit.tag== "aiteam2" ||hit.tag== "aiteam3" || hit.tag== "aiteam4"|| hit.tag=="aiteam5" ) && !isPass)
        {
            //Debug.Log("yeah");
 
            isTaken = true;
            player = hit;
			//Debug.Log (hit.tag);
              //transform.position = hit.transform.position;
            //transform.parent = hit.transform;   
        }
		if(hit.tag == "goal"){
		
			transform.position = new Vector3(-36,3,-15);
			isTaken = false;
			scoreScript.score1++;
			Debug.Log("HIT THE GOAL");
			scored=true;
			
		}
		if(hit.tag == "goal2"){
		
			transform.position = new Vector3(-36,3,-15);
			isTaken = false;
			scoreScript.score1+=2;
			Debug.Log("HIT THE GOAL");
			scored=true;
		}
		if(hit.tag == "goal3"){
		
			transform.position = new Vector3(-36,3,-15);
			isTaken = false;
			scoreScript.score1+=3;
			Debug.Log("HIT THE GOAL");
			scored=true;
		}
		if(hit.tag == "goalb"){
		
			transform.position = new Vector3(-36,3,-15);
			isTaken = false;
			scoreScript.score2++;
			Debug.Log("HIT THE GOAL");
			scored=true;
		}
		if(hit.tag == "goal2b"){
		
			transform.position = new Vector3(-36,3,-15);
			isTaken = false;
			scoreScript.score2+=2;
			Debug.Log("HIT THE GOAL");
			scored=true;
			
		}
		if(hit.tag == "goal3b"){
		
			transform.position = new Vector3(-36,3,-15);
			isTaken = false;
			scoreScript.score2+=3;
			Debug.Log("HIT THE GOAL");
			scored=true;
			
		}
		//Application.LoadLevel("project5");
    }
	void reset(){
		if(scored){
			scored=false;
			int x1=-6;
			int x2=-63;
			int y=-5;
			for(int i=0;i<5;i++){
				if(i==1){
					listofplayer[i].transform.localPosition=new Vector3(x1,19,0);
					listofplayer[i+5].transform.localPosition=new Vector3(x2,19,0);
				}
				else{
					listofplayer[i].transform.localPosition=new Vector3(x1,19,y);
					listofplayer[i+5].transform.localPosition=new Vector3(x2,19,y);
					y-=5;
				}
			}
		}
	}
}
