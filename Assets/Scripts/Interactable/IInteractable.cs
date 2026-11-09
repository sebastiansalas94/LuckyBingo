using UnityEngine;

public interface IInteractable
{
    Sprite HintIcon { get; }
    string HintText { get; }
    bool ShowHint { get; }
    void Interact();
}
