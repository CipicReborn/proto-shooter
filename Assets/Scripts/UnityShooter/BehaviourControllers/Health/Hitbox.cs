using System.Collections.Generic;
using UnityEngine;
using Game.Behaviour;
using Game.Behaviour.Health;
using Game.Behaviour.Damage;

namespace UnityShooter
{
    public class Hitbox : CollisionBox, IInput<DamagersCollided>
    {
        private void OnValidate()
        {
            var bc = GetComponent<BoxCollider>();
            bc.isTrigger = true;
        }

        public DamagersCollided Read()
        {
            var damagersCount = damagers.Count;

            var collided = new DamagersCollided(damagers);
            damagers.Clear();

            return collided;
        }

        private List<Damager> damagers = new List<Damager>();

        private void OnTriggerEnter(Collider collider)
        {
            //Debug.Log("[Hitbox Direct] " + transform.parent.parent.name + " has been collided by " + collider.transform.parent.parent.name);
            var damagerController = collider.transform.parent.GetComponent<DamagerController>();
            if (damagerController == null)
            {
                //Debug.Log("No DamagerController Component found on collider's parent");
                return;
            }
            if (damagers.Contains(damagerController.GetDamager()))
            {
                //Debug.Log("Already collided");
                return;
            }
            var d = damagerController.GetDamager();
            if (d == null)
            {
                Debug.Log(gameObject.name + "<" + transform.parent.gameObject.name + "<" + transform.parent.parent.gameObject.name);
                throw new System.Exception("DamagerController should be able to Provide a Damager.\nCheck if DamagerController has been initialised.");
            }
            damagers.Add(d);
        }
    }
}