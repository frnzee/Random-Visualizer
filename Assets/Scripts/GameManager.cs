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
    private GameObject gameFieldCanvas;
    public float _cooldownTimer = 1.0f;
    public float lifeTime;
    public Toggle _useSquare;
    public Toggle _useCircle;
    public Toggle _useTriangle;
    private int x, y, z;
    private List<string> usedFigures = new List<string>();
    private string randomFigure;
    void Start()
    {
        minLT.text = Random.Range(1, 5).ToString();
        maxLT.text = Random.Range(5, 10).ToString();
        minCD.text = Random.Range(1, 5).ToString();
        maxCD.text = Random.Range(5, 10).ToString();
        gameFieldCanvas = GameObject.FindWithTag("Canvas");
        _cooldownTimer = Random.Range(int.Parse(minCD.text), int.Parse(maxCD.text));
    }
    public void SquareToggle()
    {
        if (_useSquare.isOn)
        {
            usedFigures.Add("Square");
        }
        else
        {
            usedFigures.Remove("Square");
        }
    }
    public void CircleToggle()
    {
        if (_useCircle.isOn)
        {
            usedFigures.Add("Circle");
        }
        else
        {
            usedFigures.Remove("Circle");
        }
    }
    public void TriangleToggle()
    {
        if (_useTriangle.isOn)
        {
            usedFigures.Add("Triangle");
        }
        else
        {
            usedFigures.Remove("Triangle");
        }
    }
    private IEnumerator SpawnObjects()
    {
        yield return new WaitForSeconds(_cooldownTimer);
        switch (randomFigure)
        {
            case "Square":
                spawnedSquare = Instantiate(squarePrefab, new Vector3(x, y, z), Quaternion.identity, gameFieldCanvas.transform);
                spawnedSquare.Initialize(lifeTime, randomFigure);
                break;
            case "Circle":
                spawnedCircle = Instantiate(circlePrefab, new Vector3(x, y, z), Quaternion.identity, gameFieldCanvas.transform);
                spawnedCircle.Initialize(lifeTime, randomFigure);
                break;
            case "Triangle":
                spawnedTriangle = Instantiate(trianglePrefab, new Vector3(x, y, z), Quaternion.identity, gameFieldCanvas.transform);
                spawnedTriangle.Initialize(lifeTime, randomFigure);
                break;
        }
    }
    void Update()
    {
        if (_cooldownTimer > 0)
        {
            _cooldownTimer -= Time.deltaTime;
            if (_cooldownTimer <= 0)
            {
                x = Random.Range(50, 360);
                y = Random.Range(50, 490);
                z = 1;
                if (usedFigures.Count == 0)
                {
                    randomFigure = "";
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
