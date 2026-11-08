using UnityEngine;

public class TV : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("TV clicked");
    }
}