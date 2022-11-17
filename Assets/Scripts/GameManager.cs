using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public bool GamePaused = false;
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
