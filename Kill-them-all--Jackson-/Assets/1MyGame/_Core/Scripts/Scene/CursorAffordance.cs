using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CameraRaycaster))]
public class CursorAffordance : MonoBehaviour
{
    
    [SerializeField] Texture2D walkCursor = null;
    [SerializeField] Texture2D itemCursor = null;
    [SerializeField] Texture2D targetCursor = null;

    [SerializeField] Vector2 cursorHotspot = new Vector2(0, 0);
    
    

    // Use this for initialization
    void Start()
    {
        Cursor.SetCursor(walkCursor, cursorHotspot, CursorMode.Auto);
    }



        
    
    void OnMouseEnter()
    {
        if (gameObject.tag == "Enemy")
        {
            Cursor.SetCursor(targetCursor, cursorHotspot, CursorMode.Auto);
        }
        if (gameObject.tag == "HealBox")
        {
            Cursor.SetCursor(itemCursor, cursorHotspot, CursorMode.Auto);
        }

    }

   void OnMouseExit()
    {
        Cursor.SetCursor(walkCursor, cursorHotspot, CursorMode.Auto);
    }

    // TODO consertar cursor
}