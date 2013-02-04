using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
	int xpos;
	int ypos;
	int zpos;
	int height;//might be y scale value
	int player;
	bool wall;//is a wall
	// Use this for initialization
	GameObject currentcube;
	
	float time;
	
	public int blockLevel = 0;
	
	bool incremented = false;
	
	public Tile(int x,int y,int z){
		xpos=x;
		ypos=y;
		zpos=z;
	}
	void Start () {
		//Debug.Log ("butterfly");
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("got there");
		
		if(blockLevel > 0){
		
			if(time + 5 < Time.time){
			
				transform.localScale=new Vector3(transform.localScale.x,transform.localScale.y - 1f,transform.localScale.z);
				
				time = Time.time;
				
				blockLevel--;
				
			}
			
		}
		
		
		checkiftouch();
		
		
	}
	
	public void checkiftouch(){
		//Debug.Log ("water");
		
		
		if(Input.GetMouseButtonUp(0)){
			//Debug.Log("watermelon");
			Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray,out hit,100)){
				//Debug.Log ("got here");
				if(hit.collider.gameObject == this.gameObject && blockLevel < 6){
					
					currentcube=hit.collider.gameObject;
					//currentcube=GameObject.FindGameObjectWithTag("Field");
					Debug.Log (hit.collider.tag);
					//currentcube.transform.localScale.Set(currentcube.transform.localScale.x,10,currentcube.transform.localScale.z);
					//currentcube.transform.localScale+=new Vector3(0,15,0);
					//Destroy (currentcube);
					currentcube.transform.localScale=new Vector3(currentcube.transform.localScale.x,currentcube.transform.localScale.y + 1f,currentcube.transform.localScale.z);
					
					incremented = true;
					
					blockLevel++;
					//currentcube.GetComponent<Tile>().blockLevel++;
					time = Time.time;
					
					Debug.Log("thizazada");
					
				}
			}
		}
		else{
			//Debug.Log ("ballon animal");
		}
	}
	
}
