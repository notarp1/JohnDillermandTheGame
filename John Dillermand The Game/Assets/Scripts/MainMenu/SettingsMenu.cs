using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer mixer;

    private Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;

    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> resolutionText = new List<string>();

        int resIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            resolutionText.Add(resolutions[i].width + "x" + resolutions[i].height);


            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                resIndex = i;
            }

        }


        resolutionDropdown.AddOptions(resolutionText);
        resolutionDropdown.value = resIndex;
        resolutionDropdown.RefreshShownValue();

    }


    public void setResolution(int resindex)
    {
        Screen.SetResolution(resolutions[resindex].width, resolutions[resindex].height, Screen.fullScreen);

    }

    public void setVolume(float volume)
    {
        mixer.SetFloat("volume", volume);
    }

    public void setQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

    public void setFullscreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
