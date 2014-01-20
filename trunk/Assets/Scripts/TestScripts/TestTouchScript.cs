using UnityEngine;
using System.Collections;

public class TestTouchScript : MonoBehaviour {

    private TextMesh text;
	// Use this for initialization
	void Start () {
        text = GameObject.Find ("TouchText").GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
        int touches = Input.touches.Length;
        string str = "";

        for(int i = 0; i < Input.touches.Length; i++)
        {
            str += i + " -  ";
            str += Input.touches[i].phase + "\n";
        }
        text.text = "Touches: " + touches + "\n" + str;




	}
}
