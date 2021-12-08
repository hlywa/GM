using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
	public Poolable template = null;
	private Queue<Poolable> _pool = new Queue<Poolable>();

	public Poolable Claim()
	{
		Poolable instance;

		if (_pool.Count > 0)
		{
			instance = _pool.Dequeue();
		}
		else
		{
			instance = Instantiate(template, null);

		}

		instance.SetPool(this);
		instance.enabled = true;
		instance.gameObject.SetActive(true);

		return instance;
	}

	public void Release(Poolable instance)
	{
		instance.gameObject.SetActive(false);
		instance.enabled = false;
		_pool.Enqueue(instance);
	}
}
