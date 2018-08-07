using System.Collections.Generic;
using UnityEngine;
using Game.Behaviour;
using Game.Behaviour.Movement;
using UnityGameData;

namespace UnityShooter
{
    public class ScriptedMovementInput : IInput<Vector2>, ISpeedValue
    {
        public float Value { get { return currentSpeed; } }

        public ScriptedMovementInput(Transform transformToMove, List<MovePattern> data)
        {
            this.transformToMove = transformToMove;

            patternData = data;
            CheckData();
            if (patternData.Count == 0)
            {
                moveIsFinished = true;
                Debug.LogWarning("No Move Patterns found for " + transformToMove.gameObject.name);
                return;
            }
            currentPattern = patternData[patternIndex];
            //Debug.Log("Pattern " + patternIndex + " set for " + transformToMove.gameObject.name + " : " + currentPattern.name);
        }

        public Vector2 Read()
        {
            Tick();
            return currentDirection;
        }

        private Transform transformToMove;
        private List<MovePattern> patternData = new List<MovePattern>();

        private bool moveIsFinished;
        private float elapsedTime;
        private float t;
        private int patternIndex;
        private MovePattern currentPattern;
        private float currentSpeed;
        private Vector2 currentDirection;

        private void Tick()
        {
            if (moveIsFinished)
            {
                if (MorePatternsToPlay())
                {
                    GoToNextPattern();
                }
                else return;
            }
            ComputeTime();
            ProcessCycle();
            CalculateSpeed();
            CalculateDirection();
            //ApplyMove();
        }

        private void CheckData()
        {
            bool isLoop = false;
            for (int i = 0; i < patternData.Count; i++)
            {
                if (isLoop)
                {
                    Debug.LogWarning(transformToMove.gameObject.name + " has a Loop pattern preventing access to further patterns at index " + (i - 1));
                }
                isLoop = patternData[i].Loop;
            }
        }

        private bool MorePatternsToPlay()
        {
            return patternIndex < patternData.Count - 1;
        }

        private void GoToNextPattern()
        {
            ResetCycle();
            NextPattern();
        }

        private void NextPattern()
        {
            moveIsFinished = false;
            patternIndex++;
            currentPattern = patternData[patternIndex];
            Debug.Log("Pattern " + patternIndex + " set for " + transformToMove.gameObject.name + " : " + currentPattern.name);
        }

        private void ComputeTime()
        {
            elapsedTime += Time.deltaTime;
            t = elapsedTime / currentPattern.Duration;
        }

        private void ProcessCycle()
        {
            if (t > 1)
            {
                if (currentPattern.Loop)
                {
                    ResetCycle();
                }
                else
                {
                    t = 1;
                    moveIsFinished = true;
                }
            }
        }

        private void ResetCycle()
        {
            elapsedTime = 0;
            t = 0;
        }

        private void CalculateSpeed()
        {
            currentSpeed = currentPattern.BaseSpeed * currentPattern.SpeedOverDuration.Evaluate(t);
        }

        private void CalculateDirection()
        {
            currentDirection = new Vector2(currentPattern.xOverDuration.Evaluate(t), currentPattern.yOverDuration.Evaluate(t));
            //currentDirection = new Vector2(currentPattern.xOverDuration.Evaluate(currentPattern.SpeedOverDuration.Evaluate(t)), currentPattern.yOverDuration.Evaluate(currentPattern.SpeedOverDuration.Evaluate(t)));
        }

        private void ApplyMove()
        {
            transformToMove.position += (Vector3)(currentDirection * currentSpeed * Time.deltaTime);
        }
    }
}