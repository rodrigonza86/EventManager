using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    private const string EVENT_TOGGLE_SPIN = "Toggle Spin";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var newPosition = new Vector3(Random.Range(-2, 2), Random.Range(0, 2), 0);

            EventManager.TriggerEvent(EventData.Create(EVENT_TOGGLE_SPIN)
                .Set("Position", newPosition)
                .Set("Name", "Jhon")
                .Set("Age", 33)
            );
        }
    }
}
