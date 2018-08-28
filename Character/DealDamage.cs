//using MXX;
//using PGW;
//using CY;
//using HYB;
//using YNB;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using SnazzlebotTools.ENPCHealthBars;
//
//namespace MXX{
//	public class DealDamage : MonoBehaviour {
//
//		GameObject player;
//		public List<GameObject> beenHit;
//		public float damage;
//
//		void Awake()
//		{
//			player = GameObject.FindGameObjectWithTag ("Player");
//		}
//
//		void OnTriggerEnter(Collider other)
//		{
//			if (other.CompareTag("Enemy")&&beenHit.Contains(other.transform.gameObject)==false)
//			{
//				beenHit.Add(other.transform.gameObject);
//				other.transform.GetComponent<EnemyProperties>().TakePhysicalDamage (Mathf.RoundToInt(damage),PlayerPropertiesFinal.GetInstace.ArmorPeneNumberFinal,PlayerPropertiesFinal.GetInstace.ArmorPenePercentFinal);
//				//Debug.Log ("attack");
//			}
//		}
//	}
//}