using UnityEngine;
using System.Collections;

public class TestPhoneAngle : MonoBehaviour {

    private TextMesh text;
    // Use this for initialization
    void Start () {
        text = this.gameObject.GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update () {
        float x = Input.acceleration.x;
        float y = Input.acceleration.y;
        float z = Input.acceleration.z;

        text.text = "X: " + x + "\nY: " + y + "\nZ: " + z;
    }
}
