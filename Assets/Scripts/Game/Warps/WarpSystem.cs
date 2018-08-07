using UnityEngine;


public class WarpSystem : MonoBehaviour
{
    public Transform BlockTransform;

    public Transform EntryPoint;
    public Warp UpperExitPoint;
    public Warp LowerExitPoint;

    public WarpSystem TopExitTarget;
    public WarpSystem BottomExitTarget;

    Vector3 originalPosition;
    Vector3 alignedPosition;

    private void Awake()
    {
        originalPosition = transform.position;
        if (originalPosition.y == 0)
            originalPosition.y = 450;
        alignedPosition = new Vector3(transform.position.x, 0, transform.position.z);
        UpperExitPoint.Name = "Top";
        UpperExitPoint.System = this;
        LowerExitPoint.Name = "Bottom";
        LowerExitPoint.System = this;
    }

    public void Align(Transform player)
    {
        alignedPosition.x = player.position.x + 60;
        BlockTransform.position = alignedPosition;
    }

    public void PositionOff()
    {
        originalPosition.x = transform.position.x;
        BlockTransform.position = originalPosition;
    }

    public void WarpOut(Transform transformToWarp, string name)
    {
        if (name == "Top")
        {
            //Debug.Log("Warping from Top Warp of " + BlockTransform.gameObject.name + " to EntryPoint of " + TopExitTarget.BlockTransform.gameObject.name);
            TopExitTarget.Align(transformToWarp);
            transformToWarp.position = TopExitTarget.EntryPoint.position;
        }
        else if(name == "Bottom")
        {
            //Debug.Log("Warping from Bottom Warp of " + BlockTransform.gameObject.name + " to EntryPoint of " + BottomExitTarget.BlockTransform.gameObject.name);
            BottomExitTarget.Align(transformToWarp);
            transformToWarp.position = BottomExitTarget.EntryPoint.position;
        }
        PositionOff();
    }
}
