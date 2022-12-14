using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> _sentences;
    private Queue<string> _people;
    [SerializeField] private TextMeshProUGUI _textSentence;
    [SerializeField] private TextMeshProUGUI _textPerson;
    [SerializeField] private string _nextScene;
    [SerializeField] private GameObject _panel;

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        _panel.SetActive(true);

    }

    void Awake()
    {
        _sentences = new Queue<string>();
        _people = new Queue<string>();
        StartCoroutine(Wait());
    }

    public void StartDialogue(string[] sentences, string[] people)
    {
        _sentences.Clear();

        foreach(string sentence in sentences)
        {
            _sentences.Enqueue(sentence);
        }

        foreach(string person in people)
        {
            _people.Enqueue(person);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(_sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = _sentences.Dequeue();
        string person = _people.Dequeue();
        _textSentence.text = sentence;
        _textPerson.text = person;
    }

    private void EndDialogue()
    {
        SceneManager.LoadScene(_nextScene, LoadSceneMode.Single);
    }
}
