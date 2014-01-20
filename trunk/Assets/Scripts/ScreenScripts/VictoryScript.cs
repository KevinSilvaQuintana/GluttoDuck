using UnityEngine;
using System.Collections;

public class VictoryScript : MonoBehaviour {

    private bool locked = true;
    private float timer = 0.5f;

    private ScoreRegulator scoreRegulator;

    void Start ()
    {
        scoreRegulator = GameObject.Find ("ScoreRegulator").GetComponent<ScoreRegulator> ();
    }

    void Update () {


        if(!locked)
        {
            if(Input.touches.Length > 0)
            {
                //Destroy (scoreRegulator);
                Application.LoadLevel("TitleScreen");
            }
            if (Input.GetKey (KeyCode.Escape))
            {
                Application.Quit ();
            }
        }
        else
        {
            timer -= Time.deltaTime;
            if(timer < 0)
            {
                locked = false;
            }
        }
    }
}
