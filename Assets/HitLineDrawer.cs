using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class HitLineDrawer : MonoBehaviour
{
    private LineRenderer lineRenderer;

    public Transform center, green, yellow, red;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
    }

    private IEnumerator DrawLineForDuration(float duration)
    {
        lineRenderer.enabled = true;
        yield return new WaitForSeconds(duration);
        lineRenderer.enabled = false;

    }

    internal void DrawLine(Vector3 center, Vector3 hitPoint, float duration, float distance)
    {
        Color color = GetColor(distance);

        lineRenderer.SetPosition(0, center);
        lineRenderer.SetPosition(1, hitPoint);
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;
        lineRenderer.material.color = color;
        StartCoroutine(DrawLineForDuration(duration));
    }

    private Color GetColor(float distance)
    {
        if (distance < (center.transform.position - green.transform.position).magnitude)
        {
            GetComponent<ArcheryTarget>().onTakeDamage.Invoke();
            return Color.green;
        }
        if (distance < (center.transform.position - yellow.transform.position).magnitude)
        {
            return Color.yellow;
        }
        if (distance < (center.transform.position - red.transform.position).magnitude)
        {
            return Color.red;
        }
        return Color.white;
    }
}
