using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
namespace LeightonFPS
{
        // https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
    public class BaseHitScan : MonoBehaviour
    
    {
        [SerializeField] int maxAmmo = 30;
        int currentAmmo = 30;

        GameObject shooter;

        public void Start()
        {
            shooter = transform.parent.gameObject;

        }
        public virtual void Shoot()

        // Checks for Enough Ammo~
        // Fires Gun~
        {
            // Checks for Enough Ammo~
            if (currentAmmo <= 0)

            {
                return;
            }

            RaycastHit hit;

            if (Physics.Raycast(shooter.transform.position, shooter.transform.forward, out hit))

            {
                Debug.DrawRay(shooter.transform.position, shooter.transform.forward * 300, Color.green);
                Debug.Log("Ray has been casted"); 

            }

                currentAmmo--;        // Change to minus from a int from specfic guns.

            // Fires Gun~
            Debug.Log("Gun Attempts to fire.");

        }
        

        
        public void Reload()

        {
            currentAmmo = maxAmmo;
        }

    }

}
