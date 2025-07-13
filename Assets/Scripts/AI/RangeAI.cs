using UnityEngine;
namespace LeightonFPS
{

    public class RangeAI : BaseAI
    {
        [SerializeField] protected float cruiseAltitude = 0f; //Changes Y axis of enemy.
        [SerializeField] private SemiHitScan semiHitScan;
        [SerializeField] private GameObject gunHinge;
        protected float timerForGunFire = 2.5f;
        protected bool timerStartForGunFire = false;
        // private bool safteySwitch = false;

        protected override void Start()
        {
            base.Start();
            timerForGunFire = semiHitScan.fireRate;
        }
        protected override void MoveTowardsObjective()
        {
            // Sets speed to average and structure to adjust speed. As well as keeps the Y axis of Ai in a set state (can't go up and down without permission)
            Vector3 DirectionToTarget = (chaseTarget.transform.position - gameObject.transform.position);
            Vector3 Direction = new Vector3(DirectionToTarget.x, cruiseAltitude, DirectionToTarget.z);
            Direction.Normalize();

            // Debug.Log's below aren't enabled but can be if you need to see exactly where your eneimes / AI is.

            // Debug.Log(Direction + ": FaceDirection");
            // Debug.Log(gameObject.transform.position + ": EnemyPos");
            // Debug.Log(Direction + gameObject.transform.position + ": New Position (Direction & position)");

            if (enemyBody.linearVelocity.magnitude <= movementSpeedInUnitsPerSecond)
            {
                enemyBody.AddForce((Direction) * movementSpeedInUnitsPerSecond);
            }

        }
        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            if (!patrolMode)
            {
                // Makes gun start firing once its detected a player
                gunHinge.transform.LookAt(chaseTarget.transform, Vector3.up);

                timerForGunFire -= Time.deltaTime;
                timerStartForGunFire = true;

                if (timerForGunFire <= 0.0f)
                {
                    semiHitScan.Shoot(true);
                    timerForGunFire = semiHitScan.fireRate;
                }
            }
        }

        protected override void AiDeath()
            {
                base.AiDeath();
                this.GetComponent<Rigidbody>().useGravity = true;
            }
    }

    
}
