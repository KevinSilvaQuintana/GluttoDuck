using UnityEngine;
using System.Collections;

public class GeneralRegulator : MonoBehaviour {

    private SpeedRegulator speedRegulator;
    private ScoreRegulator scoreRegulator;
    private AudioController audioController;
    private GasRegulator gasRegulator;
    private ComboRegulator comboRegulator;

	void Start () {
        speedRegulator = GameObject.Find ("SpeedRegulator").GetComponent<SpeedRegulator>();
        scoreRegulator = GameObject.Find ("ScoreRegulator").GetComponent<ScoreRegulator>();
        gasRegulator = GameObject.Find ("GasRegulator").GetComponent<GasRegulator>();
        audioController = GameObject.Find ("AudioContainer").GetComponent<AudioController>();
        comboRegulator = GameObject.Find ("ComboRegulator").GetComponent<ComboRegulator> ();

	}
	
    public void NotifyCollision(GameObject obj)
    {
        speedRegulator.AdjustSpeed (obj);
        scoreRegulator.AdjustScore (obj);
        comboRegulator.increaseCombo (obj);

        switch (obj.name)
        {
        case "RainbowBooster":
        case "RainbowBooster(Clone)":
            audioController.Play ("Boost");
            break;
        case "SlowCloud":
        case "SlowCloud(Clone)":
            audioController.Play ("Slip");
            break;
        case "CandyA":
        case "CandyA(Clone)":
        case "CandyB":
        case "CandyB(Clone)":
        case "CandyC":
        case "CandyC(Clone)":
        case "Donut":
        case "Donut(Clone)":
        case "Lollipop":
        case "Lollipop(Clone)":
            audioController.Play ("Crunch");
            gasRegulator.AdjustGas(obj);
            // Play an animation or something
            Destroy (obj);
            break;
        default:
            break;
        }
    }
}
