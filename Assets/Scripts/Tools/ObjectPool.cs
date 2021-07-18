using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public enum ObjectPoolPolicy
{
	EMPTYABLE,
	NOT_EMPTYABLE
}*/

public class ObjectPool : IObjectPool
{

	public Queue<GameObject> pool;
	private ObjectPoolPolicy policy;
	private GameObject poolCashe;

	/// <summary>
	/// ObjectPool�� �ʱ�ȭ �մϴ�.
	/// </summary>
	/// <param name="_origin">������Ʈ Ǯ���� ������ GameObject �����Դϴ�. Prefab�� ������ ��õ�帳�ϴ�.</param>
	/// <param name="_policy">������Ʈ Ǯ�� ���� ��å�Դϴ�.</param>
	public ObjectPool(GameObject _origin, ObjectPoolPolicy _policy)
	{
		pool = new Queue<GameObject>();
		policy = _policy;
		poolCashe = _origin;
	}
	/// <summary>
	/// ObjectPool�� �ʱ�ȭ �մϴ�.
	/// </summary>
	/// <param name="_origin">������Ʈ Ǯ���� ������ GameObject �����Դϴ�. Prefab�� ������ ��õ�帳�ϴ�.</param>
	/// <param name="_initSize">������Ʈ Ǯ���� Ǯ�� �������Դϴ�.</param>
	public ObjectPool(GameObject _origin, int _initSize)
	{
		pool = new Queue<GameObject>();
		for (int i = 0; i < _initSize; i++)
		{
			poolCashe = Object.Instantiate(_origin);
			pool.Enqueue(poolCashe);
			poolCashe.SetActive(false);
		}
	}

	public GameObject Pop()
	{
		if (pool.Count == 0)
		{
			if (policy == ObjectPoolPolicy.EMPTYABLE) return null; //Ǯ�� ������� null���
			else { }//Add();
		}
		return pool.Dequeue();

	}

	public void Add(GameObject o)
	{
		o.SetActive(false);
		pool.Enqueue(o);
	}

	public void Recycle(ref GameObject target )
	{
		pool.Enqueue(target);
		target.SendMessage("Init", SendMessageOptions.RequireReceiver);//������Ʈ �ʱ�ȭ �Լ� ����, �ʱ�ȭ �Լ�(Init)�� ������ ������� ���� �� ����
		target.SetActive(false);
	}


}
