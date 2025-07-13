
using LeightonFPS;
using UnityEngine;

public class BaseAI : MonoBehaviour
{

    protected GameObject chaseTarget;
    protected int pathIndex = 0;
    protected bool patrolMode = true;

    [Header("AI Functionality")]
    [SerializeField] protected Player player;
    [SerializeField] protected GameObject[] pathNodes;
    [SerializeField] protected float movementSpeedInUnitsPerSecond = 19f;
    [SerializeField] protected Rigidbody enemyBody;
    [SerializeField] protected int damageValue = 10;
    [SerializeField] protected int healthValue = 10;
    virtual protected void Start()
    {
        chaseTarget = pathNodes[0];
    }

    virtual protected void FixedUpdate()
    {
        MoveTowardsObjective();

        if (patrolMode)
        {
            CheckPointChecker();
        }
    }
    virtual protected void MoveTowardsObjective()
    {
        // Sets speed to average and structure to adjust speed.
        Vector3 Direction = (chaseTarget.transform.position - gameObject.transform.position);
        Direction.Normalize();

        // Debug.Log(Direction + ": FaceDirection");
        // Debug.Log(gameObject.transform.position + ": EnemyPos");
        // Debug.Log(Direction + gameObject.transform.position + ": New Position (Direction & position)");
        
        if (enemyBody.linearVelocity.magnitude <= movementSpeedInUnitsPerSecond)
        {
            enemyBody.AddForce((Direction) * movementSpeedInUnitsPerSecond);
        }

        // enemyBody.transform.LookAt(chaseTarget.transform, Vector3.up);
    }

    virtual protected void CheckPointChecker()
    {
        Vector3 targetpos = new Vector3(chaseTarget.transform.position.x, 1, chaseTarget.transform.position.z);

        // Checks if the AI is in a range of 1 on both x and y, if true it changes target
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

    virtual public void Aggroed()
    {
        chaseTarget = player.gameObject;
        patrolMode = false;
    }

    virtual protected void Attack()
    {
        player.playerHealth -= damageValue;
        Debug.Log(player.playerHealth + ": Player's Health");
    }
}
