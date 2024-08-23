using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = this as T;
            DontDestroyOnLoad(gameObject);
            Debug.Log($"<color=green>{typeof(T).Name} instance initialized succesfully.</color>");
        }
        else
        {
            Destroy(this);
        }
    }
}
