using MXX;
using PGW;
using CY;
using HYB;
using YNB;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MXX{
	public class EnemyTopCheck : MonoBehaviour {

		void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag ("Enemy"))
			{
				other.GetComponent<EnemyBehaviour> ().onTop = true;
				other.GetComponent<EnemyBehaviour> ().anim.SetBool ("OnTop",true);
			}
		}

		void OnTriggerExit(Collider other)
		{
			if (other.CompareTag ("Enemy"))
			{
				other.GetComponent<EnemyBehaviour> ().onTop = false;
				other.GetComponent<EnemyBehaviour> ().anim.SetBool ("OnTop",false);
			}
		}
	}
}
