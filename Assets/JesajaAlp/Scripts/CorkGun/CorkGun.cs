using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CorkGun : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socketInteractor;
    private UnityEngine.XR.Interaction.Toolkit.Interactables.IXRSelectInteractable currentCork;
    public float launchForce = 10f;

    void Start()
    {
        socketInteractor.selectEntered.AddListener(OnCorkInserted);
        socketInteractor.selectExited.AddListener(OnCorkRemoved);
    }

    void OnCorkInserted(SelectEnterEventArgs args)
    {
        currentCork = args.interactableObject;
    }

    void OnCorkRemoved(SelectExitEventArgs args)
    {
        currentCork = null;
    }

    public void FireCork()
    {
        if (currentCork != null)
        {
            socketInteractor.EndManualInteraction();

            GameObject corkObject = currentCork.transform.gameObject;
            Rigidbody rb = corkObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
                rb.AddForce(transform.forward * launchForce, ForceMode.Impulse);
            }

            currentCork = null;
        }
    }
}