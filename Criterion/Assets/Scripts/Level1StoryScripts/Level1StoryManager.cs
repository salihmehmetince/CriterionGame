using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level1StoryManager : MonoBehaviour
{
    private string storyFilePath = Application.dataPath+"\\Story\\Story.txt";
    private string[] rows;

    [SerializeField]
    private TextMeshProUGUI storyText;

    [SerializeField]
    private Button nextButton;

    private int index = 0;

    [SerializeField]
    private Transform character;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        rows=File.ReadAllLines(storyFilePath);
        storyText.text=rows[index];
        nextButton.onClick.AddListener(readNext);
        character.position = new Vector3(-80f + (((float)index / rows.Length) * 100f),character.position.y,character.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void readNext()
    {
        if(index >= rows.Length-2)
        {
            Transform nextbuttonText=nextButton.transform.GetChild(0);
            nextbuttonText.GetComponent<TextMeshProUGUI>().text = "Start";
        }
        if(index < rows.Length-1)
        {
            index++;
            storyText.text=rows[index];
            character.position = Vector3.Lerp(character.position,new Vector3(-80f + ((130f/(rows.Length))*index), character.position.y, character.position.z),1f);
        }
        else
        {
            SceneManager.LoadScene("Level1Scene");
        }
    }
}
