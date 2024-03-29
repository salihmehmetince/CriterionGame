using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsMenuManager : MonoBehaviour
{
    private int rowsLength = 5;
    private int columnsLength = 6;

    [SerializeField]
    private GameObject levelPrefab;

    [SerializeField]
    private Transform levelsTexts;

    private int selectedLevelIndex = 0;

    [SerializeField]
    private Transform levels;

    [SerializeField]
    private TextMeshProUGUI selectedLevelText;

    private AudioSource levelSoundEffect;

    [SerializeField]
    private AudioClip levelPassSoundEffect;

    [SerializeField]
    private AudioClip levelEnterSoundEffect;

    [SerializeField]
    private AudioSource levelsBackgroundMusic;

    [SerializeField]
    private Image menu;

    private bool isMenuOpen = false;

    [SerializeField]
    private Button btnMainMenu;

    [SerializeField]
    private Button btnSettingsMenu;

    [SerializeField]
    private Button btnQuit;

    private const string FINALMANINMENU = "MainMenu";

    private const string FINALSETTINGSMENU = "SettingsMenu";

    [SerializeField]
    private Image backButton;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        setButtons();
        setVolume();
        levelSoundEffect = GetComponent<AudioSource>();
       for(int i=0;i<rowsLength;i++)
        {
            for (int j = 1; j < columnsLength; j++)
            {
                Vector3 addition = new Vector3(-12f,-10f,0f);
                Vector3 position = new Vector3(j*5,i*5,25f)+addition;
                GameObject level =Instantiate(levelPrefab);
                level.transform.position = position;
                level.transform.SetParent(levels);
                Transform canvas = level.transform.GetChild(0);
                GameObject levelText = canvas.GetChild(0).gameObject;
                levelText.GetComponent<TextMeshProUGUI>().text = (rowsLength * i + j).ToString();
                canvas.transform.SetParent(levelsTexts);
                canvas.transform.position = new Vector3(canvas.transform.position.x,canvas.transform.position.y,canvas.transform.position.z-0.5f);
            }
        }
        levels.GetChild(0).GetComponent<LMCursor>().enabled = true;
        selectedLevelText.text = "Selected level:" + (selectedLevelIndex + 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            levels.GetChild(selectedLevelIndex).GetComponent<LMCursor>().enabled = false;
            levels.GetChild(selectedLevelIndex).rotation = Quaternion.identity;
            if(selectedLevelIndex-1>=0)
            {
                selectedLevelIndex = selectedLevelIndex - 1;

            }

            levels.GetChild(selectedLevelIndex).GetComponent<LMCursor>().enabled = true;
            selectedLevelText.text = "Selected level:" + (selectedLevelIndex + 1);
            playSoundEffect(levelPassSoundEffect);

        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            levels.GetChild(selectedLevelIndex).GetComponent<LMCursor>().enabled = false;
            levels.GetChild(selectedLevelIndex).rotation = Quaternion.identity;
            if (selectedLevelIndex + 1<(rowsLength*(columnsLength-1)))
            {
                selectedLevelIndex = selectedLevelIndex + 1;

            }
            levels.GetChild(selectedLevelIndex).GetComponent<LMCursor>().enabled = true;
            selectedLevelText.text = "Selected level:" + (selectedLevelIndex + 1);
            playSoundEffect(levelPassSoundEffect);

        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            levels.GetChild(selectedLevelIndex).GetComponent<LMCursor>().enabled = false;
            levels.GetChild(selectedLevelIndex).rotation = Quaternion.identity;
            if (selectedLevelIndex + columnsLength - 1 < (rowsLength * (columnsLength - 1)))
            {
                selectedLevelIndex = selectedLevelIndex + columnsLength - 1;

            }
            levels.GetChild(selectedLevelIndex).GetComponent<LMCursor>().enabled = true;
            selectedLevelText.text = "Selected level:" + (selectedLevelIndex + 1);
            playSoundEffect(levelPassSoundEffect);

        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            levels.GetChild(selectedLevelIndex).GetComponent<LMCursor>().enabled = false;
            levels.GetChild(selectedLevelIndex).rotation = Quaternion.identity;
            if (selectedLevelIndex - columnsLength + 1 >= 0)
            {
                selectedLevelIndex = selectedLevelIndex - columnsLength + 1;
            }
            levels.GetChild(selectedLevelIndex).GetComponent<LMCursor>().enabled = true;
            selectedLevelText.text = "Selected level:" + (selectedLevelIndex + 1);
            playSoundEffect(levelPassSoundEffect);
        }
        else if(Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log(selectedLevelIndex+1+".seviyeye girildi");
            playSoundEffect(levelEnterSoundEffect);
            Invoke(nameof(handleInteract), 1f);
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            isMenuOpen = !isMenuOpen;
            menu.gameObject.SetActive(isMenuOpen);
            changeBackButtonColor();
        }

    }

    private void playSoundEffect(AudioClip soundEffect)
    {
        gameObject.GetComponent<AudioSource>().clip = soundEffect;
        gameObject.GetComponent<AudioSource>().Play();
    }

    private void handleInteract()
    {
        SceneManager.LoadScene("Level"+(selectedLevelIndex+1)+"StoryScene");
        Debug.Log("Level" + (selectedLevelIndex + 1) + "StoryScene");

    }

    private void setVolume()
    {
        gameObject.GetComponent<AudioSource>().volume = Settings.getSoundEffectVolume();
        levelsBackgroundMusic.volume = Settings.getMusicVolume();
    }

    private void setButtons()
    {
        btnMainMenu.onClick.AddListener(()=> { SceneManager.LoadScene(FINALMANINMENU); });
        btnSettingsMenu.onClick.AddListener(() => { SceneManager.LoadScene(FINALSETTINGSMENU); });
        btnQuit.onClick.AddListener(quit);
    }

    private void quit()
    {
        Application.Quit();
    }

    private void changeBackButtonColor()
    {
        if(isMenuOpen==true)
        {
            Cursor.lockState = CursorLockMode.None;
            backButton.color = new Color32(0x00,0xD2,0xFF,0xFF);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            backButton.color = Color.white;
        }
    }
}
