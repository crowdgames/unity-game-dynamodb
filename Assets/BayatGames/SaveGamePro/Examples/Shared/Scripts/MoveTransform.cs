using UnityEngine;
using System.Collections;

namespace BayatGames.SaveGamePro.Examples
{

	/// <summary>
	/// Move transform.
	/// Allows the user to control the transform by input.
	/// </summary>
	public class MoveTransform : MonoBehaviour
	{
		
		/// <summary>
		/// The speed.
		/// </summary>
		public float speed = 0.1f;

		void Update ()
		{
			Vector3 position = transform.position;
			position.x += Input.GetAxis ( "Horizontal" ) * speed;
			position.z += Input.GetAxis ( "Vertical" ) * speed;
			transform.position = position;
		}
	
	}
	
}