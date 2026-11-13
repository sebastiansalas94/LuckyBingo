using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static CursorManager Instance { get; private set; }

    [SerializeField] private Texture2D normalCursor;
    [SerializeField] private Texture2D handCursor;
    [SerializeField] private Vector2 handHotspot = new Vector2(10, 0);
    private void Awake()
    {
        Instance = this;
        SetNormal();
    }

    public void SetNormal()
    {
        Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.Auto);
    }

    public void SetHand()
    {
        Cursor.SetCursor(handCursor, handHotspot, CursorMode.Auto);
    }
}
