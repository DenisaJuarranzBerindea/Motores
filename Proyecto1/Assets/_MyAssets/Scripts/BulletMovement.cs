using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
public class BulletMovement : MonoBehaviour
{
    #region parameters
    /// <summary>
    /// Translation speed of the bullet
    /// </summary>
    [SerializeField]
    private float _speedValue = 1.0f;   // Speed magnitude
    #endregion

    #region references
    private Transform _myTransform;
    private Camera _cam;
    #endregion

    #region properties
    private Vector3 _speed; // Movement direction
    public Vector3 Speed
    {
        get { return _speed; }
    }
    #endregion

    #region methods
    /// <summary>
    /// Method to set the direction for the translation of the bullet.
    /// </summary>
    /// <param name="newDirection">Set direction</param>
    public void SetDirection(Vector3 newDirection)
    {
        _speed = newDirection.normalized;
        _speed *= _speedValue;
    }
    /// <summary>
    /// Method to add speed to the bullet while keeping it module is kept constant
    /// 1. Add the desired extra speed.
    /// 2. Normalize speed
    /// 3. Multiplay per _speed value
    /// </summary>
    /// <param name="speedToAdd">Speed to be added (vector)</param>
    public void AddSpeed(Vector3 speedToAdd)
    {
        _speed += speedToAdd;
        _speed.Normalize();
        _speed *= _speedValue;
    }
    /// <summary>
    /// Method to set the initial direction of the bullet
    /// </summary>
    /// <param name="direction">Set direction</param>
    public void Setup(Vector2 direction)
    {
        _speed = new Vector3(direction.x, direction.y, 0f);
        _speed.Normalize();
        _speed *= _speedValue;
    }
    /// <summary>
    /// Method to destroy bullet when exits limits
    /// </summary>
    private void DestoyBullet()
    {
        if (Mathf.Abs(_myTransform.position.x) > _cam.orthographicSize * ((float)Screen.width / Screen.height) || 
            Mathf.Abs(_myTransform.position.y) > _cam.orthographicSize)
        {
            Destroy(gameObject);
        }
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
    /// Update position according to speed and time
    /// </summary>
    void Update()
    {
        _myTransform.position += _speed * Time.deltaTime;
        DestoyBullet();
    }
}
