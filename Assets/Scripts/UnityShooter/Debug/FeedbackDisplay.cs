using System.Collections.Generic;
using UnityEngine;
public class FeedbackDisplay: MonoBehaviour
{

    public struct Message
    {
        public string Text;
        public float EndTime;

        public Message(string text, float duration)
        {
            Text = text;
            EndTime = Time.time + duration;
        }
    }

    List<Message> messages = new List<Message>();
    public void AddMessage(string text, float duration)
    {
        messages.Insert(0, new Message(text, duration));
    }

    private void OnGUI()
    {
        for (int i = messages.Count - 1; i >= 0; i--)
        {
            var message = messages[i];
            GUILayout.Label(message.Text);
            if (Time.time > message.EndTime)
            {
                messages.Remove(message);
            }
        }
    }
}
