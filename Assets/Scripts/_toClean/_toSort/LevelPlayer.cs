using System.Collections.Generic;
using UnityEngine;


public class LevelPlayer : MonoBehaviour
{

    private List<ILevelElementDescription> UpcomingElements;
    private List<ILevelElementDescription> LiveElements;

    private float ScreenLimit;

    private void Update()
    {
        for (int i = 0; i < UpcomingElements.Count; i++)
        {
            var element = UpcomingElements[i];
            if (ElementIsAboutToEnterScreen(element))
            {
                continue;
            }

            SetElementsAliveUpTo(i - 1);
        }
    }


    private bool ElementIsAboutToEnterScreen (ILevelElementDescription element)
    {
        return element.position.x < ScreenLimit;
    }

    private void SetElementsAliveUpTo (int count)
    {
        var elementsToWakeUp = UpcomingElements.GetRange(0, count);
        UpcomingElements.RemoveRange(0, count);

        for (int i = 0; i < elementsToWakeUp.Count; i++)
        {
            var levelElementDescription = elementsToWakeUp[i];
            ILevelElement gameElement = LevelPool.GetElement(levelElementDescription);
            gameElement.WakeUp();
        }

        LiveElements.AddRange(elementsToWakeUp);
    }
}
