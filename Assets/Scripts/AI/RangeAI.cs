using UnityEngine;

public class RangeAI : BaseAI
{   
    [SerializeField] protected float cruiseAltitude = 0f; //Changes Y axis of enemy.
    protected override void MoveTowardsObjective()
    {
        // Sets speed to average and structure to adjust speed.
        Vector3 DirectionToTarget = (chaseTarget.transform.position - gameObject.transform.position);
        Vector3 Direction = new Vector3(DirectionToTarget.x, cruiseAltitude, DirectionToTarget.z);
        Direction.Normalize();


        // Debug.Log(Direction + ": FaceDirection");
        // Debug.Log(gameObject.transform.position + ": EnemyPos");
        // Debug.Log(Direction + gameObject.transform.position + ": New Position (Direction & position)");

        if (enemyBody.linearVelocity.magnitude <= movementSpeedInUnitsPerSecond)
        {
            enemyBody.AddForce((Direction) * movementSpeedInUnitsPerSecond);
        }
        
    }
}
