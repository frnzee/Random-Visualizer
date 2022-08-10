using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Figure : MonoBehaviour
{
    public GameObject spawnedSquare;
    public GameObject spawnedCircle;
    public GameObject spawnedTriangle;
    private string r;
    private float _lifeTime;
    public void Initialize(float lifeTime, string randomFigure)
    {
        _lifeTime = lifeTime;
        r = randomFigure;
    }
    public void Update()
    {
        switch (r)
        {
            case "Square":
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
            case "Circle":
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
            case "Triangle":
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
