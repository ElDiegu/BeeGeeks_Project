using System.Collections;
using UnityEngine;

public class SetScreenTemporarily : MonoBehaviour
{
    [SerializeField] private GameObject _screen;
    public void ActivateScreenTemporarily()
    {
        _screen.SetActive(true);
        StartCoroutine(DeactivateScreen());
    }

    IEnumerator DeactivateScreen()
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(0.5f);
        _screen.SetActive(false);
        Debug.Log("yield return");
        Time.timeScale = 0;
    }
}
