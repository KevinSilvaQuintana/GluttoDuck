using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

    public float deadZone;
    public float hSpeed;
    public float hBorder;

    private Transform myTransform;
//    private SpeedRegulator regulator;
	// Use this for initialization
	void Start ()
    {
        myTransform = this.gameObject.transform;
//        regulator = GameObject.Find ("SpeedRegulator").GetComponent<SpeedRegulator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float accX = Input.acceleration.x;

        if (Input.GetButton ("Left")) {
            myTransform.Translate (Vector3.left * Time.deltaTime * hSpeed);
        } else if (accX < -deadZone) {
            myTransform.Translate (Vector3.left * Time.deltaTime * hSpeed * Mathf.Abs(accX));
        } else if (Input.GetButton ("Right")) {
            myTransform.Translate (Vector3.right * Time.deltaTime * hSpeed);
        } else if (accX > deadZone) {
            myTransform.Translate (Vector3.right * Time.deltaTime * hSpeed * Mathf.Abs(accX));
        }

        if (Application.platform == RuntimePlatform.Android) {
            if (Input.GetKey (KeyCode.Escape)) {
                Application.LoadLevel ("TitleScreen");
            }
        }

        //regulator.SetFarting(Input.touches.Length > 0 || Input.GetButton ("Action"));

        myTransform.position = new Vector3(Mathf.Clamp(myTransform.position.x, -hBorder, hBorder), myTransform.position.y, myTransform.position.z);
	}
}
