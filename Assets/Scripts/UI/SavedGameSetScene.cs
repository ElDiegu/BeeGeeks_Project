using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedGameSetScene : MonoBehaviour
{
    [SerializeField] private GameObject _savedWarning;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DeactivateWarning();
        }
    }

    public void DeactivateWarning()
    {
        _savedWarning.SetActive(false);
    }
}
