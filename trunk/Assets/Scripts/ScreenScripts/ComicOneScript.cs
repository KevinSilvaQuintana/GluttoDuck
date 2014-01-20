using UnityEngine;
using System.Collections;

public class ComicOneScript : MonoBehaviour {

    private bool locked = true;
    private float timer = 0.5f;
    private int view = 0;

    void Update () {

        if(!locked)
        {
            if(Input.touches.Length > 0)
            {
                if(view < 2)
                {
                    view++;
                    this.gameObject.transform.Translate(new Vector3(8f,0f,0f));
                    locked = true;
                    timer = 0.5f;
                }
                else
                {
                    Application.LoadLevel("GameScene 3");
                }   
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
