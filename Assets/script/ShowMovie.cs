using UnityEngine;
using System.Collections;

public class ShowMovie : MonoBehaviour {

	public int firstFrame;
	public int finalFrame;
	public bool isSkipable;
	public string folder;
	public bool isPlaying = false;
	public bool isReady = false;
	private Texture2D[] textures;
	private Texture2D texture;
	private int ammount;
	private int i;

	public IEnumerator LoadMovie() {
		isReady = false;
		ammount = finalFrame - firstFrame;
		textures = Resources.LoadAll<Texture2D>(folder);
		while (textures.Length == 0) {
			yield return new WaitForEndOfFrame();
		}
		isReady = true;
	}

	void OnGUI() {
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), texture);
		if (Input.anyKeyDown && isSkipable) {
			i = ammount;
		}
	}


	public IEnumerator PlayMovie(int fps) {
		while (!isReady) {
			yield return new WaitForEndOfFrame();
		}
		isPlaying = true;
		for (i = 0; i <= ammount; i++) {
			texture = textures[i+firstFrame];
			yield return new WaitForSeconds(1.0f/fps);
		}
		isPlaying = false;
	}
}
