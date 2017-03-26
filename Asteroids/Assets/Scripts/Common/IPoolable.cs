using UnityEngine;
using System.Collections;

/// <summary>
/// Object pool inteface
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IPoolable<T>
{
    /// <summary>
    /// Create pool
    /// </summary>
    /// <param name="size">Pool size</param>
    void Create(int size);

    /// <summary>
    /// Take object from pool
    /// </summary>
    /// <returns></returns>
    T Take();

    /// <summary>
    /// Return object to pool
    /// </summary>
    /// <param name="obj">Returned object</param>
    void Release(T obj);
}
