using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="CharacterSO",menuName ="ScriptableObjects/CharacterScriptableObjects")]
public class CharacterSO : ScriptableObject
{
    [SerializeField]
    private string characterName;

    [SerializeField]
    private List<string> characterConversations;

    [SerializeField]
    private List<string> characterHelps;

    [SerializeField]
    private List<string> characterConversationAnswers;

    [SerializeField]
    private List<string> characterHelpAnswers;

    [SerializeField]
    private int missionNumber;

    [SerializeField]
    private List<string> solutionAnswers;

    [SerializeField]
    private List<string> apriciates;

    public string getName()
    {
        return characterName;
    }

    public List<string> getConversations()
    {
        return characterConversations;
    }

    public List<string> getHelps()
    {
        return characterHelps;
    }

    public List<string> getConversationAnswers()
    {
        return characterConversationAnswers;
    }

    public List<string> getHelpAnswers()
    {
        return characterHelpAnswers;
    }

    public int getMissionNumber()
    {
        return missionNumber;
    }

    public List<string> getSolutionAnswers()
    {
        return solutionAnswers;
    }

    public List<string> getApriciates()
    {
        return apriciates;
    }

}
