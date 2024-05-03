using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    private static float soundEffectVolume;
    private static float musicVolume;

    [SerializeField]
    private Slider soundEffectSlider;

    [SerializeField]
    private Slider musicSlider;

    [SerializeField]
    private Button btnOpenMusic;

    [SerializeField]
    private Button btnCloseMusic;

    [SerializeField]
    private Button btnOpenSoundEffect;

    [SerializeField]
    private Button btnCloseSoundEffect;

    [SerializeField]
    private Button btnBack;

    private const string FINALMAINMENU="MainMenu";

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        soundEffectVolume = PlayerPrefs.GetFloat("soundEffectVolume");
        musicVolume = PlayerPrefs.GetFloat("musicVolume");
        soundEffectSlider.value = soundEffectVolume;
        musicSlider.value = musicVolume;
        soundEffectSlider.onValueChanged.AddListener(delegate { changeSoundEffectVolume(); });
        musicSlider.onValueChanged.AddListener(delegate { changeMusicVolume(); });
        btnOpenSoundEffect.onClick.AddListener(openSoundEffect) ;
        btnOpenSoundEffect.onClick.AddListener(closeSoundEffect);
        btnOpenMusic.onClick.AddListener(openMusic);
        btnCloseMusic.onClick.AddListener(closeMusic);
        btnBack.onClick.AddListener(goBack);
    }
    private void changeSoundEffectVolume()
    {
        soundEffectVolume=soundEffectSlider.value;
        PlayerPrefs.SetFloat("soundEffectVolume",soundEffectVolume);
        PlayerPrefs.Save();
    }

    private void changeMusicVolume()
    {
        musicVolume = musicSlider.value;
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
        PlayerPrefs.Save();
    }

    private void openMusic()
    {
        musicVolume = 1f;
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
        PlayerPrefs.Save();
        musicSlider.value = musicVolume;

    }

    private void closeMusic()
    {
        musicVolume = 0f;
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
        PlayerPrefs.Save();
        musicSlider.value = musicVolume;

    }

    private void openSoundEffect()
    {
        soundEffectVolume = 1f;
        PlayerPrefs.SetFloat("soundEffectVolume", soundEffectVolume);
        PlayerPrefs.Save();
        musicSlider.value = soundEffectVolume;

    }

    private void closeSoundEffect()
    {
        soundEffectVolume = 0f;
        PlayerPrefs.SetFloat("soundEffectVolume", soundEffectVolume);
        PlayerPrefs.Save();
        musicSlider.value = soundEffectVolume;

    }

    public static float getMusicVolume()
    {
        musicVolume= PlayerPrefs.GetFloat("musicVolume");
        return musicVolume;
    }

    public static float getSoundEffectVolume()
    {
        soundEffectVolume = PlayerPrefs.GetFloat("soundEffectVolume");
        return soundEffectVolume;
    }

    private void goBack()
    {
        SceneManager.LoadScene(FINALMAINMENU);
    }
}
