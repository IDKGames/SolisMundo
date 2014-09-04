using UnityEngine;
using System.Collections;

public class SunBehaviour : MonoBehaviour {

	private bool 	resizing = false;
	private Vector3	actualSize;
	private Vector3 nextSize;
	private float	currentTime = 0.0f;
	public float	sizingTime;
	public int resolution = 10;
	private ParticleSystem.Particle[] particles;
	private SphereCollider col;

	void Start() {
		col = GetComponent<SphereCollider>();
		particles = new ParticleSystem.Particle[resolution];
		float incremet = 1f / (resolution-1);
		for (int i = 0; i < resolution; i++) {
			float x = i * incremet;
			particles[i].position = new Vector3(x,x,0);
			particles[i].color = Color.yellow;
			particles[i].size = 0.1f;
		}
	}

	void Update(){
		particleSystem.SetParticles(particles, particles.Length);
		if (resizing) {
			currentTime += Time.deltaTime;
			transform.localScale = Vector3.Lerp(actualSize,nextSize, currentTime/sizingTime);
			if (currentTime >= sizingTime){
				currentTime = 0.0f;
				resizing = false;
			}
		}
	}
	
	void RecieveDamage(int damage){
		actualSize = transform.localScale;
		nextSize = actualSize + new Vector3 (0.2f * damage, 0.2f * damage, 0.2f * damage);
		resizing = true;
	}

	void OnCollisionEnter(Collision planet){
		if (planet.gameObject.CompareTag ("Player")) {
			Destroy(planet.gameObject);	
		}
		if(planet.gameObject.CompareTag ("Earth")) {
			planet.gameObject.SendMessage("RecieveDamage", 4);
		}
	}

	void FullHeal(){
		actualSize = transform.localScale;
		nextSize = new Vector3 (1, 1, 1);
		resizing = true;
	}
}
