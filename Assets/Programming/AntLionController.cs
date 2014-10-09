using UnityEngine;
using System.Collections;

public class AntLionController : MonoBehaviour
{
	public float AttackDelay = 1f;
	public float MoveTime = 0.5f;
	Animator anim;

	void Start()
	{
		anim = GetComponent<Animator>();
	}

	void Update()
	{
		
	}

	IEnumerator Attack(Vector3 location)
	{
		anim.CrossFade("Attack", 0.1f);
		//Quaternion newRot = Quaternion.LookRotation(transform.forward, location - transform.position);
		//transform.rotation = newRot;
		yield return new WaitForSeconds(AttackDelay);
		transform.position = Vector3.Lerp(transform.position, location, (1f / MoveTime) * Time.deltaTime);
	}
}
