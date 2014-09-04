using UnityEngine;
using System.Collections;

public class ShootingStarBehaviour : MonoBehaviour {

	private GameObject	earth;
	public float		speed;

	// Use this for initialization
	void Start () {
		earth = GameObject.FindGameObjectWithTag ("Earth");
		transform.LookAt (earth.transform);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.forward * speed;
	}

	void OnCollisionEnter (Collision collision){
		if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Earth")) {
			collision.gameObject.SendMessage("Heal",1);
			if (collision.gameObject.CompareTag("Earth")) {
				GameObject.FindGameObjectWithTag("Logic").GetComponent<GameLogic>().score += 5;
			}
			Destroy(this.gameObject);
		}
		else if (collision.gameObject.CompareTag("Sun")) {
			Destroy(this.gameObject);
		}
	}
}
