using LeightonFPS;
using UnityEngine;

public class SemiHitScan : BaseHitScan
{
    public override void Shoot(bool holdTrigger)
    {
        if (holdTrigger)
        {
            base.Shoot(false);
        }
    }

}
