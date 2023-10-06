using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InputManager : MonoBehaviour
{
    #region references
    /// <summary>
    /// Reference to player's LookAtPositionComponent
    /// </summary>
    [SerializeField]
    private LookAtPositionComponent _playerLookAt;

    /// <summary>
    /// Reference to player's ShootingComponent
    /// </summary>
    [SerializeField]
    private ShootingComponent _playerShooting;
    #endregion

    /// <summary>
    /// 1. Update look at position
    /// 2. Receive button input and shoot bullet when it occurs
    /// </summary>
    void Update()
    {
        //Dirección del cañón
        _playerLookAt.SetLookAtPosition(Input.mousePosition);

        //Disparo
        if (Input.GetMouseButtonDown(0))
        {
            _playerShooting.Shoot();
        }


    }
}