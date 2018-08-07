using UnityEngine;

public class GameServicesInitialiser : MonoBehaviour {

    public Camera Camera;
    public LevelTicker LevelTicker;

    private void OnValidate()
    {
        InitAllServices();
    }

    private void Awake()
    {
        InitAllServices();
    }

    private void InitAllServices()
    {
        InitBoundaries();
        InitLevelPLayer();
    }

    private void InitBoundaries()
    {
        if (Camera != null)
        {
            GameServices.Boundaries.SetCamera(Camera);
            GameServices.Boundaries.Recalculate();
            return;
        }
        Debug.Log("The GameService Boundaries needs the GameServicesInitialiser Camera reference assigned");
    }

    private void InitLevelPLayer()
    {
        GameServices.LevelTicker = LevelTicker;
    }
}
