using UnityEngine;
using System.Collections;


/// <summary>
/// Input class for mobile platforms
/// </summary>
public class MobileInput : BaseInput {

    [SerializeField]
    [Range(0, 0.5f)]
    protected float movingSidePart = 0.2f;

    void Update ()
    {
        if (Input.GetMouseButtonDown(0))
            MouseDown(Input.mousePosition);
        if (Input.GetMouseButtonUp(0))
            MouseUp();
	}

    void MouseDown(Vector3 pos)
    {
        float xPos = pos.x / (float)Screen.width;
        if (xPos <= movingSidePart)
        {
            StartMoving(MoveSide.Left);
            return;
        }
        if (xPos >= 1 - movingSidePart)
        {
            StartMoving(MoveSide.Right);
            return;
        }
        Shot();
    }

    void MouseUp()
    {
        if (isMoving)
            StopMoving();
    }
}
