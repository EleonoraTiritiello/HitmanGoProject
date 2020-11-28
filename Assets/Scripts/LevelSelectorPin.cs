using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectorPin : MonoBehaviour
{
    #region Variables

    #region Public Variables

    public int CurrentLevelNumber { get { return _currentLevelIndex + 1; } }

    #endregion

    #region Private Variables

    [SerializeField]
    private float movementDuration = 1f;

    [Space(5)]
    [SerializeField]
    private Transform _startingPosition;
    [SerializeField]
    private Transform[] _toLevel2;
    [SerializeField]
    private Transform[] _toLevel3;
    [SerializeField]
    private Transform[] _toLevel4;
    [SerializeField]
    private Transform[] _toLevel5;
    [SerializeField]
    private Transform[] _toLevel6;
    [SerializeField]
    private Transform[] _toLevel7;

    private int _currentLevelIndex = -1;

    #endregion

    #endregion

    #region Unity Callbacks

    private void Awake()
    {
        if (PlayerPrefs.GetInt("CurrentLevelIndex", -2) == -2)
            PlayerPrefs.SetInt("CurrentLevelIndex", _currentLevelIndex);
        else
            _currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", -1);
    }

    private void Start()
    {
       MoveToLevel();
    }

    #endregion

    #region Private Methods

    private void MoveToLevel()
    {
        switch (_currentLevelIndex)
        {
            case -1:
                transform.position = _startingPosition.position;
                break;
            case 0:
                StartCoroutine(MoveToNextLevel(_toLevel2));
                break;
            case 1:
                StartCoroutine(MoveToNextLevel(_toLevel3));
                break;
            case 2:
                StartCoroutine(MoveToNextLevel(_toLevel4));
                break;
            case 3:
                StartCoroutine(MoveToNextLevel(_toLevel5));
                break;
            case 4:
                StartCoroutine(MoveToNextLevel(_toLevel6));
                break;
            case 5:
                StartCoroutine(MoveToNextLevel(_toLevel7));
                break;
            default:
                break;
        }
    }

    private IEnumerator MoveToNextLevel(Transform[] toLevel)
    {
        Vector3 _startPosition = transform.position;

        yield return new WaitForSeconds(1f);

        float totalDistance = 0f;
        float currentDistance = 1f;


        for(int i = 0; i < toLevel.Length; i++)
        {
            if (i + 1 < toLevel.Length)
                totalDistance += Mathf.Abs(Vector3.Distance(toLevel[i].position, toLevel[i + 1].position));
        }

        float elapsedTime;
        float adjustedMovementDuration;

        for (int i = 0; i < toLevel.Length; i++)
        {
            if (i - 1 >= 0) _startPosition = toLevel[i - 1].position;

            if(i + 1 < toLevel.Length)
                currentDistance = Mathf.Abs(Vector3.Distance(toLevel[i].position, toLevel[i + 1].position));

            adjustedMovementDuration = currentDistance * movementDuration / totalDistance;

            elapsedTime = 0f;

            while (elapsedTime < adjustedMovementDuration)
            {
                transform.position = Vector3.Lerp(_startPosition, toLevel[i].position, elapsedTime / adjustedMovementDuration);

                elapsedTime += Time.deltaTime;

                yield return null;
            }
        }

        _currentLevelIndex++;

        PlayerPrefs.SetInt("CurrentLevelIndex", _currentLevelIndex);

        yield return null;
    }

    #endregion
}