using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LookAtPositionComponent : MonoBehaviour
{
    #region references
    /// <summary>
    /// Referene to own transform
    /// </summary>
    private Transform _myTransform;
    /// <summary>
    /// Referene to scene main camera
    /// </summary>
    private Camera _cam;
    #endregion
    /// <summary>
    /// Point to look at
    /// </summary>
    #region properties
    private Vector3 _lookAtPosition = Vector3.up;       // CAMBIAR POR PREGUNTA
    #endregion
    #region methods
    public void SetLookAtPosition(Vector3 mousePosition)
    {
        _lookAtPosition = _cam.ScreenToWorldPoint(mousePosition);
    }
    #endregion
    /// <summary>
    /// Set reference to own transform
    /// </summary>
    void Start()
    {
        _myTransform = transform;
        _cam = Camera.main;
    }
    /// <summary>
    /// Set rotation to make the player look at the lookAtPosition
    /// This is difficult to understand, so the code has been kept for students to use it
    /// </summary>
    void Update()
    {
        Quaternion rotation = Quaternion.LookRotation
            (_lookAtPosition - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
    }
}