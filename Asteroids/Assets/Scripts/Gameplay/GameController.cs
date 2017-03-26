using UnityEngine;
using System.Collections;

/// <summary>
/// Class for game controlling
/// </summary>
public class GameController : MonoBehaviour {

    [SerializeField]
    GameObject starship;
    [SerializeField]
    float sideMovingSpeed;
    [SerializeField]
    float movingAngleDivergence = 45;
    [SerializeField]
    float turningSpeed = 1;

    Coroutine sideMovingCor;
    Coroutine turningCor;

    bool isPlaying = true;


	void Start ()
    {
        BaseInput.OnStartMoving += StartMoving;
        BaseInput.OnStopMoving += StopMoving;
        BaseInput.OnShot += Shoot;
	}

    void OnDestroy()
    {
        BaseInput.OnStartMoving -= StartMoving;
        BaseInput.OnStopMoving -= StopMoving;
        BaseInput.OnShot -= Shoot;
    }

    private void Shoot()
    {
        Debug.Log("EWE HE roToBo");
    }

    private void StopMoving()
    {
        if (sideMovingCor != null)
            StopCoroutine(sideMovingCor);
        if (turningCor != null)
            StopCoroutine(turningCor);
        turningCor = StartCoroutine(turning(0));

    }

    private void StartMoving(MoveSide obj)
    {
        if (isPlaying)
        {
            if (sideMovingCor != null)
                StopCoroutine(sideMovingCor);
            sideMovingCor = StartCoroutine(sideMoving(obj));
            if (turningCor != null)
                StopCoroutine(turningCor);
            turningCor = StartCoroutine(turning(-movingAngleDivergence * (2 * obj.GetHashCode() - 1)));
        }
    }

    IEnumerator sideMoving(MoveSide side)
    {
        float delta = 0;
        if (side == MoveSide.Left)
            delta = -sideMovingSpeed;
        else
            delta = sideMovingSpeed;
        while (true)
        {
            starship.transform.position += new Vector3(delta * Time.deltaTime, 0, 0);
            yield return null;
        }
    }

    IEnumerator turning(float targetAngle)
    {
        float delta = 0;
        if (targetAngle > Angle180(starship.transform.localRotation.eulerAngles.z))
            delta = turningSpeed;
        else
            delta = -turningSpeed;
        while (true)
        {
            starship.transform.localEulerAngles += new Vector3(0, 0, delta * Time.deltaTime);
            yield return null;
            if (Mathf.Abs(targetAngle - Angle180(starship.transform.localRotation.eulerAngles.z)) < turningSpeed * Time.deltaTime)
                break;
        }
    }

    float Angle180(float angle)
    {
        if (angle > 180)
            return angle - 360;
        return angle;
    }
}
