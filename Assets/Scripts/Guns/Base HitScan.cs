using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
namespace LeightonFPS
{
    // https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
    // https://docs.unity3d.com/Packages/com.unity.inputsystem@1.14/manual/Workflow-Actions.html

    public class BaseHitScan : MonoBehaviour

    {
        [SerializeField] int maxAmmo = 30;
        [SerializeField] float reloadTime = 2f;
        protected float reloadTimeLeft = 0f;
        protected bool reloading = false;
        protected int currentAmmo = 30;
        [SerializeField] float fireRate = 0.2f;
        protected float fireRateTimer = 1f;

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


        public virtual void Shoot()

        // Checks for Enough Ammo~
        // Fires Gun~
        {
            // Checks for Enough Ammo~
            if (currentAmmo <= 0 || fireRateTimer > 0)

            {
                return;
            }
            // shoots line from gun to check if firing, may delete when wrapping up
            RaycastHit hit;

            if (Physics.Raycast(shooter.transform.position, shooter.transform.forward, out hit))

            {
                Debug.DrawRay(shooter.transform.position, shooter.transform.forward * 300, Color.green, 1f);
                Debug.Log("Ray has been casted");

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
    }

}
