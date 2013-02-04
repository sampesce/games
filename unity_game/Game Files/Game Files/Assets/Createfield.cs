using UnityEngine;
using System.Collections;

public class Createfield : MonoBehaviour {

	// Use this for initialization
	public GameObject cube;
	public GameObject field;
	void Start () {
		//Debug.Log ("started");
		//cube.GetComponent<Tile>().checkiftouch();
		//Destroy(requiredobject);
		//don't delete bad things happen 
		//change scale to 0,0,0
		GameObject rq=GameObject.Find ("Plane");
		Destroy (rq);
		for(int x=-80;x<20;x+=5){
			for(int z=-50;z<20;z+=5){
				if(x==-80||x==15){
					//Instantiate(cube,new Vector3(x,0,z), new Quaternion(0f,0f,0f,0f));
					//currentcube.transform.localScale=new Vector3(currentcube.transform.localScale.x,currentcube.transform.localScale.y - 0.01f,currentcube.transform.localScale.z);
					//cube.transform.localScale=new Vector3(cube.transform.localScale.x,cube.transform.localScale.y5,cube.transform.localScale.z);
					//cube.transform.localScale=new Vector3(cube.transform.localScale.x,cube.transform.localScale.y *10,cube.transform.localScale.z);
				}
				else{
					//Instantiate(cube,new Vector3(x,0,z), new Quaternion(0f,0f,0f,0f));
				}
				Instantiate(cube,new Vector3(x,0,z), new Quaternion(0f,0f,0f,0f));
				//cube.tag="Cube-";
				//GameObject.FindObjectOfType("Cube (Clone)").name="Cube"+x+"-"+z;
			}
		}
		GameObject requiredobject=GameObject.Find ("Cube");
		requiredobject.transform.localScale=new Vector3(0,0,0);
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("started");
		
	}
}
