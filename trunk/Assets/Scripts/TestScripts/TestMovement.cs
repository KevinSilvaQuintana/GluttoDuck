using UnityEngine;
using System.Collections;

public class TestMovement : MonoBehaviour
{
    private GameObject myHoldingObject;
    private Transform myTransform;
//    private Transform cameraTransform;

    public float x;
    public float y;
    public float speed;

    void Awake ()
    {
        myHoldingObject = this.gameObject;

        myTransform = myHoldingObject.GetComponent<Transform> ();

        speed = 15.0f;
    }

    // Use this for initialization
    void Start ()
    {
//        cameraTransform = GameObject.Find ("Main Camera").GetComponent<Transform>();
        Debug.Log ("Movement instantiated");
    }

    // Update is called once per frame

    void Update ()
    {

        float accX = Input.acceleration.x;
//        float accY = Input.acceleration.y;

//        if (Input.GetButton ("Up")) {
//            myTransform.Translate (Vector3.up * Time.deltaTime * speed);
//        } else if (accY > 0.1f) {
//            myTransform.Translate (Vector3.up * Time.deltaTime * speed * Mathf.Abs(accY));
//        } else if (Input.GetButton ("Down")) {
//            myTransform.Translate (Vector3.down * Time.deltaTime * speed);
//        } else if (accY < -0.1f) {
//            myTransform.Translate (Vector3.down * Time.deltaTime * speed * Mathf.Abs(accY));
//        }
        if (Input.GetButton ("Left")) {
            myTransform.Translate (Vector3.left * Time.deltaTime * speed);
        } else if (accX < -0.15f) {
            myTransform.Translate (Vector3.left * Time.deltaTime * speed * Mathf.Abs(accX));
        } else if (Input.GetButton ("Right")) {
            myTransform.Translate (Vector3.right * Time.deltaTime * speed);
        } else if (accX > 0.15f) {
            myTransform.Translate (Vector3.right * Time.deltaTime * speed * Mathf.Abs(accX));
        }

        if (Application.platform == RuntimePlatform.Android) {
            if (Input.GetKey (KeyCode.Escape)) {
                Application.Quit ();
            }
        }

        myTransform.position = new Vector3(Mathf.Clamp(myTransform.position.x, -4, 4), myTransform.position.y, myTransform.position.z);
    }
}
