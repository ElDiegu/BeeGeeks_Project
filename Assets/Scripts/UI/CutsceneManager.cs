using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour
{
    [TextArea(1, 10)]
    [SerializeField] private string[] _sentences;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GameObject _panel;

    private int _idx = 0;
    private float _initialTime = 0;
    private bool _textAppear = false;
    private bool _textDisappear = false;

    void Start()
    {
        StartCoroutine(NextSentence());
    }

    IEnumerator NextSentence()
    {
        yield return new WaitForSeconds(1);
        _panel.SetActive(true);

        for (int i = 0; i < _sentences.Length; i++)
        {
            _textDisappear = false;
            _textAppear = true;
            _initialTime = Time.time;
            _text.color = new Color(1, 1, 1, 0);
            _text.text = _sentences[_idx];
            _idx++;

            yield return new WaitForSeconds(7);
            _textAppear = false;
            _textDisappear = true;
            _initialTime = Time.time;
            yield return new WaitForSeconds(3);
        }

        SceneManager.LoadScene("DialogueLevel1", LoadSceneMode.Single);
    }

    void TextAppear()
    {
        if (Time.time - _initialTime < 2) // makes Progress property of shader go from 1 to 0 in the span of 1 second
        {
            float i = (Time.time - _initialTime)/2;
            _text.color = new Color(1, 1, 1, i);
        }
    }

    void TextDisappear()
    {
        if (Time.time - _initialTime < 2) // makes Progress property of shader go from 1 to 0 in the span of 1 second
        {
            float i = 1 - ((Time.time - _initialTime)/2);
            _text.color = new Color(1, 1, 1, i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_textAppear)
        {
            TextAppear();
        }

        if (_textDisappear)
        {
            TextDisappear();
        }
        
    }
}
