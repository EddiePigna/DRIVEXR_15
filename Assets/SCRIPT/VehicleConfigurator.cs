using UnityEngine;

[ExecuteInEditMode]
public class VehicleConfigurator : MonoBehaviour
{
    [Header("Vehicle Dimensions")]
    public float wheelbase;
    public float frontTrackWidth;
    public float rearTrackWidth;

    [Header("Wheel Dimensions")]
    public float frontWheelRadius;
    public float rearWheelRadius;

    [Header("Suspension Settings")]
    public float frontSuspensionDistance;
    public float rearSuspensionDistance;

    [Header("Wheel Colliders")]
    public WheelCollider[] frontWheelColliders;
    public WheelCollider[] rearWheelColliders;

    

    

    void OnValidate()
    {
        ConfigureWheels();
    }

    private void ConfigureWheels()
    {
        if (frontWheelColliders.Length == 2)
        {
            SetWheelPositions(frontWheelColliders, frontTrackWidth, wheelbase / 2, frontWheelRadius, frontSuspensionDistance);
        }

        if (rearWheelColliders.Length == 2)
        {
            SetWheelPositions(rearWheelColliders, rearTrackWidth, -wheelbase / 2, rearWheelRadius, rearSuspensionDistance);
        }
    }

    private void SetWheelPositions(WheelCollider[] wheelColliders, float trackWidth, float zPosition, float wheelRadius, float suspensionDistance)
    {
        float halfTrackWidth = trackWidth / 2;

        for (int i = 0; i < wheelColliders.Length; i++)
        {
            if (wheelColliders[i] != null)
            {
                float xPosition = (i % 2 == 0) ? -halfTrackWidth : halfTrackWidth;
                wheelColliders[i].transform.localPosition = new Vector3(
                    xPosition, wheelRadius, zPosition);

                wheelColliders[i].radius = wheelRadius;
                wheelColliders[i].suspensionDistance = suspensionDistance;
            }
        }
    }
}
