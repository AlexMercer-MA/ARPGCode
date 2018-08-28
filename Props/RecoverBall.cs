using MXX;
using PGW;
using CY;
using HYB;
using YNB;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MXX{
	public class RecoverBall : MonoBehaviour 
	{

		void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				PlayerPropertiesFinal.GetInstance.ChangeHP(0.25f);
				PlayerPropertiesFinal.GetInstance.ChangeSP(0.25f);
			}
		}
	}
}
