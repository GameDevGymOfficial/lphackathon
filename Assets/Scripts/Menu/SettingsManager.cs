using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();

        masterVolumeSlider.onValueChanged.AddListener(SetMasterVolume);
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    public void SetMasterVolume(float value)
    {
        AkSoundEngine.SetRTPCValue("MasterVolume", value);
    }
    public void SetMusicVolume(float value)
    {
        AkSoundEngine.SetRTPCValue("MusicVolume", value);
    }
    public void SetSFXVolume(float value)
    {
        AkSoundEngine.SetRTPCValue("SFXVolume", value);
    }
}
