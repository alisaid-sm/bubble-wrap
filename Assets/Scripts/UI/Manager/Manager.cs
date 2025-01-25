using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager instance { get; private set; }

    void Awake()
    {

        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}