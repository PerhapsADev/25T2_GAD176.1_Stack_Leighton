using System.Collections;
using System.Collections.Generic;

using System.Runtime.CompilerServices;
using UnityEngine;

/// <summary>
/// Rolls the ball around using phyiscs based on player inputs OR a target direction.
/// </summary>
public class PhysicsMover : MonoBehaviour
{
    [Header("Core Properties")]
    [SerializeField] private Rigidbody sphere;

    [Header("AI Functionality")]
    [SerializeField] private bool isCurrentlyChasing;
    [SerializeField] private float movementSpeedInUnitsPerSecond = 19f;
    private GameObject chaseTarget;
    public GameObject Player;
    public GameObject Target1;
    public GameObject Target2;
    // [SerializeField] private GameObject player;

    private void Start()
    {
        this.transform.position = new Vector3(-40, 0, 40);
        chaseTarget = Target1;
    }

    private void FixedUpdate()
    {
        if (isCurrentlyChasing == false)
        {
            if (sphere.linearVelocity.magnitude <= 20)
            {
                Vector3 Direction = (chaseTarget.transform.position - gameObject.transform.position);
                Direction.Normalize();
                sphere.linearVelocity = Direction * movementSpeedInUnitsPerSecond;
            }

            Vector3 targetpos = new Vector3(chaseTarget.transform.position.x, 1, chaseTarget.transform.position.y);
            // Checks if the Ball is in a range of 1 on both x and y, if true it changes target
            if ((this.transform.position.x >= targetpos.x - 1 || this.transform.position.x <= targetpos.x + 1)
             && (this.transform.position.z >= targetpos.z - 1 || this.transform.position.z <= targetpos.z + 1))
            {
                // Sets ChaseTarget FROM condition = results true : false, 
                chaseTarget = chaseTarget == Target1 ? Target2 : Target1;

            }
        }
        else
        {
            // AI chasing code
            // tartget.position - player.position

            if (sphere.linearVelocity.magnitude <= 20)
            {
                sphere.AddForce(chaseTarget.transform.position - gameObject.transform.position);
            }
        }

    }
}
