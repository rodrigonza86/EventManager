using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent OnStart;

    void Start()
    {
        if (OnStart != null)
        {
            OnStart.Invoke();
        }
    }
}
