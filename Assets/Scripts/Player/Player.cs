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
        public BaseHitScan HitScanWeapon;
        // int healthPlayer = 1;

        // Player Shoot Class

        public void Start()
        {
            attackAction = InputSystem.actions.FindAction("AttackAuto");
            
        }

        public void Update()
        {
            if (attackAction.IsPressed())
            {
                HitScanWeapon.Shoot();
            }
              // PrimaryAction();
        }
            
    
        /* public void PrimaryAction()
    
        {
         Detects Mouse Input~
        if (Input.GetKeyDown(KeyCode.Mouse0))

        {
            HitScanWeapon.Shoot();
        }

        }
    */


}

}

