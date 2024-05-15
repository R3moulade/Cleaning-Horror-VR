using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections; // Ensure this namespace is included

public class DisappearTrash : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    public float disappearDelay = 3.0f; // Time in seconds before the object disappears

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrab);
        }
    }

    void OnDestroy()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrab);
        }
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        Debug.Log("Object grabbed: " + gameObject.name);
        StartCoroutine(DisappearAfterDelay(disappearDelay));
    }

    private IEnumerator DisappearAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
        Debug.Log("Object disappeared: " + gameObject.name);
    }
}