using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropGo : MonoBehaviour
{
    float distance = 10f;
    private void OnMouseDrag()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = objPos;

    }

    private void OnMouseUp()
    {
    }
}
