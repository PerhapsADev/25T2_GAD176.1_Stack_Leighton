using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
namespace LeightonFPS

{

    public class Player : MonoBehaviour
    {
        public int playerHealth = 100;
        InputAction attackAction;
        InputAction reloadAction;

        public BaseHitScan HitScanWeapon;
        // Player Shoot Class

        public void Start()
        // Input Sets
        {
            attackAction = InputSystem.actions.FindAction("AttackAuto");
            reloadAction = InputSystem.actions.FindAction("Reload");

        }

        public void Update()
        // Input Checks
        {
            if (attackAction.IsPressed())
            {
                HitScanWeapon.Shoot(attackAction.WasPressedThisFrame());

            }

            if (reloadAction.IsPressed())
            {
                HitScanWeapon.ReloadStart();
            }

        }
        
        virtual public void PlayerTakeDamage(int damage)
        {
            playerHealth -= damage;
            Debug.Log(playerHealth + ": Player's Health");
        }
}

}

