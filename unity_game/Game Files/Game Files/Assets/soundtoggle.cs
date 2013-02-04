using UnityEngine;
using System.Collections;

public class soundtoggle : MonoBehaviour {

	// Use this for initialization
	public bool soundon;
	void Start () {
		soundon=true;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.Q)){
			soundon=!soundon;	
			playsound();
		}
	
	}
	void playsound(){
		if(soundon){
			audio.Play();	
		}
		else{
			audio.Stop();	
		}
	}
}
