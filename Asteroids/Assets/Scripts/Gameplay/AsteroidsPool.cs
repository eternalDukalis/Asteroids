using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Asteroids pool
/// </summary>
public class AsteroidsPool : MonoBehaviour, IPoolable<GameObject>
{
    /// <summary>
    /// Pool size
    /// </summary>
    public int Size { get { return _size; } }

    [SerializeField]
    int _size;
    [SerializeField]
    GameObject asteroidPrefab;
    Stack<GameObject> objectsStack;

    /// <summary>
    /// Current instance
    /// </summary>
    public static AsteroidsPool Instance { get { return _instance; } }

    static AsteroidsPool _instance;

	void Start ()
    {
        if (_instance != null)
            Destroy(_instance);
        _instance = this;
        Create(_size);
	}

    /// <summary>
    /// Create asteroids pool
    /// </summary>
    /// <param name="size">Initial pool size</param>
    public void Create(int size)
    {
        _size = size;
        objectsStack = new Stack<GameObject>();
        for (int i = 0; i < size; i++)
        {
            GameObject obj = Instantiate(asteroidPrefab);
            Init(obj);
            objectsStack.Push(obj);
        }
    }

    /// <summary>
    /// Take asteroid from pool
    /// </summary>
    /// <returns></returns>
    public GameObject Take()
    {
        if (objectsStack.Count == 0)
            return TakeFromEmpty();
        return objectsStack.Pop();
    }

    /// <summary>
    /// Return asteroid to pool
    /// </summary>
    /// <param name="obj">Returned asteroid</param>
    public void Release(GameObject obj)
    {
        objectsStack.Push(obj);
    }

    /// <summary>
    /// Take object from empty pool
    /// </summary>
    /// <returns></returns>
    GameObject TakeFromEmpty()
    {
        GameObject res = Instantiate(asteroidPrefab);
        Init(res);
        _size++;
        return res;
    }

    void Init(GameObject obj)
    {

    }
}
