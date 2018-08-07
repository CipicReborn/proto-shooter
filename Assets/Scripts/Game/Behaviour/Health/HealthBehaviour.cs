using UnityEngine;

namespace Game.Behaviour.Health
{
    public class HealthBehaviour : AudioGraphicBehaviour<DamagersCollided, HealthAfterDamage>
    {
        public HealthBehaviour(IHealthData data, IHealthSystemController controller, IInput<DamagersCollided> input) :
            base(input, controller)
        {
            currentHP = data.MaxHealthPoints;
            this.controller = controller;

        }

        override protected HealthAfterDamage GetResult(DamagersCollided damagers)
        {
            var list = damagers.List;
            var totalDamage = 0;
            for (int i = 0; i < damagers.List.Count; i++)
            {
                var damager = damagers.List[i];
                totalDamage += damager.GetDamage();

                if (Debug.isDebugBuild)
                {
                    if (controller.EnableDebugLogs)
                        Debug.Log(controller.ObjectName + "has been collided by " + damagers.List[i].GetName() + " for " + damagers.List[i].GetDamage() + " points.");
                }
            }

            var effectiveDamageTaken = Mathf.Min(currentHP, totalDamage);
            currentHP -= effectiveDamageTaken;

            if (currentHP <= 0)
            {
                if (Debug.isDebugBuild)
                {
                    if (controller.EnableDebugLogs)
                        Debug.Log(controller.ObjectName + "has reached 0 HP. controller.Destroy() is about to be called.");
                }

                controller.Destroy();
            }


            if (Debug.isDebugBuild)
            {
                if (controller.EnableDebugLogs && effectiveDamageTaken > 0)
                {
                    Debug.Log("Total Damage for " + controller.ObjectName + " : " + effectiveDamageTaken);
                    Debug.Log("Remaining HP for " + controller.ObjectName + " : " + currentHP);
                }
            }

            return new HealthAfterDamage(effectiveDamageTaken, currentHP);
        }

        private new IHealthSystemController controller;
        private int currentHP;
    }
}
