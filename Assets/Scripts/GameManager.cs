using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public InputField MinLT;
    public InputField MaxLT;
    public InputField MinCD;
    public InputField MaxCD;

    public Figure SquarePrefab;
    public Figure CirclePrefab;
    public Figure TrianglePrefab;

    public RectTransform GameFieldCanvas;

    private float _cooldownTimer = 1.0f;

    public Toggle UseSquare;
    public Toggle UseCircle;
    public Toggle UseTriangle;

    public enum FigureType
    {
        None,
        Square,
        Circle,
        Triangle
    }

    private int _x, _y;
    private int _sizeX, _sizeY;

    private List<FigureType> _usedFigures = new List<FigureType>();
    private FigureType _randomFigure;

    void Start()
    {
        MinLT.text = Random.Range(1, 5).ToString();
        MaxLT.text = Random.Range(5, 10).ToString();
        MinCD.text = Random.Range(1, 5).ToString();
        MaxCD.text = Random.Range(5, 10).ToString();

        _sizeX = (int)GameFieldCanvas.rect.size.x;
        _sizeY = (int)GameFieldCanvas.rect.size.y;

        _cooldownTimer = Random.Range(int.Parse(MinCD.text), int.Parse(MaxCD.text));
    }

    public void SquareToggle()
    {
        if (UseSquare.isOn)
        {
            _usedFigures.Add(FigureType.Square);
        }
        else
        {
            _usedFigures.Remove(FigureType.Square);
        }
    }
    public void CircleToggle()
    {
        if (UseCircle.isOn)
        {
            _usedFigures.Add(FigureType.Circle);
        }
        else
        {
            _usedFigures.Remove(FigureType.Circle);
        }
    }
    public void TriangleToggle()
    {
        if (UseTriangle.isOn)
        {
            _usedFigures.Add(FigureType.Triangle);
        }
        else
        {
            _usedFigures.Remove(FigureType.Triangle);
        }
    }

    private IEnumerator SpawnObjects(float lifeTime)
    {
        yield return new WaitForSeconds(_cooldownTimer);
        switch (_randomFigure)
        {
            case FigureType.Square:
                var spawnedSquare = Instantiate(SquarePrefab, GameFieldCanvas.transform);
                spawnedSquare.transform.localPosition = new Vector2(_x, _y);
                spawnedSquare.Initialize(lifeTime);
                break;
            case FigureType.Circle:
                var spawnedCircle = Instantiate(CirclePrefab, GameFieldCanvas.transform);
                spawnedCircle.transform.localPosition = new Vector2(_x, _y);
                spawnedCircle.Initialize(lifeTime);
                break;
            case FigureType.Triangle:
                var spawnedTriangle = Instantiate(TrianglePrefab, GameFieldCanvas.transform);
                spawnedTriangle.transform.localPosition = new Vector2(_x, _y);
                spawnedTriangle.Initialize(lifeTime);
                break;
        }
    }

    private void Spawn()
    {
        if (_usedFigures.Count == 0)
        {
            _randomFigure = FigureType.None;
        }
        else
        {
            _x = Random.Range(50, _sizeX - 50);
            _y = Random.Range(50, _sizeY - 50);

            _randomFigure = _usedFigures[Random.Range(0, _usedFigures.Count)];

            var lifeTime = Random.Range(int.Parse(MinLT.text), int.Parse(MaxLT.text));
            StartCoroutine(SpawnObjects(lifeTime));
        }
    }

    private void Update()
    {
        if (_cooldownTimer > 0)
        {
            _cooldownTimer -= Time.deltaTime;
            if (_cooldownTimer <= 0)
            {
                Spawn();
                _cooldownTimer = Random.Range(int.Parse(MinCD.text), int.Parse(MaxCD.text));
            }
        }
    }
}
