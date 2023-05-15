using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    public string safeAreaTag = "SafeArea";
    public string deathAreaTag = "DeathArea";

    private bool isInSafeArea = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(safeAreaTag))
        {
            isInSafeArea = true;
        }
        else if (other.CompareTag(deathAreaTag))
        {
            StartCoroutine(OnDeath());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(safeAreaTag))
        {
            isInSafeArea = false;
        }
    }

    private IEnumerator OnDeath()
    {
        // Add your custom death behavior here
        yield return null;
    }
}
