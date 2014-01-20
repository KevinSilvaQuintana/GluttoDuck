using UnityEngine;
using System.Collections;

public class GameOverSreenScript : MonoBehaviour {

    private TextMesh loseTextMesh;
    private ScoreRegulator scoreRegulator;

    private float angle = 0f;
    private float angularSpeed = 3.14f;

	// Use this for initialization
	void Start () {
//        scoreRegulator = GameObject.Find ("ScoreRegulator").GetComponent<ScoreRegulator> ();       
	}
	
	// Update is called once per frame
	void Update () {

        angle += angularSpeed * Time.deltaTime;        
        float factor = Mathf.Abs (Mathf.Sin (angle));        
        transform.localScale = new Vector3(1.35f + factor * 0.3f, 1.35f+factor * 0.3f, 0);

        if(Input.touches.Length > 0)
        {
            Application.LoadLevel("TitleScreen");
        }
        if (Input.GetKey (KeyCode.Escape))
        {
            Application.LoadLevel("TitleScreen");
        }
	}
}
