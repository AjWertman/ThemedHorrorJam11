using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Transform eyesTransform = null;
    [SerializeField] float sightRange = 20f;

    PlayerController playerController = null;

    NavMeshAgent navMeshAgent = null;

    bool isChasingPlayer = false;
    bool canMakeSightCheck = true;
    bool isInSight = false;
    
    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (isInSight)
        {
            isChasingPlayer = true;
        }

        if (isChasingPlayer)
        {
            ChasePlayer();
        }

        if (canMakeSightCheck)
        {
            canMakeSightCheck = false;
            StartCoroutine(HandleSightRaycast());
        }
    }

    /// <summary>
    /// Raycasts from the enemy's eyes to the player.
    /// If the first object hit isn't the player, the enemy cannot see the player.
    /// </summary>
    private IEnumerator HandleSightRaycast()
    {
        Vector3 directionToPlayer = (playerController.transform.position - eyesTransform.position).normalized;
        Ray ray = new Ray(eyesTransform.position, directionToPlayer);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, sightRange))
        {
            if (hit.collider.transform == playerController.transform)
            {
                isInSight = true;
                isChasingPlayer = true;
            }
            else
            {
                isInSight = false;
            }
        }

        yield return new WaitForSeconds(.25f);

        canMakeSightCheck = true;
    }

    private void ChasePlayer()
    {
        Vector3 playerPosition = playerController.transform.position;
        navMeshAgent.SetDestination(playerPosition);
    }

    private void CatchPlayer()
    {

    }

    private float GetDistanceToPlayer()
    {
        return Vector3.Distance(transform.position, playerController.transform.position);
    }
}
