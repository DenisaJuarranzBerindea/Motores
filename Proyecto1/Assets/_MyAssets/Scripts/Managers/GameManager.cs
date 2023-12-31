using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    #region references
    private InputManager _inputManager;
    private GameManager _gameManager;
    private UIManager _UIManager;
    #endregion
    #region methods
    /// <summary>
    /// Public method used to inform GameManager that the target has been reached
    /// </summary>
    public void OnTargetReached()
    {
        GameFinishes();
    }
    /// <summary>
    /// Public method used to inform GameManager that the player has clicked Start button
    /// </summary>
    public void OnPressedStart()
    {
        GameStarts();

    }
    /// <summary>
    /// GameManager executes this method to set required elements for Start Menu
    /// </summary>
    private void StartMenu()
    {
        _UIManager.SetMainMenu(true);
        _UIManager.SetVictoryScreen(false);
        _inputManager.enabled = false;
    }
    /// <summary>
    /// GameManager exectes this method to set required elements to start the Game
    /// </summary>
    private void GameStarts()
    {
        _UIManager.SetMainMenu(false);
        _inputManager.enabled = true;
    }
    /// <summary>
    /// GameManager executes this method to set the required elements to finish the Game
    /// </summary>
    private void GameFinishes()
    {
        _UIManager.SetVictoryScreen(true);
        _inputManager.enabled = false;
    }
    #endregion
    /// <summary>
    /// Initial setup of references and call to StartMenu
    /// </summary>
    void Start()
    {
        _inputManager = GetComponent<InputManager>();
        _gameManager = GetComponent<GameManager>();
        _UIManager = GetComponent<UIManager>();

        StartMenu();
    }
}

