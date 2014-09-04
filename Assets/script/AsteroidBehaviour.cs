using UnityEngine;
using System.Collections;

public class AsteroidBehaviour : MonoBehaviour {

	private Transform 	trans;
	private GameObject	sun;
	private float		radius;
	public float 		speed;
	public float 		speed_angle;
	public int 			damage;
	public float		smallProbablility;
	public float		mediumProbablility;
	public float		bigProbnability;
	private float		randomSize;
	private bool		isPlayed = false;

	void Start(){
		trans = transform;
		sun = GameObject.FindGameObjectWithTag ("Sun");
		randomSize = Random.Range(0.0f,smallProbablility + mediumProbablility + bigProbnability);
		if (randomSize < bigProbnability) {
			this.transform.localScale = this.transform.localScale * 2.0f;
			speed = speed * 0.5f;
			damage = damage * 3;	
		} else if (randomSize < bigProbnability + mediumProbablility) {
			this.transform.localScale = this.transform.localScale * 1.5f;
			speed = speed * 0.75f;
			damage = 2;
		}
		radius = sun.GetComponent<SphereCollider> ().radius;
		trans.LookAt(new Vector3(Random.Range(-radius*sun.transform.localScale.x,radius*sun.transform.localScale.x/2),Random.Range(-radius*sun.transform.localScale.x,radius*sun.transform.localScale.x/2),0.0f));
	}

	// Update is called once per frame
	void Update () {
		trans.position += trans.forward*speed;
		trans.Rotate (0, 0, speed_angle * Time.deltaTime);
		if (isPlayed && !audio.isPlaying)
			Destroy (this.gameObject);
	}

	void OnCollisionEnter (Collision collision){
		if (collision.gameObject.CompareTag ("Player") || collision.gameObject.CompareTag ("Earth")|| collision.gameObject.CompareTag ("Sun")) {
			audio.Play();
			isPlayed = true;
			collision.gameObject.SendMessage("RecieveDamage",damage);
			gameObject.renderer.enabled = false;
			gameObject.collider.enabled = false;
			if (collision.gameObject.CompareTag("Player")) {
				GameObject.FindGameObjectWithTag("Logic").GetComponent<GameLogic>().score += 10;
			}
		}
	}
}
