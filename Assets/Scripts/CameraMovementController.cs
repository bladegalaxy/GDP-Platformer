using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    public Transform character;

    private Vector3 distanceFromCharacter = new Vector3(0f, 0f, -10f);

    void LateUpdate()
    {
        transform.position = new Vector3(character.position.x + distanceFromCharacter.x, 1f, character.position.z + distanceFromCharacter.z);

        if (transform.position.x < 0f) // left border for camera
        {
            transform.position = new Vector3(0f, transform.position.y, transform.position.z);
        }
    }
}
