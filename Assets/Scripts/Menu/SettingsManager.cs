using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    private MenuManager menuManager;

    public static bool IsBinding { get; private set; }
    private int keyIndexToBind;

    [SerializeField] private TextMeshProUGUI[] keysTexts;

    private static KeyCode[] keys = new KeyCode[4];

    public static KeyCode Key1 => keys[0];
    public static KeyCode Key2 => keys[1];
    public static KeyCode Key3 => keys[2];
    public static KeyCode Key4 => keys[3];

    [SerializeField] private AK.Wwise.Event SecretEvent;
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;

    private void Awake()
    {
        menuManager = FindObjectOfType<MenuManager>();
        
        masterVolumeSlider.onValueChanged.AddListener(SetMasterVolume);
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 75);
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 75);
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume", 75);

        keys[0] = (KeyCode)PlayerPrefs.GetInt("key0", (int)KeyCode.D);
        keys[1] = (KeyCode)PlayerPrefs.GetInt("key1", (int)KeyCode.F);
        keys[2] = (KeyCode)PlayerPrefs.GetInt("key2", (int)KeyCode.J);
        keys[3] = (KeyCode)PlayerPrefs.GetInt("key3", (int)KeyCode.K);

        keysTexts[0].text = keys[0].ToString();
        keysTexts[1].text = keys[1].ToString();
        keysTexts[2].text = keys[2].ToString();
        keysTexts[3].text = keys[3].ToString();
    }

    private void OnGUI()
    {
        if (!IsBinding)
            return;

        Event e = Event.current;
        if (e.isKey)
        {
            if (e.keyCode == KeyCode.Escape)
            {
                EndBinding();
                return;
            }

            BindKey(e.keyCode, keyIndexToBind);
            EndBinding();
        }
    }


    public void SetMasterVolume(float value)
    {
        AkSoundEngine.SetRTPCValue("MasterVolume", value);
        PlayerPrefs.SetFloat("MasterVolume", value);
    }
    public void SetMusicVolume(float value)
    {
        AkSoundEngine.SetRTPCValue("MusicVolume", value);
        PlayerPrefs.SetFloat("MusicVolume", value);
    }
    public void SetSFXVolume(float value)
    {
        AkSoundEngine.SetRTPCValue("SFXVolume", value);
        PlayerPrefs.SetFloat("SFXVolume", value);
    }

    public void StartBind(int keyIndexToBind)
    {
        IsBinding = true;
        menuManager.EnableOverlay();
        this.keyIndexToBind = keyIndexToBind;
    }
    public void EndBinding()
    {
        menuManager.DisableOverlay();
        IsBinding = false;
        if((keys[0]==KeyCode.Alpha1 || keys[0] == KeyCode.Keypad1) && (keys[1] == KeyCode.Alpha9 || keys[1] == KeyCode.Keypad9) && (keys[2] == KeyCode.Alpha8 || keys[2] == KeyCode.Keypad8) && (keys[3] == KeyCode.Alpha5 || keys[3] == KeyCode.Keypad5))
        {
            Debug.Log("Secret");
            SecretEvent?.Post(gameObject);
        }
        Debug.Log("0:"+keys[0]);
        Debug.Log("1:"+keys[1]);
        Debug.Log("2:"+keys[2]);
        Debug.Log("3:"+keys[3]);
    }
    public void BindKey(KeyCode key, int keyIndex)
    {
        if (keyIndex >= 4)
            return;

        keys[keyIndex] = key;
        keysTexts[keyIndex].text = key.ToString();

        PlayerPrefs.SetInt("key" + keyIndex, (int)key);
    }
}
