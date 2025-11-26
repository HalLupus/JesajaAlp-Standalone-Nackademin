using UnityEngine;
using TMPro;
using System.Collections;

public class EffectDisplay : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    public float displayDuration = 3f; // How long the message stays visible

    private Coroutine displayRoutine;

    private void Awake()
    {
        gameObject.SetActive(false); // Start hidden
    }

    public void ShowMessage(string message)
    {
        // If already displaying something, restart timer
        if (displayRoutine != null)
            StopCoroutine(displayRoutine);

        gameObject.SetActive(true);
        displayRoutine = StartCoroutine(DisplayMessageRoutine(message));
    }

    private IEnumerator DisplayMessageRoutine(string message)
    {
        displayText.text = message;

        yield return new WaitForSeconds(displayDuration);

        gameObject.SetActive(false);
        displayRoutine = null;
    }
}
