using UnityEngine;
using System.Collections;

public class Main_menu : MonoBehaviour {

	bool activateMenu = false;
	bool movieHasPlayed = false;
	int phase = 0;
	public Texture[] bg;
	public Texture text;
	public Texture[] options = new Texture[3];
	private Color test;
	private ShowMovie movie;

	void Awake() {
		movie = GetComponent<ShowMovie>();
		movie.isSkipable = true;
		StartCoroutine(movie.LoadMovie());
		StartCoroutine(movie.PlayMovie(24));
		movieHasPlayed = true;
	}

	void OnGUI(){
		if (activateMenu) {
			switch (phase) {
			case 0:
				GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), bg[0]);
				GUI.color = test;
				GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), text);
				break;
			case 1:
				GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), bg[1]);
				GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), options[0]);
				GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), options[1]);
				GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), options[2]);
				break;
			}
		}
	}

	void Update() {
		Color aColor = GUI.color;
		aColor.a = (Mathf.Sin(Time.time)/2) + 0.5f;
		test = aColor;
		if (!movie.isPlaying && movieHasPlayed) {
			activateMenu = true;
			movieHasPlayed = false;
		}
		if (Input.anyKeyDown && activateMenu && phase == 0) {
			activateMenu = false;
			movie.firstFrame = 0;
			movie.folder = "menu2";
			movie.finalFrame = 18;
			movie.isSkipable = false;
			StartCoroutine(movie.LoadMovie());
			StartCoroutine(movie.PlayMovie(24));
			movieHasPlayed = true;
			phase = 1;
		}
		if (Input.GetKeyDown(KeyCode.Return) && activateMenu && phase == 1) {
			Application.LoadLevel("Intro");
		}
	}
}
