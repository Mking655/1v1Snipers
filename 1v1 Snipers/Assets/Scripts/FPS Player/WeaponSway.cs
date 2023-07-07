using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    public float swayAmount = 0.02f;  // The amount of sway to apply to the weapon
    public float maxSwayAmount = 0.06f;  // The maximum amount of sway to apply
    public float swaySpeed = 0.5f;  // The speed at which to apply the sway

    private Vector3 initialPosition;  // The initial position of the weapon

    void Start()
    {
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * swayAmount;
        float mouseY = Input.GetAxis("Mouse Y") * swayAmount;

        mouseX = Mathf.Clamp(mouseX, -maxSwayAmount, maxSwayAmount);
        mouseY = Mathf.Clamp(mouseY, -maxSwayAmount, maxSwayAmount);

        Vector3 targetPosition = new Vector3(mouseX, mouseY, 0);
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition + initialPosition, Time.deltaTime * swaySpeed);
    }
}