using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Rendering;
namespace LeightonFPS
{
    // https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
    // https://docs.unity3d.com/Packages/com.unity.inputsystem@1.14/manual/Workflow-Actions.html

    public class BaseHitScan : MonoBehaviour

    {
        [SerializeField] protected int maxAmmo = 30;
        [SerializeField] protected float reloadTime = 2f;
        [SerializeField] protected float fireRate = 0.2f;
        [SerializeField] protected float accuracy = 100f;
        [SerializeField] protected float damageValue = 1f;

        protected float reloadTimeLeft = 0f;
        protected float fireRateTimer = 1f;
        protected int currentAmmo = 30;
        protected bool reloading = false;


        GameObject shooter;

        public void Start()
        // Gets shooter
        {
            shooter = transform.parent.gameObject;

        }

        public void Update()
        {
            // Checks what to do when starting a reload
            if (reloading)
            {
                reloadTimeLeft -= Time.deltaTime;
                // Reload timer ends, it reloads
                if (reloadTimeLeft <= 0)

                {
                    reloading = false;
                    Reload();

                    Debug.Log("Reloaded Max Ammo " + maxAmmo);
                }

            }

            // 
            fireRateTimer -= Time.deltaTime;
        }


        public virtual void Shoot(bool holdTrigger)

        // Checks for Enough Ammo~
        // Fires Gun~
        {
            // Checks for Enough Ammo~
            if (currentAmmo <= 0 || fireRateTimer > 0)

            {
                return;
            }
            // shoots line from gun to check if firing, delete when wrapping up
            RaycastHit hit;

            // Decides Random Spread of Gun
            Vector3 forward = shooter.transform.forward + RandomSpread();
            forward.Normalize();

            if (Physics.Raycast(shooter.transform.position, forward, out hit))

            {
                Debug.Log("Ray has been casted");
                Debug.DrawRay(shooter.transform.position, forward * 300, Color.green, 10f);
            }

    

            fireRateTimer = fireRate;

            currentAmmo--;        // Change to minus from a int from specfic guns.

            // Fires Gun~
            Debug.Log("Gun Attempts to fire.");

        }



        public void Reload()
        // Sets ammo to Max
        {
            currentAmmo = maxAmmo;
        }

        public void ReloadStart()
        // Reloading or Current Ammo Check, does not reload
        // sets end of reload timer to beginning of reload time
        {
            if (reloading || currentAmmo == maxAmmo)
            {
                return;
            }
            Debug.Log("Started Reload");

            reloading = true;
            reloadTimeLeft = reloadTime;
        }

        public Vector3 RandomSpread()

        {
            float remainingPoints = 100f - accuracy;
            float xAccuracyPosition = Random.Range(- remainingPoints, remainingPoints) / 1000f;
            float yAccuracyPosition = Random.Range(- remainingPoints, remainingPoints) / 1000f;
            float zAccuracyPosition = Random.Range(- remainingPoints, remainingPoints) / 1000f;

            // Debug.Log (new Vector3(xAccuracyPosition, yAccuracyPosition, zAccuracyPosition));
            return new Vector3(xAccuracyPosition, yAccuracyPosition, zAccuracyPosition);

        
        }
    }

}
