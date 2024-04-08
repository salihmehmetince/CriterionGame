using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class L1InteractableSideCharacters : MonoBehaviour
{
    [SerializeField]
    private CharacterSO characterSO;
    private const string FINALPLAYER = "Player";

    private Animator animator;

    [SerializeField]
    private GameInput gameInput;

    private bool isRightChoice = false;

    [SerializeField]
    private string answer;
    private int maxAnswers = 6;
    private int answerIndex = 0;
    private string tryAnswer = "";

    [SerializeField]
    private Transform mainCharacter;

    private void Start()
    {
        animator = GetComponent<Animator>();
        gameInput.onChoose += onChoosed;
    }

    private void onChoosed(object sender, GameInput.onChooseEventArgs e)
    {
        if (e.Choose.x == 0 && e.Choose.y == 1 && e.Choose.z == 0)
        {
            Debug.Log("1");
            checkAnswer(1);
        }
        else if (e.Choose.x == 0 && e.Choose.y == -1 && e.Choose.z == 0)
        {
            Debug.Log("2");
            checkAnswer(2);
        }
        else if (e.Choose.x == -1 && e.Choose.y == 0 && e.Choose.z == 0)
        {
            Debug.Log("3");
            checkAnswer(3);
        }
        else if (e.Choose.x == 1 && e.Choose.y == 0 && e.Choose.z == 0)
        {
            Debug.Log("4");
            checkAnswer(4);
        }
        else if (e.Choose.x == 0 && e.Choose.y == 0 && e.Choose.z == 1)
        {
            Debug.Log("5");
            checkAnswer(5);
        }
        else if (e.Choose.x == 0 && e.Choose.y == 0 && e.Choose.z == -1)
        {
            Debug.Log("6");
            checkAnswer(6);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        GameObject gObject = other.gameObject;

        if (gObject.tag == FINALPLAYER)
        {
            recognizePlayer();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject gObject = other.gameObject;

        if (gObject.tag == FINALPLAYER)
        {
            forgetPlayer();
        }
    }
    private void recognizePlayer()
    {
        Transform speechBox = transform.GetChild(2);
        speechBox.gameObject.SetActive(true);
    }

    private void forgetPlayer()
    {
        Transform speechBox = transform.GetChild(2);
        speechBox.gameObject.SetActive(false);
    }

    public bool IsRightChoice
    {
        get { return isRightChoice; }
        set { isRightChoice = value; }
    }

    public string Answer
    {
        get { return answer; }
        set { answer = value; }
    }

    private void checkAnswer(int answer)
    {
        Debug.Log("index:"+answerIndex);
        if (answerIndex < maxAnswers-1)
        {
            answerIndex++;
            tryAnswer += answer.ToString();
            Debug.Log("index:" + answerIndex);
        }
        else if(answerIndex == maxAnswers - 1)
        {
            answerIndex++;
            tryAnswer += answer.ToString();

            if (this.answer == tryAnswer)
            {
                isRightChoice = true;
                Debug.Log("doðru yol");
                Debug.Log("index:" + answerIndex);
                return;
            }
            else
            {
                tryAnswer = "";
                answerIndex = 0;
                Debug.Log("yanlýþ yol");
                Debug.Log("index:" + answerIndex);
            }
        }
    }

    public CharacterSO getCharacterSO()
    {
        return characterSO;
    }

    public Animator getAnimator()
    {
        return animator;
    }
    
    public Transform getMainCharacter()
    {
        return mainCharacter;
    }
}
