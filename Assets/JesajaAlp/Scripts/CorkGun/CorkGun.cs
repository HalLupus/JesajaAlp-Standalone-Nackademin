using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class CorkGun : MonoBehaviour
{
    public XRSocketInteractor socketInteractor;
    private IXRSelectInteractable currentCork;
    public float launchForce = 10f;
    public float disableDuration = 1.0f;  // Duration to disable reattachment

    void Start()
    {
        socketInteractor.selectEntered.AddListener(OnCorkInserted);
        socketInteractor.selectExited.AddListener(OnCorkRemoved);
    }

    void OnCorkInserted(SelectEnterEventArgs args)
    {
        currentCork = args.interactableObject;
        Debug.Log("Cork attached: " + currentCork.transform.name);
    }

    void OnCorkRemoved(SelectExitEventArgs args)
    {
        currentCork = null;
    }

    public void FireCork()
    {
        if (currentCork != null)
        {
            // End manual interaction and detach.
            socketInteractor.EndManualInteraction();

            GameObject corkObject = currentCork.transform.gameObject;
            Rigidbody rb = corkObject.GetComponent<Rigidbody>();
            XRGrabInteractable grabInteractable = corkObject.GetComponent<XRGrabInteractable>();

            // Unparent the cork so it’s no longer a child of the socket.
            corkObject.transform.parent = null;

            // Slightly offset the cork so it doesn't immediately clip back.
            corkObject.transform.position += transform.forward * 0.01f;

            if (rb != null)
            {
                // Output some debug information regarding the Rigidbody.
                Debug.Log("Cork Rigidbody found: " + rb.name + ", mass: " + rb.mass);

                // Prepare the Rigidbody.
                rb.isKinematic = false;
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;

                // Test applying a stronger force (for debugging) to see if it moves.
                float appliedForce = launchForce; // You could tweak this in the Inspector.
                rb.AddForce(transform.forward * appliedForce, ForceMode.Impulse);
                Debug.Log("Applied force: " + (transform.forward * appliedForce));
            }
            else
            {
                Debug.LogError("No Rigidbody found on cork!");
            }

            currentCork = null;

            // Temporarily disable the socket and possibly the cork's interactable to prevent reattachment.
            StartCoroutine(TemporarilyDisable(socketInteractor, grabInteractable, disableDuration));
        }
        else
        {
            Debug.LogWarning("FireCork() called, but no cork was attached.");
        }
    }

    private IEnumerator TemporarilyDisable(XRSocketInteractor socket, XRGrabInteractable interactable, float duration)
    {
        // Disable the socket to prevent auto reattachment.
        socket.enabled = false;

        // If the cork has an interactable, disable that too.
        if (interactable != null)
        {
            interactable.enabled = false;
        }

        yield return new WaitForSeconds(duration);

        // Re-enable the socket and the cork's interactable.
        socket.enabled = true;
        if (interactable != null)
        {
            interactable.enabled = true;
        }
    }
}
