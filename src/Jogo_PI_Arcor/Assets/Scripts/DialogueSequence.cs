using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct DialogueLine
{
    public CharacterData character; // Who is talking
    [TextArea(3, 5)] public string text; // What they are saying
}

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue/Sequence")]
public class DialogueSequence : ScriptableObject
{
    public List<DialogueLine> lines; // List of lines in the conversation
}