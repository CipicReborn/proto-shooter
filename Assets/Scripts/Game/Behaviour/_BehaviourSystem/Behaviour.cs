using UnityEngine;

namespace Game.Behaviour
{
    public abstract class Behaviour<InputType, OutputType>
    {
        public Behaviour(IInput<InputType> input, IBehaviourController controller)
        {
            inputModule = input;
            this.controller = controller;
        }

        public void Tick()
        {
            ReadInputs();
            ApplyToGame();
            Feedback();
            if (controller.EnableDebugLogs)
            {
                PrintLog();
            }
        }

        protected IInput<InputType> inputModule;
        protected IBehaviourController controller;

        protected abstract OutputType GetResult(InputType input);

        protected InputType input;
        protected OutputType result;

        private void ReadInputs()
        {
            input = inputModule.Read();
        }

        private void ApplyToGame()
        {
            result = GetResult(input);
        }


        protected virtual void Feedback() { }

        private void PrintLog()
        {
            Debug.Log("For [" + controller.ObjectName + "] : " + "Input : " + input + "\n" +
                "Output : " + result);
        }
    }
}
