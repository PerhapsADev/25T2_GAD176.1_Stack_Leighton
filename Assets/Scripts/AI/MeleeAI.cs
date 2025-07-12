using UnityEngine;

public class MeleeAI : BaseAI

// https://discussions.unity.com/t/simple-timer/56201
{
    private float movementTimeOutTimer = 2f;
    private bool timeOut = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player.gameObject)
        {
            Attack();
            timeOut = true;
            movementTimeOutTimer = 2f;
            Debug.Log(timeOut + ": time out for bounce triggered");
        }
    }

    protected override void FixedUpdate()
    {

        if (timeOut)
        {
            // This makes the enemy bounce back away from player after dealing damage.
            Vector3 BounceDirection = -(chaseTarget.transform.position - gameObject.transform.position);
            BounceDirection.Normalize();

            enemyBody.AddForce((BounceDirection + Vector3.up / 3) * 18);



            movementTimeOutTimer -= Time.deltaTime;

            if (movementTimeOutTimer <= 0.0f)
            {
                timeOut = false;
            }
        }
        else
        {
             base.FixedUpdate();

        }
    }
    
}
