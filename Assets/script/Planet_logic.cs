using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Planet_logic : MonoBehaviour {

	private Transform trans;
	public float distance;
	public float angle;
	public int actual_hit_points;
	public int max_hit_points;
	public int sH_star;
	public Texture bonus;

	void Awake () {
		trans = transform;
		distance = Vector3.Distance(trans.position, new Vector3(0,0, trans.position.z));
		actual_hit_points = max_hit_points;
	}

	void Update () {
		trans.position = new Vector3((Mathf.Cos(angle)*distance), (Mathf.Sin(angle)*distance), trans.position.z);
	}

	void Move(float tangenV){
		float angleV = tangenV/distance;
		angle +=angleV;
	}

	void Init(float tangenV) {
		float angleV = tangenV/distance;
		angle += angleV*Random.Range(1000,5000);;
	}

	void RecieveDamage(int damage) {
		actual_hit_points -= damage;
		if (actual_hit_points <= 0) {
			actual_hit_points = 1;
			collider.enabled = false;
			renderer.enabled = false;
			GameObject.FindGameObjectWithTag("Logic").GetComponent<GameLogic>().score -= 20;
			if (this.name == "Earth") {
				Application.LoadLevel("MainMenu");
			}
		}
	}

	void Heal(int ammount) {
		actual_hit_points += ammount;
		if (actual_hit_points > max_hit_points) {
			actual_hit_points = max_hit_points;
		}
		if(this.tag == "Earth"){
			sH_star += 1;
		}
	}

	void OnGUI(){
		switch (sH_star){
		case 0:
			break;
		case 1:
			GUI.DrawTexture(new Rect(Screen.width*0.825f,Screen.height*0.91f,Screen.width*0.13f,Screen.height*0.13f), bonus);
			break;
		case 2:
			GUI.DrawTexture(new Rect(Screen.width*0.825f,Screen.height*0.91f,Screen.width*0.13f,Screen.height*0.13f), bonus);
			GUI.DrawTexture(new Rect(Screen.width*0.807f,Screen.height*0.84f,Screen.width*0.13f,Screen.height*0.13f), bonus);
			break;
		case 3:
			GUI.DrawTexture(new Rect(Screen.width*0.825f,Screen.height*0.91f,Screen.width*0.13f,Screen.height*0.13f), bonus);
			GUI.DrawTexture(new Rect(Screen.width*0.807f,Screen.height*0.84f,Screen.width*0.13f,Screen.height*0.13f), bonus);
			GUI.DrawTexture(new Rect(Screen.width*0.82f,Screen.height*0.76f,Screen.width*0.13f,Screen.height*0.13f), bonus);
			break;
		case 4:
			GUI.DrawTexture(new Rect(Screen.width*0.825f,Screen.height*0.91f,Screen.width*0.13f,Screen.height*0.13f), bonus);
			GUI.DrawTexture(new Rect(Screen.width*0.807f,Screen.height*0.84f,Screen.width*0.13f,Screen.height*0.13f), bonus);
			GUI.DrawTexture(new Rect(Screen.width*0.82f,Screen.height*0.76f,Screen.width*0.13f,Screen.height*0.13f), bonus);
			GUI.DrawTexture(new Rect(Screen.width*0.865f,Screen.height*0.7f,Screen.width*0.13f,Screen.height*0.13f), bonus);
			break;
		default:
			GUI.DrawTexture(new Rect(Screen.width*0.825f,Screen.height*0.91f,Screen.width*0.13f,Screen.height*0.13f), bonus);
			GUI.DrawTexture(new Rect(Screen.width*0.807f,Screen.height*0.84f,Screen.width*0.13f,Screen.height*0.13f), bonus);
			GUI.DrawTexture(new Rect(Screen.width*0.82f,Screen.height*0.76f,Screen.width*0.13f,Screen.height*0.13f), bonus);
			GUI.DrawTexture(new Rect(Screen.width*0.865f,Screen.height*0.7f,Screen.width*0.13f,Screen.height*0.13f), bonus);
			GUI.DrawTexture(new Rect(Screen.width*0.909f,Screen.height*0.704f,Screen.width*0.13f,Screen.height*0.13f), bonus);
			break;
		}
	}

	void FullHeal(){
		actual_hit_points = max_hit_points;
		collider.enabled = true;
		renderer.enabled =true;
	}
	
}