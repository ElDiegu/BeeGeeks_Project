using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScreen : MonoBehaviour
{
    [SerializeField] private string _nextScreenName;
    
    public void GoToScreen()
    {
        SceneManager.LoadScene(_nextScreenName, LoadSceneMode.Single);
    }
}
