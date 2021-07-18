using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;

public class GameManager : MonoBehaviour
{
    public float money;
    public float exp;

    public const float MAX_MONEY = float.MaxValue;
    public const float MAX_EXP = float.MaxValue;

    public static GameManager instance;//�̱��� ������ ���� ������ ���� ����
    //public ObjectPool objectPool = new ObjectPool()

    private void Awake()
    {
        Singleton.SetPattern(ref instance, this, gameObject, false);
    }
    


    /// <summary>
    /// Ư�� ���� �� �� ����մϴ�. ����, ���п��θ� Ȯ�� �� �� �ֽ��ϴ�.
    /// </summary>
    /// <param name="data">���� �� ���</param>
    /// <param name="amount">�󸶸�ŭ ���� �� ���� ����</param>
    /// <returns>true => ����, false => ����</returns>
    public bool Consume(ref float data, float amount)
	{
        if (data - amount < 0) //���� �ΰ��� ���
        {
            return false;
        }
        else
        {
            data -= amount;
            return true;
        }
	}
    /// <summary>
    /// Ư�� ���� ���� �� ����մϴ�. ����, ���п��θ� Ȯ�� �� �� �ֽ��ϴ�.
    /// </summary>
    /// <param name="data">���� ���� ���</param>
    /// <param name="amount">�󸶸�ŭ ���� ���� ���� ����</param>
    /// <returns>����, ���� ����</returns>
    public bool Rise(ref float data, float amount, float MAX_VALUE)
	{

		if (float.IsInfinity(data+amount) || data+amount > MAX_VALUE)
		{
            return false;
		}
		else
		{
            data += amount;
            return true;
		}
	}
}
