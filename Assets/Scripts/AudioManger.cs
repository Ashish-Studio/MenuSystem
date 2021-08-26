using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManger : MonoBehaviour {

    [SerializeField] AudioMixer themix;
	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("VolMx"))
        {
            themix.SetFloat("VolMx", PlayerPrefs.GetFloat("VolMx"));
            
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
