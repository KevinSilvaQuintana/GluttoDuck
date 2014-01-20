using UnityEngine;
using System.Collections;

public class ScorePostGame : MonoBehaviour {

    private TextMesh scoreTextMesh;
    private ScoreRegulator scoreRegulator;

	// Use this for initialization
	void Start () {
        scoreTextMesh = GameObject.Find ("ScoreTextMesh").GetComponent<TextMesh> ();
        scoreRegulator = GameObject.Find ("ScoreRegulator").GetComponent<ScoreRegulator> ();
	}
	
	// Update is called once per frame
	void Update () {
        scoreTextMesh.text = "Score: " + scoreRegulator.score;
	}
}
