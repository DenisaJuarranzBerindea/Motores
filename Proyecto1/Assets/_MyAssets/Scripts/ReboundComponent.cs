using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
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

            Vector3 normal = collision.GetContact(0).normal; // Normal dirección al muro

            // Metodo 1:

            Vector3 wall = Vector3.Cross(Vector3.forward, normal);

            float cWall = Vector3.Dot(wall, bullet.Speed.normalized);
            float cNormal = Vector3.Dot(bullet.Speed.normalized, normal);

            Vector3 reflexion1 = cWall * wall + (cNormal * normal * -1);

            bullet.SetDirection(reflexion1.normalized);


            // Método 2:

            //Vector3 reflexion2 = bullet.Speed.normalized - 2 * Vector3.Dot(bullet.Speed.normalized, normal) * normal;

            //bullet.SetDirection(reflexion2.normalized);
        }
        
    }
    #endregion
}