using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Figure : MonoBehaviour
{
    public GameObject spawnedSquare;
    public GameObject spawnedCircle;
    public GameObject spawnedTriangle;
    private GameManager.FigureType ChosenFigure;
    private float _lifeTime;
    public void Initialize(float lifeTime, GameManager.FigureType randomFigure)
    {
        _lifeTime = lifeTime;
        ChosenFigure = randomFigure;
    }
    public void Update()
    {
        switch (ChosenFigure)
        {
            case GameManager.FigureType.None:
                break;
            case GameManager.FigureType.Square:
                if (_lifeTime > 0)
                {
                    _lifeTime -= Time.deltaTime;
                    spawnedSquare.GetComponentInChildren<Text>().text = _lifeTime.ToString("F1");
                    if (_lifeTime <= 0)
                    {
                        Destroy(spawnedSquare);
                    }
                }
                break;
            case GameManager.FigureType.Circle:
                if (_lifeTime > 0)
                {
                    _lifeTime -= Time.deltaTime;
                    spawnedCircle.GetComponentInChildren<Text>().text = _lifeTime.ToString("F1");
                    if (_lifeTime <= 0)
                    {
                        Destroy(spawnedCircle);
                    }
                }
                break;
            case GameManager.FigureType.Triangle:
                if (_lifeTime > 0)
                {
                    _lifeTime -= Time.deltaTime;
                    spawnedTriangle.GetComponentInChildren<Text>().text = _lifeTime.ToString("F1");
                    if (_lifeTime <= 0)
                    {
                        Destroy(spawnedTriangle);
                    }
                }
                break;
        }
    }
}
