using System.Collections;
using System.Collections.Generic;

using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

/// GENERAL DISCRIPTION NEEDED <<<< <<<< <<< 
public class PhysicsMover : MonoBehaviour
{
    [Header("Core Properties")]
    [SerializeField] private Rigidbody sphere;

    [Header("AI Functionality")]
    [SerializeField] private float movementSpeedInUnitsPerSecond = 19f;
    private GameObject chaseTarget; // the "chaseTarget" can be either pathnodes or the player
    public GameObject Player;
    [SerializeField] public GameObject[] pathNodes;
    protected int pathIndex = 0;
    private void Start()
    {
        chaseTarget = pathNodes[0];
    }
    private void FixedUpdate()
    {

        // Direction it's looking
        sphere.transform.LookAt(chaseTarget.transform, Vector3.up);
        
        // Sets speed to average and structure to adjust speed.
        Vector3 Direction = (chaseTarget.transform.position - gameObject.transform.position);
        Direction.Normalize();
        sphere.MovePosition((Direction * movementSpeedInUnitsPerSecond)  + this.transform.position);

        Vector3 targetpos = new Vector3(chaseTarget.transform.position.x, 1, chaseTarget.transform.position.z);
        // Checks if the AI is in a range of 1 on both x and y, if true it changes target AKA Checks if near nodes and if yes go to next designated node.
        if ((this.transform.position.x >= targetpos.x - 1 && this.transform.position.x <= targetpos.x + 1)
         && (this.transform.position.z >= targetpos.z - 1 && this.transform.position.z <= targetpos.z + 1))
            {
                // Sets ChaseTarget FROM condition = results true : false, 
                // >> chaseTarget = chaseTarget == Target1 ? Target2 : Target1;
                pathIndex++;
                pathIndex %= pathNodes.Length;
                chaseTarget = pathNodes[pathIndex];
                print(chaseTarget);
            }

        }
    }


