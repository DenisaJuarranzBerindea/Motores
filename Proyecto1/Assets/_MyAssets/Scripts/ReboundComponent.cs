using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ReboundComponent : MonoBehaviour
{
    #region methods
    /// <summary>
    /// This method detects if the collided object is a bullet. Use duck typing!
    /// If it is a bullet, the movement direction is set to fake a rebound on the surface:
    /// Normal, tangent, dot product and cross product will be required to accomplish this
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        BulletMovement bullet = collision.gameObject.GetComponent<BulletMovement>();

        if(bullet != null)
        {
            Vector3 normal = collision.GetContact(0).normal;

            Vector3 reflexion = bullet.Speed.normalized - 2 * Vector3.Dot(bullet.Speed.normalized, normal) * normal;

            bullet.SetDirection(reflexion.normalized);
        }
        
    }
    #endregion
}