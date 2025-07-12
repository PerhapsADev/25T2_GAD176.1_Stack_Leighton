using UnityEngine;

public class EnemyVison : MonoBehaviour
{    
    [SerializeField] protected GameObject player;
    [SerializeField] protected BaseAI baseAI;

    private void OnTriggerEnter(Collider other)
    {
        // This scipt is used for enemy vison cones using "OnTrigger". Attach this script to its vison cone, NOT the Enemy itself.
        if (other.gameObject == player)
        {
            baseAI.Aggroed();
            Debug.Log("Enemy detected player,Aggroed triggered");
        }
    }
}
