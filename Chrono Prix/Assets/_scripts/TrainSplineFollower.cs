using UnityEngine;
using UnityEngine.Splines;

public class TrainSplineFollower : MonoBehaviour
{
    public SplineContainer spline;
    public float speed = 0.1f;
    public float progress;

    void Update()
    {
        progress += speed * Time.deltaTime;

        if (progress > 1f)
            progress = 0f;

        Vector3 position = spline.EvaluatePosition(progress);
        Vector3 forward = spline.EvaluateTangent(progress);

        transform.position = position;
        transform.rotation = Quaternion.LookRotation(forward);
    }
}