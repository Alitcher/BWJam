using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.I.RegisteredSeeds.Count > 0)
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
                Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);
                GameManager.I.RegisteredSeeds[0].transform.position = objPos;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                GameManager.I.RegisteredSeeds.Clear();

            }
        }

    }
}
