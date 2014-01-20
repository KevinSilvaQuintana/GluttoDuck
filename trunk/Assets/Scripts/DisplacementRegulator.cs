using UnityEngine;
using System.Collections;

public class DisplacementRegulator : MonoBehaviour {

    public float distance;
    private SpeedRegulator speedRegulator;
    private TextMesh textMesh;
    private float winningDistance = 2000;

	// Use this for initialization
	void Start () {

        textMesh = GameObject.Find ("DisplacementRegulator").GetComponent<TextMesh> ();
        speedRegulator = GameObject.Find ("SpeedRegulator").GetComponent<SpeedRegulator> ();
	}
	
	// Update is called once per frame
	void Update () {
	    
        distance += speedRegulator.velocity * Time.deltaTime;

        int distRemaining = (int)(winningDistance - distance);
        textMesh.text = "Distance to win : " + distRemaining; 

        //Win the game!
        if (distRemaining < 0) {
            Application.LoadLevel("Comic2");
        }
	}
}
