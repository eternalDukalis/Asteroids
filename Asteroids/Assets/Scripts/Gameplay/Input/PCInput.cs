using UnityEngine;
using System.Collections;

/// <summary>
/// Input class for pc platforms
/// </summary>
public class PCInput : BaseInput {

    MoveSide CurrentSide = MoveSide.Left;

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            KeyDown(MoveSide.Left);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            KeyDown(MoveSide.Right);
        if (Input.GetKeyUp(KeyCode.LeftArrow))
            KeyUp(MoveSide.Left);
        if (Input.GetKeyUp(KeyCode.RightArrow))
            KeyUp(MoveSide.Right);
        if (Input.GetKeyDown(KeyCode.Return))
            ShotDown();
	}

    void KeyDown(MoveSide side)
    {
        StartMoving(side);
        CurrentSide = side;
    }

    void KeyUp(MoveSide side)
    {
        if (side == CurrentSide)
            StopMoving();
    }

    void ShotDown()
    {
        Shot();
    }
}
