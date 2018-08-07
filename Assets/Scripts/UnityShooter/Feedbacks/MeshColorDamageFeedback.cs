using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Behaviour;
using Game.Behaviour.Health;
using System;

namespace UnityShooter
{
    public class MeshColorDamageFeedback : MonoBehaviour, IDamageFeedback, IFeedbackEffect<HealthAfterDamage>
    {
        public List<Renderer> Meshes;
        public Color DamageColor;
        public int FramesCount;

        public void Tick(HealthAfterDamage gameOutput)
        {
            Trigger(gameOutput.damageTaken);
        }

        public void Trigger(int count)
        {
            if (count > 0)
                StartCoroutine(Blink());
        }

        private List<Color> initialColors = new List<Color>();

        private void Awake()
        {
            for (int i = 0; i < Meshes.Count; i++)
            {
                var mat = Meshes[i].material;
                if (mat == null)
                {
                    Debug.Log(Meshes[i].gameObject.name + " has returned no material");
                    continue;
                }
                initialColors.Add(mat.color);
            }
        }

        private IEnumerator Blink()
        {
            AssignColorToMeshes(DamageColor);
            for (int i = 0; i < FramesCount; i++)
            {
                yield return null;
            }
            AssignInitialColorToMeshes();
        }

        private void AssignColorToMeshes(Color color)
        {
            for (int i = 0; i < Meshes.Count; i++)
            {
                Meshes[i].material.color = color;
            }
        }

        private void AssignInitialColorToMeshes()
        {
            for (int i = 0; i < Meshes.Count; i++)
            {
                Meshes[i].material.color = initialColors[i];
            }
        }
    }
}