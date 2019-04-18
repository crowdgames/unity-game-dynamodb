using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type ParticleSystem serialization implementation.
	/// </summary>
	public class SaveGameType_ParticleSystem : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.ParticleSystem );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.ParticleSystem particleSystem = ( UnityEngine.ParticleSystem )value;
			writer.WriteProperty ( "collision", particleSystem.collision );
			writer.WriteProperty ( "colorBySpeed", particleSystem.colorBySpeed );
			writer.WriteProperty ( "colorOverLifetime", particleSystem.colorOverLifetime );
			writer.WriteProperty ( "customData", particleSystem.customData );
			writer.WriteProperty ( "emission", particleSystem.emission );
			writer.WriteProperty ( "externalForces", particleSystem.externalForces );
			writer.WriteProperty ( "forceOverLifetime", particleSystem.forceOverLifetime );
			writer.WriteProperty ( "inheritVelocity", particleSystem.inheritVelocity );
			writer.WriteProperty ( "lights", particleSystem.lights );
			writer.WriteProperty ( "limitVelocityOverLifetime", particleSystem.limitVelocityOverLifetime );
			writer.WriteProperty ( "main", particleSystem.main );
			writer.WriteProperty ( "noise", particleSystem.noise );
			writer.WriteProperty ( "rotationBySpeed", particleSystem.rotationBySpeed );
			writer.WriteProperty ( "rotationOverLifetime", particleSystem.rotationOverLifetime );
			writer.WriteProperty ( "shape", particleSystem.shape );
			writer.WriteProperty ( "sizeBySpeed", particleSystem.sizeBySpeed );
			writer.WriteProperty ( "sizeOverLifetime", particleSystem.sizeOverLifetime );
			writer.WriteProperty ( "subEmitters", particleSystem.subEmitters );
			writer.WriteProperty ( "textureSheetAnimation", particleSystem.textureSheetAnimation );
			writer.WriteProperty ( "trails", particleSystem.trails );
			writer.WriteProperty ( "trigger", particleSystem.trigger );
			writer.WriteProperty ( "velocityOverLifetime", particleSystem.velocityOverLifetime );
			writer.WriteProperty ( "time", particleSystem.time );
			writer.WriteProperty ( "randomSeed", particleSystem.randomSeed );
			writer.WriteProperty ( "useAutoRandomSeed", particleSystem.useAutoRandomSeed );
			writer.WriteProperty ( "tag", particleSystem.tag );
			writer.WriteProperty ( "name", particleSystem.name );
			writer.WriteProperty ( "hideFlags", particleSystem.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.ParticleSystem particleSystem = SaveGameType.CreateComponent<UnityEngine.ParticleSystem> ();
			ReadInto ( particleSystem, reader );
			return particleSystem;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.ParticleSystem particleSystem = ( UnityEngine.ParticleSystem )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "collision":
						reader.ReadIntoProperty<UnityEngine.ParticleSystem.CollisionModule> ( particleSystem.collision );
						break;
					case "colorBySpeed":
						reader.ReadIntoProperty<UnityEngine.ParticleSystem.ColorBySpeedModule> ( particleSystem.colorBySpeed );
						break;
					case "colorOverLifetime":
						reader.ReadIntoProperty<UnityEngine.ParticleSystem.ColorOverLifetimeModule> ( particleSystem.colorOverLifetime );
						break;
					case "customData":
						reader.ReadIntoProperty<UnityEngine.ParticleSystem.CustomDataModule> ( particleSystem.customData );
						break;
					case "emission":
						reader.ReadIntoProperty<UnityEngine.ParticleSystem.EmissionModule> ( particleSystem.emission );
						break;
					case "externalForces":
						reader.ReadIntoProperty<UnityEngine.ParticleSystem.ExternalForcesModule> ( particleSystem.externalForces );
						break;
					case "forceOverLifetime":
						reader.ReadIntoProperty<UnityEngine.ParticleSystem.ForceOverLifetimeModule> ( particleSystem.forceOverLifetime );
						break;
					case "inheritVelocity":
						reader.ReadIntoProperty<UnityEngine.ParticleSystem.InheritVelocityModule> ( particleSystem.inheritVelocity );
						break;
					case "lights":
						reader.ReadIntoProperty<UnityEngine.ParticleSystem.LightsModule> ( particleSystem.lights );
						break;
					case "limitVelocityOverLifetime":
						reader.ReadIntoProperty<UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule> ( particleSystem.limitVelocityOverLifetime );
						break;
					case "main":
						reader.ReadIntoProperty<UnityEngine.ParticleSystem.MainModule> ( particleSystem.main );
						break;
					case "noise":
						reader.ReadIntoProperty<UnityEngine.ParticleSystem.NoiseModule> ( particleSystem.noise );
						break;
					case "rotationBySpeed":
						reader.ReadIntoProperty<UnityEngine.ParticleSystem.RotationBySpeedModule> ( particleSystem.rotationBySpeed );
						break;
					case "rotationOverLifetime":
						reader.ReadIntoProperty<UnityEngine.ParticleSystem.RotationOverLifetimeModule> ( particleSystem.rotationOverLifetime );
						break;
					case "shape":
						reader.ReadIntoProperty<UnityEngine.ParticleSystem.ShapeModule> ( particleSystem.shape );
						break;
					case "sizeBySpeed":
						reader.ReadIntoProperty<UnityEngine.ParticleSystem.SizeBySpeedModule> ( particleSystem.sizeBySpeed );
						break;
					case "sizeOverLifetime":
						reader.ReadIntoProperty<UnityEngine.ParticleSystem.SizeOverLifetimeModule> ( particleSystem.sizeOverLifetime );
						break;
					case "subEmitters":
						reader.ReadIntoProperty<UnityEngine.ParticleSystem.SubEmittersModule> ( particleSystem.subEmitters );
						break;
					case "textureSheetAnimation":
						reader.ReadIntoProperty<UnityEngine.ParticleSystem.TextureSheetAnimationModule> ( particleSystem.textureSheetAnimation );
						break;
					case "trails":
						reader.ReadIntoProperty<UnityEngine.ParticleSystem.TrailModule> ( particleSystem.trails );
						break;
					case "trigger":
						reader.ReadIntoProperty<UnityEngine.ParticleSystem.TriggerModule> ( particleSystem.trigger );
						break;
					case "velocityOverLifetime":
						reader.ReadIntoProperty<UnityEngine.ParticleSystem.VelocityOverLifetimeModule> ( particleSystem.velocityOverLifetime );
						break;
					case "time":
						particleSystem.time = reader.ReadProperty<System.Single> ();
						break;
					case "randomSeed":
						particleSystem.randomSeed = reader.ReadProperty<System.UInt32> ();
						break;
					case "useAutoRandomSeed":
						particleSystem.useAutoRandomSeed = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						particleSystem.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						particleSystem.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						particleSystem.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}