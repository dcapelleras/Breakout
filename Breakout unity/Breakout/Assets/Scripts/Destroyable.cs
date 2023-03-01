using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    [SerializeField] int pointsWorthDestroying;
    [SerializeField] int hitPoints;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            hitPoints--;
            if (hitPoints == 0)
            {
                GameManager.instance.AddPoints(pointsWorthDestroying);
                gameObject.SetActive(false);
            }
        }
    }
}
