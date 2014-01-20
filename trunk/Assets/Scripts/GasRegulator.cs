using UnityEngine;
using System.Collections;

public class GasRegulator : MonoBehaviour {

    public float gasAmount;

    private AudioController audioController;
    private Transform barFilling;
    private SpeedRegulator sRegulator;
    private float gas;
    private float MAX_GAS = 100.0f;
    private float INITIAL_GAS = 50.0f;
//    private float GAS_DEPLETE_RATIO = 0.3f;
    private bool canFart;

	void Start () {

        sRegulator = GameObject.Find ("SpeedRegulator").GetComponent<SpeedRegulator>();
        barFilling = GameObject.Find ("Gauge").GetComponent<Transform>();
        audioController = GameObject.Find ("AudioContainer").GetComponent<AudioController>();
        gas = INITIAL_GAS;
        canFart = true;
	}
	
	void Update () { 

        canFart = gas > 10f;

        if(Input.touches.Length > 0 && Input.touches[0].phase == TouchPhase.Began && canFart && gas > 0f)
        {
            sRegulator.SetFarting (true);
            audioController.Play ("Fart");
            audioController.Play ("AfterFart");
        }
        else if( Input.touches.Length == 0 || gas == 0f)
        {
            sRegulator.SetFarting (false);
        }


        if (sRegulator.GetFarting ())
        {
            gas = gas > 0 ? gas - 50.0f * Time.deltaTime : 0f;
        }

        DrawFilling (gas/MAX_GAS);

	}

    public void DrawFilling(float ratio){

        float xPosEmpty = -1.5f;
//        float xPosFull = 0.61f;
//        float xChange = 0.0211f;
//
        float yPos = -0.14f;
//
        float xScaEmpty = 0;
//        float xScaFull = 82;
//        float xScaleChange = 0.0082f;
//
//        float ySca = -0.5f;

        barFilling.localPosition = new Vector3( xPosEmpty + 2.11f * ratio,yPos,0);

        barFilling.localScale = new Vector3(xScaEmpty + 0.82f * ratio, -0.5f,0);
    }

    public void AdjustGas(GameObject obj)
    {
        switch (obj.name)
        {
        case "RainbowBooster":
        case "RainbowBooster(Clone)":
            break;
        case "SlowCloud":
        case "SlowCloud(Clone)":
            break;
        case "CandyA":
        case "CandyA(Clone)":
            gas += 2;
            break;
        case "CandyB":
        case "CandyB(Clone)":
            gas += 2;
            break;
        case "CandyC":
        case "CandyC(Clone)":
            gas += 2;
            break;
        case "Donut":
        case "Donut(Clone)":
            gas += 4;
            break;
        case "Lollipop":
        case "Lollipop(Clone)":
            gas += 3;
            break;
        default:
            break;
        }

        if( gas > 100f)
        {
            gas = 100f;
        }
    }
}