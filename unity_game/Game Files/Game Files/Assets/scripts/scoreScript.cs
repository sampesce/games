using UnityEngine;
using System.Collections;

public class scoreScript : MonoBehaviour {

	
	public static int score1 = 0;
	public static int score2 = 0;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(score1 > 10 || score2 > 10){
		
			Application.LoadLevel("winscreen");
			
		}
	
	}
	
	void OnGUI(){
	
		GUI.TextArea(new Rect(0,550,150,30), "Red: "+ score1 + "     Blue: " + score2);
		
	}
	
}
