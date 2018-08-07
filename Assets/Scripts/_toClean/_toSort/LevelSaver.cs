using System.Collections.Generic;
using UnityEngine;
using GameDesign;

[ExecuteInEditMode]
public class LevelSaver : MonoBehaviour {

    public Transform LevelTransform;
    public LevelData LevelData;

    public bool Save;

    private void Update()
    {
        if (Save)
        {
            Save = false;
            ExecuteSave();
        }
    }

    private void ExecuteSave () {

        var children = new List<Transform>();

        var count = LevelTransform.childCount;
        for (int i = 0; i < count; i++)
        {
            children.Add(LevelTransform.GetChild(i));
        }

        children.Sort(new SortTransformByX());


    }
}

public class SortTransformByX : IComparer<Transform>
{
    public int Compare(Transform x, Transform y)
    {
        if (x.position.x < y.position.x)
            return -1;
        
        if (x.position.x > y.position.x)
            return 1;
        return 0;
    }
}

namespace GameDesign
{
    public class LevelData : ScriptableObject
    {



    }
}

public interface ILevelElementDescription {
    Vector2 position { get; }
}

public interface ILevelElement {
    void WakeUp();
}

public class LevelPool
{
    public static ILevelElement GetElement (ILevelElementDescription elementDescription)
    {
        return null;
    }
}