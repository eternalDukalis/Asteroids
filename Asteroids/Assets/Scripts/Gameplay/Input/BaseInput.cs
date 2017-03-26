using UnityEngine;
using System.Collections;

/// <summary>
/// Abstract input class
/// </summary>
public abstract class BaseInput : MonoBehaviour
{
    /// <summary>
    /// On moving's beginning
    /// </summary>
    public static event System.Action<MoveSide> OnStartMoving;

    /// <summary>
    /// On moving's ending
    /// </summary>
    public static event System.Action OnStopMoving;

    /// <summary>
    /// On shot
    /// </summary>
    public static event System.Action OnShot;

    [SerializeField]
    protected RuntimePlatform[] targetPlatforms;
    protected bool isMoving = false;

    protected void Start()
    {
        bool platformConfirmed = false;
        foreach (RuntimePlatform x in targetPlatforms)
            if (Application.platform == x)
            {
                platformConfirmed = true;
                break;
            }
        if (!platformConfirmed)
            this.enabled = false;
    }

    protected void StartMoving(MoveSide moveSide)
    {
        if (OnStartMoving != null)
            OnStartMoving(moveSide);
        isMoving = true;
    }

    protected void StopMoving()
    {
        if (OnStopMoving != null)
            OnStopMoving();
        isMoving = false;
    }

    protected void Shot()
    {
        if (OnShot != null)
            OnShot();
    }
}

/// <summary>
/// Side where something is moving to
/// </summary>
public enum MoveSide { Left, Right }
