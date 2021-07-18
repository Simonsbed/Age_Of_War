using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

	private Button moneyButton;
	private Button spawnButton;

	private UnityAction MoneyBtnAction;
	//private Button 
	private Text moneyTxt;
	private Text expTxt;

	


	private void Awake()
	{
		moneyTxt = GameObject.Find("MoneyText").GetComponent<Text>();
		/*expTxt = GameObject.Find("expText").GetComponent<Text>();
		*/
	}

	/// <summary>
	/// ���� ���Ӱ� ��Ĩ�ϴ�.
	/// </summary>
	/// <param name="context">������ ����� ��</param>
	/// <param name="origin">������ ��� Object</param>
	public void RefreshText(string context, Text origin)
	{
		string data = origin.text;
		int replaceOrder = data.IndexOf(":");
		data.Substring(0, replaceOrder+1);

		data += context;

		origin.text = data;
	}


	void MoneyButton()
	{
		moneyButton.onClick.AddListener(() => RefreshText(GameManager.instance.money.ToString(), moneyTxt));
		// += RefreshText("asas", moneyTxt);
		//moneyButton.onClick.AddListener(RefreshText());
	}

	
}
