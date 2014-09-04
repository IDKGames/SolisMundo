using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameLogic : MonoBehaviour {

	public GameObject	planets;
	public GameObject 	asteroid;
	public GameObject	shootingStar;
	private float		asteroidCreationEventTime = 2.0f;
	private float		asteroidCreationCurrentTime = 0.0f;
	public float		xLimit = 16.0f;
	public float		yLimit = 12.0f;
	private int			randomLimit;
	//private int			level = 1;
	private float		timePlayed;
	public float		timeNextLevel;
	//public float		smallProbablility;
	//public float		smallProbablility;
	public GUIText		timer;
	public Texture[] 	hud;
	private Planet_logic[] moons;
	public float cD_timer;
	public float cD;
	public int score = 0;

	
	void Start(){
		List<Planet_logic> m = new List<Planet_logic>();
		foreach(Transform p in planets.transform){
			m.Add(p.GetComponent<Planet_logic>());
		}
		moons = m.ToArray();
		cD_timer = cD;
	}
	
	void OnGUI(){
		GUI.Label(new Rect(Screen.width*0.061f,Screen.height*0.18f,Screen.width*0.07f,Screen.height*0.05f), (moons[0].actual_hit_points-1).ToString());
		GUI.Label(new Rect(Screen.width*0.061f,Screen.height*0.28f,Screen.width*0.07f,Screen.height*0.05f), (moons[1].actual_hit_points-1).ToString());
		GUI.Label(new Rect(Screen.width*0.061f,Screen.height*0.36f,Screen.width*0.07f,Screen.height*0.05f), (moons[2].actual_hit_points-1).ToString());
		GUI.Label(new Rect(Screen.width*0.061f,Screen.height*0.45f,Screen.width*0.07f,Screen.height*0.05f), (moons[3].actual_hit_points-1).ToString());
		GUI.Label(new Rect(Screen.width*0.061f,Screen.height*0.53f,Screen.width*0.07f,Screen.height*0.05f), (moons[4].actual_hit_points-1).ToString());
		GUI.Label(new Rect(Screen.width*0.061f,Screen.height*0.61f,Screen.width*0.07f,Screen.height*0.05f), (moons[5].actual_hit_points-1).ToString());
		GUI.Label(new Rect(Screen.width*0.061f,Screen.height*0.69f,Screen.width*0.07f,Screen.height*0.05f), (moons[6].actual_hit_points-1).ToString());
		GUI.Label(new Rect(Screen.width*0.061f,Screen.height*0.78f,Screen.width*0.07f,Screen.height*0.05f), (moons[7].actual_hit_points-1).ToString());
		GUI.Label(new Rect(Screen.width*0.9f, Screen.height*0.56f, Screen.width*0.08f,Screen.height*0.05f), System.Convert.ToInt32(timePlayed/60).ToString());
		GUI.Label(new Rect(Screen.width*0.95f, Screen.height*0.59f, Screen.width*0.08f,Screen.height*0.05f), System.Convert.ToInt32(timePlayed).ToString());
		GUI.Label(new Rect(Screen.width*0.89f, Screen.height*0.03f, Screen.width, Screen.height), GameObject.FindGameObjectWithTag("Logic").GetComponent<GameLogic>().score.ToString());
	}
	
	void OnDrawGizmos() {
		Gizmos.color = Color.red;
		Gizmos.DrawLine(new Vector3(-xLimit,yLimit,0), new Vector3(xLimit, yLimit, 0));
		Gizmos.DrawLine(new Vector3(-xLimit,-yLimit,0), new Vector3(xLimit, -yLimit, 0));
		Gizmos.DrawLine(new Vector3(xLimit,yLimit,0), new Vector3(xLimit, -yLimit, 0));
		Gizmos.DrawLine(new Vector3(-xLimit,yLimit,0), new Vector3(-xLimit, -yLimit, 0));
	}
	
	
	// Update is called once per frame
	void Update () {
		//Tira asteroides cada "asteroidCreationEventTime" segundos
		timePlayed += Time.deltaTime;

		if(cD_timer > 0){
			cD_timer -= Time.deltaTime;
		}

		//if (timePlayed >= timeNextLevel * level) {
		//	level += 1;
		//	Debug.Log(level);
		//}
		asteroidCreationCurrentTime += Time.deltaTime;

		if (asteroidCreationCurrentTime >= asteroidCreationEventTime) {
			asteroidCreationCurrentTime = 0.0f;
			randomLimit = Random.Range(1,4);
			Instantiate(shootingStar,new Vector3(Random.Range(xLimit*-1,xLimit),yLimit),Quaternion.identity);
			switch (randomLimit){
			case 1:
				Instantiate(asteroid,new Vector3(Random.Range(xLimit*-1,xLimit),yLimit),Quaternion.identity);
				break;
			case 2:
				Instantiate(asteroid,new Vector3(xLimit,Random.Range(yLimit*-1,yLimit)),Quaternion.identity);
				break;
			case 3:
				Instantiate(asteroid,new Vector3(Random.Range(xLimit*-1,xLimit),yLimit*-1),Quaternion.identity);
				break;
			case 4:
				Instantiate(asteroid,new Vector3(xLimit*-1,Random.Range(yLimit*-1,yLimit)),Quaternion.identity);
				break;
			}
		}
	}
}
