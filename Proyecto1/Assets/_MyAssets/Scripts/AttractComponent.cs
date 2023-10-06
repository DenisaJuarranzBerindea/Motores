using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AttractComponent : MonoBehaviour
{
    #region parameters
    /// <summary>
    /// Parameter to regulate the attraction speed of the attraction area
    /// </summary>
    [SerializeField]
    private float _attraction = 1.0f;
    #endregion
    #region references
    /// <summary>
    /// Reference to own transform
    /// </summary>
    private Transform _myTransform;
    #endregion
    /// <summary>
    /// Called when an object stays inside the trigger area.
    /// We will evalate if collided object is a Bullet. Use duck typing!
    /// If it is a bullet, add attraction speed to the speed of the bullet.
    /// </summary>
    /// <param name="collision">Collided object</param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        BulletMovement bullet = collision.gameObject.GetComponent<BulletMovement>();

        if (bullet != null)
        {
            Vector3 attractionDirection = (_myTransform.position - bullet.transform.position).normalized;

            bullet.AddSpeed(attractionDirection * _attraction);
        }

    }

    /// <summary>
    /// Start is called before the first frame update.
    /// Set reference to own transform
    /// </summary>
    void Start()
    {
        _myTransform = transform;

    }
}