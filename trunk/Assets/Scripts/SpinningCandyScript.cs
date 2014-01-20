using UnityEngine;
using System.Collections;

public class SpinningCandyScript : MonoBehaviour {

    private float spinRate;
    private float direction;

    void Start()
    {
        spinRate = Random.Range (90, 275);
        direction = Random.Range(0,2) == 0 ? -1 : 1;
    }

	void Update () {
        transform.Rotate(new Vector3(0,0, Time.deltaTime * spinRate * direction));
	}
}
