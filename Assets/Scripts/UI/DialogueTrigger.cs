using System.Collections;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueManager _dialogueManager;

    [TextArea(1, 10)]
    [SerializeField] private string[] _sentences;
    [SerializeField] private string[] _people;

    public void Start()
    {
        _dialogueManager.StartDialogue(_sentences, _people);
    }
}
