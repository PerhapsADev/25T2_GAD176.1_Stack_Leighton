using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
namespace LeightonFPS

{
public class Player : MonoBehaviour
{

    InputAction attackAction;
    InputAction reloadAction;

        public BaseHitScan HitScanWeapon;
        // int healthPlayer = 1;

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
                HitScanWeapon.Shoot();
            }

            if (reloadAction.IsPressed())
            {
                HitScanWeapon.ReloadStart();
            }
            
        }
}

}

