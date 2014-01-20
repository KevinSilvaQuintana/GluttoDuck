using UnityEngine;
using System.Collections;

public class TitleScreenScript : MonoBehaviour {

    private float angle = 0f;
    private float angularSpeed = 3.14f;
	
    private bool locked = true;
    private float timer = 0.8f;


    void Start(){
        GameObject myReg = GameObject.Find ("ScoreRegulator");
        if (myReg != null) {
            Destroy(myReg);
        }
    }
	
	void Update () {

        angle += angularSpeed * Time.deltaTime;

        float factor = Mathf.Abs (Mathf.Sin (angle));

        transform.localScale = new Vector3(1.35f + factor * 0.3f, 1.35f+factor * 0.3f, 0);

        if(!locked)
        {
            if(Input.touches.Length > 0)
            {
                Application.LoadLevel("Comic1");
            }
            if (Application.platform == RuntimePlatform.Android)
            {
                if (Input.GetKey (KeyCode.Escape))
                {
                    Application.Quit ();
                }
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
