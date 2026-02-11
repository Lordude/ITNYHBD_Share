using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class settings : MonoBehaviour
{
    public TMP_Dropdown graphicsDrop;
    public Slider volumeSlider;
    // public Toggle chromaticToggle, bloomToggle, grainToggle;
    public bool inGame;
    // public GameObject chromaticCam, bloomCam, grainCam;
    public AudioSource sfxButtonClick;

    void Start()
    {
        //graphics
        if(PlayerPrefs.GetInt("graphics") == 0)
        {
            graphicsDrop.value = 0;
            QualitySettings.SetQualityLevel(0);
        }
        if(PlayerPrefs.GetInt("graphics") == 1)
        {
            graphicsDrop.value = 1;
            QualitySettings.SetQualityLevel(1);
        }
        if(PlayerPrefs.GetInt("graphics") == 2)
        {
            graphicsDrop.value = 2;
            QualitySettings.SetQualityLevel(2);
        }

        //resolution
        // if(PlayerPrefs.GetInt("resolution") == 2)
        // {
        //     resoDrop.value = 0;
        //     Screen.SetResolution(854, 480, true);
        // }
        // if(PlayerPrefs.GetInt("resolution") == 1)
        // {
        //     resoDrop.value = 1;
        //     Screen.SetResolution(1280, 720, true);
        // }
        // if(PlayerPrefs.GetInt("resolution") == 0)
        // {
        //     resoDrop.value = 2;
        //     Screen.SetResolution(1920, 1080, true);
        // }

        //volume
        volumeSlider.value = PlayerPrefs.GetFloat("mastervolume");
        AudioListener.volume = PlayerPrefs.GetFloat("mastervolume");
    }
        //post FX
    //     if(PlayerPrefs.GetInt("chromatic") == 1)
    //     {
    //         chromaticToggle.isOn = true;
    //         if(inGame){
    //         chromaticCam.SetActive(true);
    //         }
    //     }
    //     if(PlayerPrefs.GetInt("chromatic") == 0)
    //     {
    //         chromaticToggle.isOn = false;
    //         if(inGame){
    //         chromaticCam.SetActive(false);
    //         }
    //     }
    //     if(PlayerPrefs.GetInt("bloom") == 1)
    //     {
    //         bloomToggle.isOn = true;
    //         if(inGame){
    //         bloomCam.SetActive(true);
    //         }
    //     }
    //     if(PlayerPrefs.GetInt("bloom", 0) == 0)
    //     {
    //         bloomToggle.isOn = false;
    //         if(inGame){
    //         bloomCam.SetActive(false);
    //         }
    //     }
        
    //     if(PlayerPrefs.GetInt("grain", 1) == 1)
    //     {
    //         grainToggle.isOn = true;
    //         if(inGame){
    //         grainCam.SetActive(true);
    //         }
    //     }
    //     if(PlayerPrefs.GetInt("grain", 0) == 0)
    //     {
    //         grainToggle.isOn = false;
    //         if(inGame){
    //         grainCam.SetActive(false);
    //         }
    //     }
    // }

    public void setGraphics()
    {
        if(graphicsDrop.value == 0)
        {
            PlayerPrefs.SetInt("graphics", 0);
            // PlayerPrefs.Save();
            QualitySettings.SetQualityLevel(0);
        }
        if(graphicsDrop.value == 1)
        {
            PlayerPrefs.SetInt("graphics", 1);
            // PlayerPrefs.Save();
            QualitySettings.SetQualityLevel(1);
        }
        if(graphicsDrop.value == 2)
        {
            PlayerPrefs.SetInt("graphics", 2);
            // PlayerPrefs.Save();
            QualitySettings.SetQualityLevel(2);
        }
    }

    // public void setResolution()
    // {
    //     if(resoDrop.value == 0)
    //     {
    //         PlayerPrefs.SetInt("resolution", 2);
    //         // PlayerPrefs.Save();
    //         Screen.SetResolution(854, 480, true);
    //     }
    //     if(resoDrop.value == 1)
    //     {
    //         PlayerPrefs.SetInt("resolution", 1);
    //         // PlayerPrefs.Save();
    //         Screen.SetResolution(1280, 720, true);
    //     }
    //     if(resoDrop.value == 0)
    //     {
    //         PlayerPrefs.SetInt("resolution", 0);
    //         // PlayerPrefs.Save();
    //         Screen.SetResolution(1920, 1080, true);
    //     }
    // }

    public void setVolume()
    {
        PlayerPrefs.SetFloat("mastervolume", volumeSlider.value);
        // PlayerPrefs.Save();
        AudioListener.volume = volumeSlider.value;
    }

    // public void toggleChromatic()
    // {
    //     if(chromaticToggle.isOn == false)
    //     {
    //         PlayerPrefs.SetInt("chromatic", 0);
    //         // PlayerPrefs.Save();
    //         if(inGame == true)
    //         {
    //             chromaticCam.SetActive(false);
    //         }
    //     }
    //     if(chromaticToggle.isOn == true)
    //     {
    //         PlayerPrefs.SetInt("chromatic", 1);
    //         // PlayerPrefs.Save();
    //         if(inGame == true)
    //         {
    //             chromaticCam.SetActive(true);
    //         }
    //     }
    // }

    // public void toggleBloom()
    // {
    //     if(bloomToggle.isOn == false)
    //     {
    //         PlayerPrefs.SetInt("bloom", 0);
    //         // PlayerPrefs.Save();
    //         if(inGame == true)
    //         {
    //             bloomCam.SetActive(false);
    //         }
    //     }
    //     if(bloomToggle.isOn == true)
    //     {
    //         PlayerPrefs.SetInt("bloom", 1);
    //         // PlayerPrefs.Save();
    //         if(inGame == true)
    //         {
    //             bloomCam.SetActive(true);
    //         }
    //     }
    // }

    // public void toggleGrain()
    // {
    //     if(grainToggle.isOn == false)
    //     {
    //         PlayerPrefs.SetInt("grain", 0);
    //         // PlayerPrefs.Save();
    //         if(inGame == true)
    //         {
    //             grainCam.SetActive(false);
    //         }
    //     }
    //     if(grainToggle.isOn == true)
    //     {
    //         PlayerPrefs.SetInt("grain", 1);
    //         // PlayerPrefs.Save();
    //         if(inGame == true)
    //         {
    //             grainCam.SetActive(true);
    //         }
    //     }
    // }

    public void saveSettings()
    {
        PlayerPrefs.SetInt("settingsSaved", 1);        
        PlayerPrefs.Save();
    }

    public void PlaySfxButtonClick()
    {
        sfxButtonClick.Play();
    }


}
