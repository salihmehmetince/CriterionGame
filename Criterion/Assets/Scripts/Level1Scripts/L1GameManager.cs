using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class L1GameManager : MonoBehaviour
{
    [SerializeField]
    private Button GOPlayAgainButton;

    [SerializeField]
    private Button GOMainMenuButton;

    [SerializeField]
    private Button pausedPlayAgainButton;

    [SerializeField]
    private Button pausedMainMenuButton;

    [SerializeField]
    private Button pausedSettingsButton;

    [SerializeField]
    private Slider soundEffectSlider;

    [SerializeField]
    private Slider musicSlider;

    private const string FINALMAINMENU = "MainMenu";

    private const string FINALSETTINGSMENU = "SettingsMenu";

    private static float soundEffectVolume = 0.5f;

    private static float musicVolume = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        GOPlayAgainButton.onClick.AddListener(playAgain);
        GOMainMenuButton.onClick.AddListener(goMainMenu);
        pausedPlayAgainButton.onClick.AddListener(playAgain);
        pausedMainMenuButton.onClick.AddListener(goMainMenu);
        pausedSettingsButton.onClick.AddListener(goSettingsMenu);
        soundEffectVolume = PlayerPrefs.GetFloat("soundEffectVolume");
        musicVolume = PlayerPrefs.GetFloat("musicVolume");
        soundEffectSlider.value = soundEffectVolume;
        musicSlider.value = musicVolume;
        soundEffectSlider.onValueChanged.AddListener(delegate { changeSoundEffectVolume(); });
        musicSlider.onValueChanged.AddListener(delegate { changeMusicVolume(); });
    }

    private void playAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;  
    }

    private void goMainMenu()
    {
        SceneManager.LoadScene(FINALMAINMENU);
    }

    private void goSettingsMenu()
    {
        SceneManager.LoadScene(FINALSETTINGSMENU);
    }

    private void changeMusicVolume()
    {
        musicVolume = musicSlider.value;
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
        PlayerPrefs.Save();
    }

    private void changeSoundEffectVolume()
    {
        soundEffectVolume = soundEffectSlider.value;
        PlayerPrefs.SetFloat("soundEffectVolume", soundEffectVolume);
        PlayerPrefs.Save();
    }
}
