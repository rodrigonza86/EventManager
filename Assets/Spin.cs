using UnityEngine;

public class Spin : MonoBehaviour
{
    public float speed = 10f;
    public string playerName;
    public int playerAge;

    private Transform _transform;
    private bool spin = true;
    private const string EVENT_TOGGLE_SPIN = "Toggle Spin";

    void OnEnable()
    {
        _transform = transform;

        EventManager.StartListening(EVENT_TOGGLE_SPIN, (EventData data) =>
        {
            playerName = data.Get<string>("Name");
            playerAge = data.Get<int>("Age");

            _transform.position = data.Get<Vector3>("Position");
        });
    }

    void Update()
    {
        if (spin)
        {
            _transform.Rotate(Vector3.up * speed * Time.deltaTime);
        }
    }
}
