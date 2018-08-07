using System.Collections;
using UnityEngine;
using Sirenix.OdinInspector;
using Game.Behaviour;
using UnityGameData;
using UnityShooter;

public class PlayerMoveSetup : SerializedMonoBehaviour {

    [Header("Move")]
    [SerializeField]
    private SpeedData EngineData;

    [Header("Feedback")]
    [SerializeField]
    private IFeedbackEffect<Vector2> moveFeedback;
    [SerializeField]
    private IFeedbackEffect<Vector2> audioMoveFeedback;

    private IInput<Vector2> moveInput;
    //private ConstantSpeedBehaviour moveBehaviour;

    private bool stabilizing;
    private Rigidbody rb;
    private Quaternion initialRotation;

    void Awake () {
        //moveInput = new PlayerMoveInput();
        //moveBehaviour = new ConstantSpeedBehaviour(transform, EngineData);

        rb = GetComponent<Rigidbody>();
        initialRotation = transform.rotation;
    }


    private void Update()
    {
        Stabilise();
        Move();
    }

    private void Stabilise()
    {
        if (Input.GetButtonDown("Stabilize") & !stabilizing)
        {
            if (rb.angularVelocity != Vector3.zero)
            {

                StartCoroutine(BringBackAngularVelocityToZero());
            }
            else
            {
                StartCoroutine(BringBackRotationToOriginal());
            }

        }
    }

    IEnumerator BringBackAngularVelocityToZero()
    {
        stabilizing = true;
        var elapsed = 0f;
        var duration = 1.0f;
        var t = 0f;
        var startVelocity = rb.angularVelocity;
        var finalVelocity = Vector3.zero;
        while (t < 1)
        {
            rb.angularVelocity = Vector3.Lerp(startVelocity, finalVelocity, t);

            yield return null;
            elapsed += Time.deltaTime;
            t = elapsed / duration;
        }

        rb.angularVelocity = finalVelocity;
        stabilizing = false;
    }

    IEnumerator BringBackRotationToOriginal()
    {
        stabilizing = true;
        var elapsed = 0f;
        var duration = 1.0f;
        var t = 0f;
        var start = transform.rotation;
        var final = initialRotation;
        while (t < 1)
        {
            transform.rotation = Quaternion.Lerp(start, final, t);

            yield return null;
            elapsed += Time.deltaTime;
            t = elapsed / duration;
        }

        transform.rotation = final;
        stabilizing = false;
    }

    private void Move()
    {
        var direction = moveInput.Read();
        //moveBehaviour.Tick(direction);
        Feedback(direction);
    }

    private void Feedback(Vector2 move)
    {
        moveFeedback.Tick(move);
        audioMoveFeedback.Tick(move);
    }
}
