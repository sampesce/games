using UnityEngine;
using System.Collections;

public class menu : MonoBehaviour {
	public GUIStyle mystyle;
	public Texture bg;
	public Texture Title;
	public Texture Playgame;//single player
	public Texture multiplayer;//multiplayer
	public Texture Helpplay;//tutorial
	public Texture Options;//
	public Texture credits;//credits
	public Texture Quit;//quit
	float theight=300;
	float twidth=200;
	float gameoptionheight=150;
	float gameoptionwidth=100;
	int start=160;
	int sep=110;
	void Start () {
		//GUI.Box (new Rect(10,10,100,90),"Load menu");
		GUI.backgroundColor=Color.green;
		Camera.mainCamera.backgroundColor=Color.green;
	}
	void OnMouseOver(){
	}
	//draws the textures
	void drawmenu(){
		int space=100;
		GUI.DrawTexture(new Rect((Screen.width/2)-(twidth/2)-30,-25,theight,twidth),Title,ScaleMode.ScaleToFit);
		if(GUI.Button (new Rect((Screen.width/2)-(gameoptionwidth/2)-space,start,gameoptionheight,gameoptionwidth),Playgame)){
			Application.LoadLevel ("project5");
		}
		if(GUI.Button(new Rect((Screen.width/2)-(gameoptionwidth/2)-space,start+sep,gameoptionheight,gameoptionwidth),multiplayer)){
			//Application.loadleve("tutorial");
			//application load server
			//applicaton load network test
			Application.LoadLevel("networktest");
		}
		if(GUI.Button (new Rect((Screen.width/2)-(gameoptionwidth/2)-space,start+2*sep,gameoptionheight,gameoptionwidth),Options)){
			//application loadlevel("options");	
			//Application.LoadLevel("networktest");
			//
			Application.LoadLevel("options");
		}
		if(GUI.Button(new Rect((Screen.width/2)-(gameoptionwidth/2)+space,start,gameoptionheight,gameoptionwidth),Helpplay)){
			//application 
			//tutorial mode
			//Image with controls
			Application.LoadLevel("tutorial");
		}
		if(GUI.Button(new Rect((Screen.width/2)-(gameoptionwidth/2)+space,start+sep,gameoptionheight,gameoptionwidth),credits)){
			//Application.loadleve("tutorial");
			Application.LoadLevel("credits");
		}
		if(GUI.Button (new Rect((Screen.width/2)-(gameoptionwidth/2)+space,start+2*sep,gameoptionheight,gameoptionwidth),Quit)){
			Application.Quit();
		}
		
		
	}
	void OnGUI () {
		//GUI. (new Rect(10,10,100,100),"blockballtitle");
		//GUI.DrawTexture(new Rect(Screen.height/2+150,10,300,200),title);
		drawmenu();
	}
	
	// Update is called once per frame
	void Update () {
			
	}
}
