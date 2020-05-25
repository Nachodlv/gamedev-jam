using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// <para>Runs multiple coroutines one after the other</para>
/// </summary>
public class CoroutineQueue
{
    private readonly Queue<IEnumerator> _coroutines;
    private bool _executingCoroutines;
    private readonly MonoBehaviour _monoBehaviour;
    private readonly Func<IEnumerator> _executeCoroutines;

    public CoroutineQueue(MonoBehaviour monoBehaviour, int initialQuantity)
    {
        _monoBehaviour = monoBehaviour;
        _coroutines = new Queue<IEnumerator>(initialQuantity);
        _executeCoroutines = ExecuteCoroutines;
    }

    /// <summary>
    /// <para>Adds a new coroutine to the queue. If no coroutine is executing, it will start executing the
    /// coroutine passed as parameter</para>
    /// </summary>
    /// <param name="coroutine"></param>
    public void AddCoroutine(IEnumerator coroutine)
    {
        _coroutines.Enqueue(coroutine);
        if(_executingCoroutines) return;
        _executingCoroutines = true;
        _monoBehaviour.StartCoroutine(_executeCoroutines());
    }

    private IEnumerator ExecuteCoroutines()
    {
        while (_coroutines.Count > 0)
        {
            yield return _monoBehaviour.StartCoroutine(_coroutines.Peek());
            _coroutines.Dequeue();
        }

        _executingCoroutines = false;
    }
}
