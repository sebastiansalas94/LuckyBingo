using UnityEngine;

public interface IInteractable
{
    Sprite HintIcon { get; }
    string HintText { get; }
    void Interact();
}
