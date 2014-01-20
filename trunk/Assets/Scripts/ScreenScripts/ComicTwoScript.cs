using UnityEngine;
using System.Collections;

public class ComicTwoScript : MonoBehaviour {

    private bool locked = true;
    private float timer = 0.5f;
    private int view = 0;

    void Update () {
        
        if(!locked)
        {
            if(Input.touches.Length > 0)
            {
                if(view < 3)
                {
                    view++;
                    this.gameObject.transform.Translate(new Vector3(8f,0f,0f));
                    locked = true;
                    timer = 0.5f;
                }
                else
                {
                    // Change scene
                    Application.LoadLevel ("Victory");
                }
            }
            if (Input.GetKey (KeyCode.Escape))
            {
                Application.LoadLevel ("Victory");
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
