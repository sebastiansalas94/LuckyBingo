using UnityEngine;

public interface IInteractable
{
    Sprite HintIcon { get; }
    string HintText { get; }
    bool ShowHint { get; }
    int HoveredCount { get; set; }
    void Interact();

    void ChangeSprite(bool isHovered);
}
