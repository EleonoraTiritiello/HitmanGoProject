using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c> SwipeController </c> contains the methods for player movement with swipe inputs
/// </summary>
public class Swipe : MonoBehaviour
{
    #region Variables

    #region Public Variables

    /// <summary>
    /// Bool
    /// </summary>
    public bool tap, swipeLeft, swipeRight, swipeUp, swipeDown, playerSelect;

    /// <summary>
    /// Change the area where is possible cancel the action before the movement
    /// </summary>
    public float ActionDetection;

    public GameObject target;

    #endregion

    #region Private Variables

    /// <summary>
    /// Bool variable for detect dragging
    /// </summary>
    private bool _isDragging = false;
    /// <summary>
    /// Touch start point
    /// </summary>
    private Vector2 _startTouch;
    /// <summary>
    /// Swipe direction detection
    /// </summary>
    private Vector2 _swipeDelta;

    #endregion

    #endregion

    #region Unity Callbacks

    private void Update()
    {
        ResetTap();
        MobileInput();
        MouseInput();
        CalculateDelta();
    }

    void OnMouseOver()
    {
        playerSelect = true;
    }
    void OnMouseExit()
    {
        playerSelect = false;
    }


    #endregion

    #region Calculate Delta

    /// <summary>
    /// Method to calculate the direction of the swipe
    /// </summary>

    void CalculateDelta()
    {
        _swipeDelta = Vector2.zero;
        if (_isDragging)
        {
            if (Input.touches.Length < 0)
                _swipeDelta = Input.touches[0].position - _startTouch;
            else if (Input.GetMouseButton(0))
                _swipeDelta = (Vector2)Input.mousePosition - _startTouch;
        }

        if (_swipeDelta.magnitude > ActionDetection)
        {
            float x = _swipeDelta.x;
            float y = _swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
            }
            else
            {
                if (y < 0)
                    swipeDown = true;
                else
                    swipeUp = true;
            }
            Reset();
        }
    }

    #endregion

    #region Mouse Input

    /// <summary>
    /// Get input from mouse
    /// </summary>
    private void MouseInput()
    {
        if (Input.GetMouseButtonDown(0) && playerSelect == true)
            StartDrag(Input.mousePosition);
        else if (Input.GetMouseButtonUp(0))
            Reset();        
    }

    #endregion

    #region Mobile Input

    /// <summary>
    /// Get input from mobile touch
    /// </summary>
    private void MobileInput()
    {

        if (Input.touches.Length > 0 && playerSelect == true)
        {
            if (Input.touches[0].phase == TouchPhase.Began)          
                StartDrag(Input.touches[0].position);
            
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
                Reset();
        }
    }

    #endregion

    #region Start Dragging
    private void StartDrag(Vector2 touchPoint)
    {
        tap = true;
        _isDragging = true;
        _startTouch = touchPoint;
    }

    #endregion

    #region Reset

    /// <summary>
    /// Reset dragging to false
    /// </summary>
    private void Reset()
    {
        _startTouch = _swipeDelta = Vector2.zero;
        _isDragging = false;
    }

    #endregion

    #region Reset Tap
    /// <summary>
    /// Reset tap and swipe variables
    /// </summary>
    private void ResetTap()
    {
        tap = false;
        swipeDown = false;
        swipeLeft = false;
        swipeRight = false;
        swipeUp = false;
    }

    #endregion
}

