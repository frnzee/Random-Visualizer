using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public InputField minLT;
    public InputField maxLT;
    public InputField minCD;
    public InputField maxCD;

    public Figure squarePrefab;
    public Figure circlePrefab;
    public Figure trianglePrefab;

    private Figure spawnedSquare;
    private Figure spawnedCircle;
    private Figure spawnedTriangle;

    public RectTransform GameFieldCanvas;
    public float _cooldownTimer = 1.0f;
    public float lifeTime;

    public Toggle _useSquare;
    public Toggle _useCircle;
    public Toggle _useTriangle;

    public enum FigureType
    {
        None,
        Square,
        Circle,
        Triangle
    }

    private int _x, _y;
    private int _sizeX, _sizeY;
    private List<FigureType> usedFigures = new List<FigureType>();
    private FigureType randomFigure;

    void Start()
    {
        minLT.text = Random.Range(1, 5).ToString();
        maxLT.text = Random.Range(5, 10).ToString();
        minCD.text = Random.Range(1, 5).ToString();
        maxCD.text = Random.Range(5, 10).ToString();
        _sizeX = (int)GameFieldCanvas.rect.size.x;
        _sizeY = (int)GameFieldCanvas.rect.size.y;
        Debug.Log(_sizeX);
        Debug.Log(_sizeY);
        _cooldownTimer = Random.Range(int.Parse(minCD.text), int.Parse(maxCD.text));
    }
    public void SquareToggle()
    {
        if (_useSquare.isOn)
        {
            usedFigures.Add(FigureType.Square);
        }
        else
        {
            usedFigures.Remove(FigureType.Square);
        }
    }
    public void CircleToggle()
    {
        if (_useCircle.isOn)
        {
            usedFigures.Add(FigureType.Circle);
        }
        else
        {
            usedFigures.Remove(FigureType.Circle);
        }
    }
    public void TriangleToggle()
    {
        if (_useTriangle.isOn)
        {
            usedFigures.Add(FigureType.Triangle);
        }
        else
        {
            usedFigures.Remove(FigureType.Triangle);
        }
    }
    private IEnumerator SpawnObjects()
    {
        yield return new WaitForSeconds(_cooldownTimer);
        switch (randomFigure)
        {
            case FigureType.Square:
                spawnedSquare = Instantiate(squarePrefab, new Vector2(_x, _y), Quaternion.identity, GameFieldCanvas.transform);
                spawnedSquare.Initialize(lifeTime, randomFigure);
                spawnedSquare.transform.localPosition = new Vector2(_x, _y);
                break;
            case FigureType.Circle:
                spawnedCircle = Instantiate(circlePrefab, new Vector2(_x, _y), Quaternion.identity, GameFieldCanvas.transform);
                spawnedCircle.Initialize(lifeTime, randomFigure);
                spawnedCircle.transform.localPosition = new Vector2(_x, _y);
                break;
            case FigureType.Triangle:
                spawnedTriangle = Instantiate(trianglePrefab, new Vector2(_x, _y), Quaternion.identity, GameFieldCanvas.transform);
                spawnedTriangle.Initialize(lifeTime, randomFigure);
                spawnedTriangle.transform.localPosition = new Vector2(_x, _y);
                break;
        }
    }
    private void Update()
    {
        if (_cooldownTimer > 0)
        {
            _cooldownTimer -= Time.deltaTime;
            if (_cooldownTimer <= 0)
            {
                _x = Random.Range(50, _sizeX - 50);
                _y = Random.Range(50, _sizeY - 50);
                Debug.Log(_x + " " + _y);
                if (usedFigures.Count == 0)
                {
                    randomFigure = FigureType.None;
                }
                else
                {
                    randomFigure = usedFigures[Random.Range(0, usedFigures.Count)];
                }
                lifeTime = Random.Range(int.Parse(minLT.text), int.Parse(maxLT.text));
                StartCoroutine(SpawnObjects());
                _cooldownTimer = Random.Range(int.Parse(minCD.text), int.Parse(maxCD.text));
            }
        }
    }
}
