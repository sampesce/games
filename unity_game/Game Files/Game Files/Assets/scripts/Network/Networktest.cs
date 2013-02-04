using UnityEngine;
using System.Collections;

public class Networktest : MonoBehaviour {
	public string IP="127.0.0.1";
	public int Port=25003;
	public GameObject target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){
		if(Network.peerType==NetworkPeerType.Disconnected){
			if(GUI.Button(new Rect(100,100,100,25),"Start Client")){
				Network.Connect(IP,Port);	
			}
			if(GUI.Button(new Rect(100,125,100,25),"Start Server")){
				Network.InitializeServer(2,Port);
			}
		}
		else{
			if(Network.peerType==NetworkPeerType.Client){
				GUI.Label(new Rect(100,100,100,25),"Client");
				if(GUI.Button(new Rect(100,125,100,25),"Start Game")){
					networkView.RPC ("Changelevel",RPCMode.All);
					//networkView.RPC ("netupdate",RPCMode.All);
				}
				if(GUI.Button(new Rect(100,150,100,25),"Log out")){
					Network.Disconnect(250);	
				}
			}
			if(Network.peerType==NetworkPeerType.Server){
				GUI.Label(new Rect(100,100,100,25),"Server");
				GUI.Label(new Rect(100,125,100,25),"Connections "+Network.connections.Length);
				
				if(GUI.Button(new Rect(100,150,100,25),"Log out")){
					Network.Disconnect(250);	
				}
			}
		}
	}
	[RPC]
	void Changelevel(){
		Application.LoadLevel("multigame");	
	}
	/*[RPC]
	void Changecolor(){
		target.renderer.material.color=Color.green;	
	}*/
	[RPC]
	void update(){	
	}
}

