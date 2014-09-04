using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	bool movieHasPlayed = false;
	private ShowMovie movie;
	Texture tex;

	void Awake() {
		movie = GetComponent<ShowMovie>();
		movie.isSkipable = false;
		StartCoroutine(movie.LoadMovie());
		StartCoroutine(movie.PlayMovie(12));
		movieHasPlayed = true;
	}

	void Update() {
		if (movieHasPlayed && !movie.isPlaying) {
			Application.LoadLevel("Game");
		}
	}
}
