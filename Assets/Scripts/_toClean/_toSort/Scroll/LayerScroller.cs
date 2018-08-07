using UnityEngine;
using UnityGameData;

public class LayerScroller : MonoBehaviour
{
    [Header("Game Layer Settings")]
    public Layer GameLayer;
    public IntValue GameLayerSpeed;
    [Header("Other Layers")]
    public Layer[] Layers;
    [Header("Other Layers Speeds")]
    public int[] Speeds;

    void Start () {
        GameLayer.ScrollingSpeed = new Vector2(GameLayerSpeed.Value, 0);

        for (int i = 0; i < Layers.Length; i++)
        {
            Layers[i].ScrollingSpeed = new Vector2(Speeds[i], 0);
        }
    }


    void Update () {
        GameLayer.Tick(Time.deltaTime);

        for (int i = 0; i < Layers.Length; i++)
        {
            Layers[i].Tick(Time.deltaTime);
        }
    }
}
