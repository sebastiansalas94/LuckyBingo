using Unity.Burst.CompilerServices;
using UnityEngine;

public class TV : MonoBehaviour, IInteractable
{
    private DialogueTrigger dt;

    private void Awake()
    {
        dt = GetComponent<DialogueTrigger>();
    }

    public void Interact()
    {
        Debug.Log("TV clicked");
        dt.StartDialogue(); 
    }
}