using UnityEngine;
using UnityEngine.UI;

public class Figure : MonoBehaviour
{
    private float _lifeTime;
    public void Initialize(float lifeTime)
    {
        _lifeTime = lifeTime;
    }
    public void Update()
    {
        if (_lifeTime > 0)
        {
            _lifeTime -= Time.deltaTime;
            gameObject.GetComponentInChildren<Text>().text = _lifeTime.ToString("F1");
            if (_lifeTime <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
