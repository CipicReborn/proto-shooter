using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScrollDrop : SerializedMonoBehaviour {

    public IScrollingLayer Back;
    public IScrollingLayer Game;
    public IScrollingLayer Fore;

    public List<GameObject> prefabsBackGround;
    public List<GameObject> prefabsGameGround;
    public List<GameObject> prefabsForeGround;

    public float BackRate;
    public float GameRate;
    public float ForeRate;

    public Vector2 BackRange;
    public Vector2 GameRange;
    public Vector2 ForeRange;


	void Update () {
        Drop(Back, prefabsBackGround, BackRate, BackRange, 0.03f, 0.3f);
        Drop(Game, prefabsGameGround, GameRate, GameRange, 1f, 1f);
        Drop(Fore, prefabsForeGround, ForeRate, ForeRange, 1f, 1f);
    }

    private void Drop(IScrollingLayer layer, List<GameObject> prefabList, float rate, Vector2 range, float minScale, float maxScale)
    {
        if (Random.Range(0f, 1.0f) < rate)
        {
            GameObject prefab = prefabList[Random.Range(0, prefabList.Count)];
            var pos = new Vector3(300, Random.Range(range.x, range.y));
            var t = Instantiate(prefab).transform;
            var s = Random.Range(minScale, maxScale);
            t.localScale = new Vector3(s, s, s);
            //t.rotation = Random.rotation;
            layer.AddAtPosition(t, pos);

        }
    }
}
