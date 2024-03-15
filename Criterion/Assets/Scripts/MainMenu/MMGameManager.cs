using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MMGameManager : MonoBehaviour
{
    [SerializeField]
    private Button btnStart;

    [SerializeField]
    private Button btnSettings;

    [SerializeField]
    private Button btnQuit;

    [SerializeField]
    private Button btnAnother;

    [SerializeField]
    private GameObject planeStart;

    [SerializeField]
    private GameObject planeSettings;

    [SerializeField]
    private GameObject planeQuit;

    [SerializeField]
    private GameObject planeAnother;

    private int position = 0;

    private int positionMax = 3;

    private int jumpPower = 6;

    [SerializeField]
    private GameObject cursor;

    [SerializeField]
    private Material selectedButtonMaterial;

    [SerializeField]
    private Material buttonMaterial;

    private bool canPass = true;

    private AudioSource menuSoundEffect;

    [SerializeField]
    private AudioClip menuPassSoundEffect;

    [SerializeField]
    private AudioClip menuEnterSoundEffect;

    [SerializeField]
    private AudioSource menuBackgroundMusic;

    private const string FINALLEVELSMENU = "LevelsMenu";
    private const string FINALSETTINGSMENU = "SettingsMenu";
    private const string FINALANOTHERSMENU = "AnotherMenu";


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        setVolume();
    }

    // Update is called once per frame
    void Update()
    {
        if(canPass)
        {
            if (Input.GetKeyUp(KeyCode.D))
            {
                if (position < positionMax)
                {
                    position++;
                    Vector3 direction = new Vector3(1f, 1f, 0f) * jumpPower;
                    cursor.GetComponent<Rigidbody>().AddForce(direction, ForceMode.Impulse);
                    canPass = false;
                    handleColorChanges();
                    playSoundeffect(menuPassSoundEffect);

                }
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                if (position > 0)
                {
                    position--;
                    Vector3 direction = new Vector3(-1f, 1f, 0f) * jumpPower;
                    cursor.GetComponent<Rigidbody>().AddForce(direction, ForceMode.Impulse);
                    handleColorChanges();
                    playSoundeffect(menuPassSoundEffect);
                }
            }
            else if(Input.GetKeyUp(KeyCode.Return))
            {
                playSoundeffect(menuEnterSoundEffect);
                Invoke(nameof(handleInteract), 1f);
            }
        }


    }

    private void handleColorChanges()
    {
        switch(position){
            default:
            case 0:
                btnStart.GetComponent<Image>().material = selectedButtonMaterial;
                planeStart.GetComponent<MeshRenderer>().material = selectedButtonMaterial;

                btnSettings.GetComponent<Image>().material = buttonMaterial;
                planeSettings.GetComponent<MeshRenderer>().material = buttonMaterial;

                btnQuit.GetComponent<Image>().material = buttonMaterial;
                planeQuit.GetComponent<MeshRenderer>().material = buttonMaterial;

                btnAnother.GetComponent<Image>().material = buttonMaterial;
                planeAnother.GetComponent<MeshRenderer>().material = buttonMaterial;

                break;

            case 1:
                btnStart.GetComponent<Image>().material = buttonMaterial;
                planeStart.GetComponent<MeshRenderer>().material = buttonMaterial;

                btnSettings.GetComponent<Image>().material = selectedButtonMaterial;
                planeSettings.GetComponent<MeshRenderer>().material = selectedButtonMaterial;

                btnQuit.GetComponent<Image>().material = buttonMaterial;
                planeQuit.GetComponent<MeshRenderer>().material = buttonMaterial;

                btnAnother.GetComponent<Image>().material = buttonMaterial;
                planeAnother.GetComponent<MeshRenderer>().material = buttonMaterial;

                break;

            case 2:
                btnStart.GetComponent<Image>().material = buttonMaterial;
                planeStart.GetComponent<MeshRenderer>().material = buttonMaterial;

                btnSettings.GetComponent<Image>().material = buttonMaterial;
                planeSettings.GetComponent<MeshRenderer>().material = buttonMaterial;

                btnQuit.GetComponent<Image>().material = selectedButtonMaterial;
                planeQuit.GetComponent<MeshRenderer>().material = selectedButtonMaterial;

                btnAnother.GetComponent<Image>().material = buttonMaterial;
                planeAnother.GetComponent<MeshRenderer>().material = buttonMaterial;

                break;

            case 3:
                btnStart.GetComponent<Image>().material = buttonMaterial;
                planeStart.GetComponent<MeshRenderer>().material = buttonMaterial;

                btnSettings.GetComponent<Image>().material = buttonMaterial;
                planeSettings.GetComponent<MeshRenderer>().material = buttonMaterial;

                btnQuit.GetComponent<Image>().material = buttonMaterial;
                planeQuit.GetComponent<MeshRenderer>().material = buttonMaterial;

                btnAnother.GetComponent<Image>().material = selectedButtonMaterial;
                planeAnother.GetComponent<MeshRenderer>().material = selectedButtonMaterial;

                break;
        }
        canPass = false;
        Invoke(nameof(setCanpass), 1.5f);
    }

    private void setCanpass()
    {
        this.canPass = true;
    }

    private void handleInteract()
    {
        switch(position)
        {
            case 0:
                SceneManager.LoadScene(FINALLEVELSMENU);
                break;
            case 1:
                SceneManager.LoadScene(FINALSETTINGSMENU);
                break;
            case 2:
                Application.Quit();
                break;
            case 3:
                Debug.Log("another");
                break;
        }
    }

    private void playSoundeffect(AudioClip soundEffect)
    {
        gameObject.GetComponent<AudioSource>().clip = soundEffect;
        gameObject.GetComponent<AudioSource>().Play();
    }


    private void setVolume()
    {
        gameObject.GetComponent<AudioSource>().volume=Settings.getSoundEffectVolume();
        menuBackgroundMusic.volume=Settings.getMusicVolume();
    }
}
