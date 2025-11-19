using UnityEngine;

public class StartGame : MonoBehaviour
{
    [Header("Object to Disable")]
    public GameObject objectToDisable;

    [Header("Timer Script (with StartTimer())")]
    public MonoBehaviour timerScript;   // Drag the script here

    private void OnTriggerEnter(Collider other)
    {
        // Disable the object
        if (objectToDisable != null)
        {
            objectToDisable.SetActive(false);
        }

        // Call StartTimer() if available
        if (timerScript != null)
        {
            // Assumes the script has a public StartTimer() function
            timerScript.Invoke("StartTimer", 0f);
        }
    }
}
