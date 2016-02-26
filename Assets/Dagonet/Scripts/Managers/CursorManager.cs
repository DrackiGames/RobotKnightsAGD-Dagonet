using UnityEngine;
using System.Collections;

public class CursorManager : MonoBehaviour 
{
    public Texture2D normalMouse;
    public Texture2D highlightedMouse;

    void Start()
    {
        normal();
    }

    public void normal()
    {
        Cursor.SetCursor(normalMouse, Vector2.zero, CursorMode.Auto);
    }

    public void highlight()
    {
        Cursor.SetCursor(highlightedMouse, Vector2.zero, CursorMode.Auto);
    }
}
