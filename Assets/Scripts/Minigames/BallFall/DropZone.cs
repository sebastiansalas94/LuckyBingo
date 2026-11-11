using UnityEngine;

public class DropZone : MonoBehaviour
{
    public bool Accepts(Draggable item)
    {
        return true; // add rules here, e.g. only the right ball
    }

    public void Drop(Draggable item)
    {
        item.transform.position = transform.position; // snap into place
        Debug.Log($"{item.name} dropped on {name}");
    }
}
