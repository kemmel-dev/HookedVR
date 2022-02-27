using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Bullet : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.CompareTag("Target"))
        {

            Vector3 hitPoint = collision.contacts[0].point;
            Vector3 center = collision.rigidbody.transform.GetChild(0).position;

            float distance = (hitPoint - center).magnitude;
            
            collision.rigidbody.GetComponent<HitLineDrawer>().DrawLine(hitPoint, center, 30f, distance);
        }

        if (collision.rigidbody.CompareTag("Balloon"))
        {
            Debug.Log("?");
            collision.rigidbody.GetComponent<Balloon>().ApplyDamage();
        }
    }
}
