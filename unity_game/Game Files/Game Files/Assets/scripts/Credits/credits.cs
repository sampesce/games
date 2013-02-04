using UnityEngine;
using System.Collections;

public class credits : MonoBehaviour {

	// Use this for initialization
	public Texture menu;
	public GUIStyle mstyle;
	//public GUIStyle mstyle2;
	void Start () {
		GUI.backgroundColor=Color.green;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){
		GUI.Label(new Rect(Screen.width/2,0,200,200),"Credits",mstyle);
		GUI.Label(new Rect(50,100,200,200),"-Dhaman Mehta",mstyle);
		GUI.Label (new Rect(50,130,200,200),"-Brian Shepard",mstyle);
		GUI.Label(new Rect(50,160,200,200),"-Sam Pesce",mstyle);
		GUI.Label(new Rect(50,190,200,200),"-Joe Flynn",mstyle);
		//new Rect(
		if(GUI.Button(new Rect(50,230,150,150),menu)){
			Application.LoadLevel("Menu");
		}
	}
}
