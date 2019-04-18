using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Cloth serialization implementation.
	/// </summary>
	public class SaveGameType_Cloth : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.Cloth );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.Cloth cloth = ( UnityEngine.Cloth )value;
			writer.WriteProperty ( "sleepThreshold", cloth.sleepThreshold );
			writer.WriteProperty ( "bendingStiffness", cloth.bendingStiffness );
			writer.WriteProperty ( "stretchingStiffness", cloth.stretchingStiffness );
			writer.WriteProperty ( "damping", cloth.damping );
			writer.WriteProperty ( "externalAcceleration", cloth.externalAcceleration );
			writer.WriteProperty ( "randomAcceleration", cloth.randomAcceleration );
			writer.WriteProperty ( "useGravity", cloth.useGravity );
			writer.WriteProperty ( "enabled", cloth.enabled );
			writer.WriteProperty ( "friction", cloth.friction );
			writer.WriteProperty ( "collisionMassScale", cloth.collisionMassScale );
			#if UNITY_2017_2_OR_NEWER
			writer.WriteProperty ( "enableContinuousCollision", cloth.enableContinuousCollision );
			#else
			writer.WriteProperty ( "useContinuousCollision", cloth.useContinuousCollision );
			#endif
			writer.WriteProperty ( "useVirtualParticles", cloth.useVirtualParticles );
			writer.WriteProperty ( "coefficients", cloth.coefficients );
			writer.WriteProperty ( "worldVelocityScale", cloth.worldVelocityScale );
			writer.WriteProperty ( "worldAccelerationScale", cloth.worldAccelerationScale );
			#if UNITY_2017_2_OR_NEWER
			writer.WriteProperty ( "clothSolverFrequency", cloth.clothSolverFrequency );
			#else
			writer.WriteProperty ( "solverFrequency", cloth.solverFrequency );
			#endif
			writer.WriteProperty ( "capsuleColliders", cloth.capsuleColliders );
			writer.WriteProperty ( "sphereColliders", cloth.sphereColliders );
			writer.WriteProperty ( "tag", cloth.tag );
			writer.WriteProperty ( "name", cloth.name );
			writer.WriteProperty ( "hideFlags", cloth.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.Cloth cloth = SaveGameType.CreateComponent<UnityEngine.Cloth> ();
			ReadInto ( cloth, reader );
			return cloth;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.Cloth cloth = ( UnityEngine.Cloth )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "sleepThreshold":
						cloth.sleepThreshold = reader.ReadProperty<System.Single> ();
						break;
					case "bendingStiffness":
						cloth.bendingStiffness = reader.ReadProperty<System.Single> ();
						break;
					case "stretchingStiffness":
						cloth.stretchingStiffness = reader.ReadProperty<System.Single> ();
						break;
					case "damping":
						cloth.damping = reader.ReadProperty<System.Single> ();
						break;
					case "externalAcceleration":
						cloth.externalAcceleration = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "randomAcceleration":
						cloth.randomAcceleration = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "useGravity":
						cloth.useGravity = reader.ReadProperty<System.Boolean> ();
						break;
					case "enabled":
						cloth.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "friction":
						cloth.friction = reader.ReadProperty<System.Single> ();
						break;
					case "collisionMassScale":
						cloth.collisionMassScale = reader.ReadProperty<System.Single> ();
						break;
					#if UNITY_2017_2_OR_NEWER
					case "enableContinuousCollision":
						cloth.enableContinuousCollision = reader.ReadProperty<System.Boolean> ();
						break;
					#else
					case "useContinuousCollision":
						cloth.useContinuousCollision = reader.ReadProperty<System.Single> ();
						break;
					#endif
					case "useVirtualParticles":
						cloth.useVirtualParticles = reader.ReadProperty<System.Single> ();
						break;
					case "coefficients":
						cloth.coefficients = reader.ReadProperty<UnityEngine.ClothSkinningCoefficient []> ();
						break;
					case "worldVelocityScale":
						cloth.worldVelocityScale = reader.ReadProperty<System.Single> ();
						break;
					case "worldAccelerationScale":
						cloth.worldAccelerationScale = reader.ReadProperty<System.Single> ();
						break;
					#if UNITY_2017_2_OR_NEWER
					case "clothSolverFrequency":
						cloth.clothSolverFrequency = reader.ReadProperty<System.Single> ();
						break;
					#else
					case "solverFrequency":
						cloth.solverFrequency = reader.ReadProperty<System.Boolean> ();
						break;
					#endif
					case "capsuleColliders":
						cloth.capsuleColliders = reader.ReadProperty<UnityEngine.CapsuleCollider []> ();
						break;
					case "sphereColliders":
						cloth.sphereColliders = reader.ReadProperty<UnityEngine.ClothSphereColliderPair []> ();
						break;
					case "tag":
						cloth.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						cloth.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						cloth.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}