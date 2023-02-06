using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerController : MonoBehaviour
{
    FirstPersonController firstPersonController = null;


    private void ActivateMovement(bool shouldActivate)
    {
        firstPersonController.canMove = shouldActivate;
    }
}
