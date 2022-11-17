using UnityEngine;

public class SetScreenActive : MonoBehaviour
{
    [SerializeField] private GameObject _screen;
    public void ActivateScreen()
    {
        _screen.SetActive(true);
    }

    public void DeactivateScreen()
    {
        _screen.SetActive(false);
    }
}
