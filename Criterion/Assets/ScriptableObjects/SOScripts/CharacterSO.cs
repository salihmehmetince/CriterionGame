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
}
