using UnityEngine;
using System.Collections;

public class SpeedDisplayScript : MonoBehaviour {

    private TextMesh speedDisplay;
    private SpeedRegulator speedScript;

    // Use this for initialization
    void Start () {
        speedDisplay = this.gameObject.GetComponent<TextMesh>();
        speedScript = this.gameObject.GetComponent<SpeedRegulator>();
    }
    
    // Update is called once per frame
    void Update () {
        speedDisplay.text = "Speed: " + (int)(speedScript.velocity) + " m/s";
    }
}
