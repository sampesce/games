using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

	// Use this for initialization
	public Texture menu;
	public GUIStyle mstyle;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){
		GUI.Label(new Rect(0,0,100,100),"Controls",mstyle);
		GUI.Label(new Rect(0, 50,100,100),"Move=W,A,S,D",mstyle);
		GUI.Label (new Rect(0,100,200,200),"Throw=Click Player+t",mstyle);
		GUI.Label (new Rect(0,150,100,100),"Jump=Spacebar",mstyle);
		if(GUI.Button(new Rect(0,230,150,150),menu)){
			Application.LoadLevel("Menu");
		}
	}
}
