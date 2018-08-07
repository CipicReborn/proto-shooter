using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


namespace UnityShooter
{
    public class Actor : SerializedMonoBehaviour
    {
        public string Name { get { return gameObject.name; } }
        public bool OnStage { get { return onStage; } }
        private bool onStage = false;

        [Header("List of Behaviours")]
        public List<IActorAbility> BehaviourControllers;

        public void Setup()
        {
            for (int i = 0; i < BehaviourControllers.Count; i++)
            {
                BehaviourControllers[i].gameObject.SetActive(true);
                BehaviourControllers[i].Init();
            }
            //Debug.Log(Name + " : All Enabeld");
        }

        public void GoOnStage()
        {
            GameServices.LevelTicker.Add(this);
            onStage = true;
        }

        public void Tick()
        {
            for (int i = 0; i < BehaviourControllers.Count; i++)
            {
                BehaviourControllers[i].Tick();
            }
        }


        virtual protected void Awake()
        {
            for (int i = 0; i < BehaviourControllers.Count; i++)
            {
                BehaviourControllers[i].gameObject.SetActive(false);
            }
            //Debug.Log(Name + " : All Disabeld");
        }


    }
}