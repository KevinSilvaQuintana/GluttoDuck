using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {

    private AudioSource[] audioSources;

	void Start () {
        audioSources = this.gameObject.GetComponentsInChildren<AudioSource>();
	}

    public void Play(string audioName)
    {
        foreach(AudioSource a in audioSources)
        {
            if(a.clip.name == audioName)
            {
                a.Play();
            }
        }
    }
   	
}
