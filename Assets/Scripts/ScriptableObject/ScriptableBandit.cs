using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Bandit �� ������Ʈ���� �ʱⰪ�� ������ �ֽ��ϴ�.
/// </summary>
[CreateAssetMenu(fileName ="ScriptableBandit",menuName ="ScriptableObject/Bandit")]
public class ScriptableBandit : ScriptableObject
{
	public float Hp = 1f;
	public float attack = 0f;
	public float runSpeed = 8f;
	public GameObject prefab;
}
