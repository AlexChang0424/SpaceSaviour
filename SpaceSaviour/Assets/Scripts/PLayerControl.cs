using UnityEngine;

public class PLayerControl : MonoBehaviour
{
    [SerializeField] float Speed = 10f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 5f;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    void ProcessRotation()
    {
        float pitch = 0f;
        float yaw = 0f;
        float roll = 0f;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessTranslation()
    {
        float xMove = Input.GetAxis("Horizontal");
        float yMove = Input.GetAxis("Vertical");

        float xOffset = xMove * Time.deltaTime * Speed;
        float xaxis = transform.localPosition.x + xOffset;
        float clampedxaxis = Mathf.Clamp(xaxis, -xRange, xRange);

        float yOffset = yMove * Time.deltaTime * Speed;
        float yaxis = transform.localPosition.y + yOffset;
        float clampedyaxis = Mathf.Clamp(yaxis, -yRange, yRange);

        transform.localPosition = new Vector3(clampedxaxis, clampedyaxis, transform.localPosition.z);
    }
}
