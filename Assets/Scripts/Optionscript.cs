using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class Optionscript : MonoBehaviour {

    [SerializeField] Toggle FullScreenToggle;
    [SerializeField] Toggle VsyncToggle;

    [SerializeField] Resolutionitem[] Resolution;
    [SerializeField] int SelectedResolution;

    [SerializeField] Text ResolutionLabel;

    [SerializeField] AudioMixer VolMixer;
    public Slider VolumeSlider;
    public Text VolumeText;

    [SerializeField] AudioSource sfxloop;
    // Use this for initialization
    void Start()
    {
        FullScreenToggle.isOn = Screen.fullScreen;

        if (QualitySettings.vSyncCount == 0)
        {
            VsyncToggle.isOn = false;
        }
        else
        {
            VsyncToggle.isOn = true;
        }

        bool FoundRes = false;
        for(int i = 0; i < Resolution.Length; i++)
        {
            if(Screen.width==Resolution[i].ResolutionHorizontal && Screen.height == Resolution[i].ResolutionVertical)
            {
                FoundRes = true;

                SelectedResolution = i;
                ResolutionText();
            }
        }

        if (!FoundRes)
        {
            ResolutionLabel.text = Screen.width.ToString() + "X" + Screen.height.ToString();
            
        }

        if (PlayerPrefs.HasKey("VolMx"))
        { 
            VolMixer.SetFloat("VolMx", PlayerPrefs.GetFloat("VolMx"));
            VolumeSlider.value = PlayerPrefs.GetFloat("VolMx");
        }
       


    }

    // Update is called once per frame
    void Update() {

    }

    public void ResLeft()
    {
        SelectedResolution = SelectedResolution - 1;
        if (SelectedResolution < 0)
        {
            SelectedResolution = 0;
        }
        ResolutionText();
    }

    public void Resright()
    {
        SelectedResolution = SelectedResolution + 1;
        if (SelectedResolution > Resolution.Length-1)
        {
            SelectedResolution = Resolution.Length-1;
        }
        ResolutionText();
    }

    void ResolutionText()
    {
        ResolutionLabel.text = Resolution[SelectedResolution].ResolutionHorizontal.ToString() + "X"
                                + Resolution[SelectedResolution].ResolutionVertical.ToString();
    }

    public void Applygraphics()
    {
        //for fullscreen
        //Screen.fullScreen = FullScreenToggle.isOn;

        //For vsync
        if (VsyncToggle.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }

        //for resolution and fullscreen
        Screen.SetResolution(Resolution[SelectedResolution].ResolutionHorizontal,
            Resolution[SelectedResolution].ResolutionVertical, FullScreenToggle.isOn);

    }

    public void MusicVolume()
    {
        VolumeText.text = (VolumeSlider.value+80).ToString();
        VolMixer.SetFloat("VolMx", VolumeSlider.value);

        PlayerPrefs.SetFloat("VolMx", VolumeSlider.value);
    }

    public void PlaySfxloop()
    {
        sfxloop.Play();
    }
    public void StopSfxloop()
    {
        sfxloop.Stop();
    }
}

[System.Serializable]
public class Resolutionitem
{
    public int ResolutionHorizontal, ResolutionVertical;
}
