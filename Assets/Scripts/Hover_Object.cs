using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover_Object : MonoBehaviour
{
    [Header("Rotation Settings")]
    [Tooltip("Rotation speed on each axis (degrees per second)")]
    public Vector3 rotationSpeed = new Vector3(0f, 45f, 0f);

    [Header("Hover / Bob Settings")]
    [Tooltip("How high the object bobs up and down (in units)")]
    public float hoverAmplitude = 0.1f;

    [Tooltip("How fast the object bobs up and down")]
    public float hoverFrequency = 1.5f;

    // Stores the original position so we always bob relative to it
    private Vector3 _startPosition;

    void Start()
    {
        _startPosition = transform.position;
    }

    void Update()
    {
        // --- Continuous rotation ---
        transform.Rotate(rotationSpeed * Time.deltaTime, Space.Self);

        // --- Hover / bob motion ---
        float offsetY = Mathf.Sin(Time.time * hoverFrequency * Mathf.PI * 2f) * hoverAmplitude;
        transform.position = _startPosition + new Vector3(0f, offsetY, 0f);
    }
}
