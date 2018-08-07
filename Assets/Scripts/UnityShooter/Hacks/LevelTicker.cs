using System.Collections.Generic;
using UnityEngine;
using UnityShooter;

public class LevelTicker : MonoBehaviour
    {
        public void Add(Actor actor)
        {
            AddToTicklist(actor);
        }

        public void Remove(Actor actor)
        {
            AddToRemoveList(actor);
        }

        public void RequestDestroy(Actor actor)
        {
            AddToRemoveList(actor);
            AddUniqueToList(destroyList, actor.gameObject);
            //Debug.Log("Effectively Added " + actor.Name + " to destroyList");
        }

        public void AddUniqueToList<T>(List<T> list, T item)
        {
            if (!list.Contains(item))
                list.Add(item);
        }

        [SerializeField]
        private List<BoundedActor> tickList = new List<BoundedActor>();
        private List<BoundedActor> removeList = new List<BoundedActor>();
        private List<GameObject> destroyList = new List<GameObject>();
        private Boundaries boundaries;
        private Vector2 margins = new Vector2(50, 50);

        private void Awake()
        {
            boundaries = GameServices.Boundaries.GetBoundaries(margins, true);
            //Debug.Log("On Awake, boundaries are " + boundaries);
        }

        void Update()
        {
            ProcessTickList();
            ClearTickList();
            DestroyGameObjects();
        }

        private void AddToTicklist(Actor actor)
        {
            var boundedActor = new BoundedActor(actor, boundaries, this);
            tickList.Add(boundedActor);
            //Debug.Log("Effectively Added " + actor.Name + " to TickList");
        }

        private void AddToRemoveList(BoundedActor boundedActor)
        {
            AddUniqueToList(removeList, boundedActor);
            //Debug.Log("Effectively Added " + boundedActor.actor.Name + " to RemoveList");
        }

        private void AddToRemoveList(Actor actor)
        {
            var boundedActor = tickList.Find(x => x.actor == actor);
            AddToRemoveList(boundedActor);
        }

        // UPDATE
        private void ProcessTickList()
        {
            for (int i = 0; i < tickList.Count; i++)
            {
                tickList[i].actor.Tick();
                tickList[i].DestroyIfOutOfBounds();
            }
        }

        private void ClearTickList()
        {
            for (int i = 0; i < removeList.Count; i++)
            {
                tickList.Remove(removeList[i]);
                //Debug.Log(" Effectively removed " + removeList[i].actor.name + " from Ticklist.");
            }
            removeList.Clear();
        }

        private void DestroyGameObjects()
        {
            for (int i = 0; i < destroyList.Count; i++)
            {
                //Debug.Log("Effectively destroyed " + destroyList[i].name);
                Destroy(destroyList[i]);
            }
            destroyList.Clear();
        }




        private class BoundedActor
        {
            public Actor actor;
            BoundariesCondition isOut;
            LevelTicker ticker;

            public BoundedActor(Actor actor, Boundaries boundaries, LevelTicker levelTicker)
            {
                this.actor = actor;
                isOut = new BoundariesCondition(actor.transform, boundaries);
                ticker = levelTicker;
            }

            public void DestroyIfOutOfBounds()
            {
                if (isOut.IsTrue())
                {
                    ticker.RequestDestroy(actor);
                }
            }
        }
    }


    public class BoundariesCondition
    {
        public BoundariesCondition(Transform transform, Boundaries boundaries)
        {
            this.transform = transform;
            this.boundaries = boundaries;
        }

        public bool IsTrue()
        {
            return IsOutOfBoundaries(transform.position);
        }

        private bool IsOutOfBoundaries(Vector2 pos)
        {
            return pos.y < boundaries.Bottom || pos.y > boundaries.Top || pos.x < boundaries.Left || pos.x > boundaries.Right;
        }

        private Transform transform;
        private Boundaries boundaries;
    }
