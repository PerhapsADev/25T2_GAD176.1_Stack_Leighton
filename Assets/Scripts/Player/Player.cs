using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace LeightonFPS

{
public class Player : MonoBehaviour
{

public BaseHitScan HitScanWeapon;
    // int healthPlayer = 1;

        // Player Shoot Class


        public void Update()
    {
        PrimaryAction();
    }
            
    
        public void PrimaryAction()
    
        {
        // Detects Mouse Input~
        if (Input.GetKeyDown(KeyCode.Mouse0))

        {
            HitScanWeapon.Shoot();
        }

        }



}

}

