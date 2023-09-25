using UnityEngine;

namespace CodeBase.Combat.Attacks
{
    public class ClickAttack : BaseAttack
    {
        private void Start()
        {
            PerformAttack();
        }

        protected override void Update()
        {
            base.Update();

            if (!(currentTimeBtwAttacks <= 0) || !Input.GetMouseButtonDown(0)) return;
            currentTimeBtwAttacks = timeBtwAttacks;
        }
    }
}