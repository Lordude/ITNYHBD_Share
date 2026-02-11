using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class postFXinit : MonoBehaviour
{
    public TMP_Dropdown graphicsDrop, resoDrop;
    public Slider volumeSlider;
    public Toggle chromaticToggle, bloomToggle, grainToggle;
    public bool inGame;
    public GameObject chromaticCam, bloomCam, grainCam;
    public AudioSource sfxButtonClick;
    // Start is called before the first frame update
    void Start()
    {
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
        if(PlayerPrefs.GetInt("resolution") == 2)
        {
            resoDrop.value = 0;
            Screen.SetResolution(854, 480, true);
        }
        if(PlayerPrefs.GetInt("resolution") == 1)
        {
            resoDrop.value = 1;
            Screen.SetResolution(1280, 720, true);
        }
        if(PlayerPrefs.GetInt("resolution") == 0)
        {
            resoDrop.value = 2;
            Screen.SetResolution(1920, 1080, true);
        }

        //volume
        volumeSlider.value = PlayerPrefs.GetFloat("mastervolume");
        AudioListener.volume = PlayerPrefs.GetFloat("mastervolume");

        //post FX
        if(PlayerPrefs.GetInt("chromatic") == 1)
        {
            chromaticToggle.isOn = true;
            if(inGame){
            chromaticCam.SetActive(true);
            }
        }
        if(PlayerPrefs.GetInt("chromatic") == 0)
        {
            chromaticToggle.isOn = false;
            if(inGame){
            chromaticCam.SetActive(false);
            }
        }
        if(PlayerPrefs.GetInt("bloom") == 1)
        {
            bloomToggle.isOn = true;
            if(inGame){
            bloomCam.SetActive(true);
            }
        }
        if(PlayerPrefs.GetInt("bloom", 0) == 0)
        {

            bloomToggle.isOn = false;
            if(inGame){
            bloomCam.SetActive(false);
            }
        }
        
        if(PlayerPrefs.GetInt("grain", 1) == 1)
        {
            grainToggle.isOn = true;
            if(inGame){
            grainCam.SetActive(true);
            }
        }
        if(PlayerPrefs.GetInt("grain", 0) == 0)
        {
            grainToggle.isOn = false;
            if(inGame){
            grainCam.SetActive(false);
            }
        }
        
    }


}
