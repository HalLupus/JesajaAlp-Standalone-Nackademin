using UnityEngine;

public class NetDurability : MonoBehaviour
{
    [Header("Durability Settings")]
    public float maxDurability = 10f;   // Total durability in seconds
    private float currentDurability;

    [Header("Objects to Toggle")]
    public GameObject objectToDisable;   // Drag the object to deactivate here
    public GameObject objectToEnable;    // Drag the object to activate here

    private bool isInWater = false;

    void Start()
    {
        currentDurability = maxDurability;
    }

    void Update()
    {
        // Countdown only if in water
        if (isInWater && currentDurability > 0f)
        {
            currentDurability -= Time.deltaTime;

            if (currentDurability <= 0f)
            {
                currentDurability = 0f;
                HandleDurabilityDepleted();
            }
        }
    }

    private void HandleDurabilityDepleted()
    {
        if (objectToDisable != null)
            objectToDisable.SetActive(false);

        if (objectToEnable != null)
            objectToEnable.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            isInWater = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            isInWater = false;
        }
    }
}
