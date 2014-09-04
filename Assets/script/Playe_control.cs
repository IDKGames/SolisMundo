using UnityEngine;
using System.Collections;

public class Playe_control : MonoBehaviour {

	public GameObject planets;
	public GameObject cosa;
	public GameObject Earth;
	public GameObject Sun;
	public float speed =0.5f;
	private GameLogic gL;
	private Planet_logic pL;

	void Start (){
		foreach(Transform p in planets.transform){
			p.gameObject.SendMessage("Init", speed);
		}
		gL = GetComponent<GameLogic>();
		pL = Earth.GetComponent<Planet_logic>();
	}
	
	void Update () {
		if(Input.GetKey(KeyCode.LeftArrow)){
			foreach(Transform p in planets.transform){
				p.gameObject.SendMessage("Move", speed);
				cosa.transform.Rotate(0,-0.3f,0);
			}
		}
		if(Input.GetKey(KeyCode.RightArrow)){
			foreach(Transform p in planets.transform){
				p.gameObject.SendMessage("Move", -speed);
				cosa.transform.Rotate(0,0.3f,0);
			}
		}
		Debug.Log(gL.cD_timer <= 0 && pL.sH_star >= 5);
		if(gL.cD_timer <= 0 && pL.sH_star >= 5){
			if(Input.GetKey(KeyCode.Z)){
				gL.cD_timer = gL.cD;
				pL.sH_star = 0;
				foreach(Transform p in planets.transform){
					p.gameObject.SendMessage("FullHeal");
				}
				Sun.SendMessage("FullHeal");
			}
		}
	}
}
