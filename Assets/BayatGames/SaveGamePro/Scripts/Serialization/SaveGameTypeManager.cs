using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

using BayatGames.SaveGamePro.Serialization.Types;

namespace BayatGames.SaveGamePro.Serialization
{

	/// <summary>
	/// Save Game Type Manager.
	/// Manage custom types using this API.
	/// </summary>
	public static class SaveGameTypeManager
	{

		private static Dictionary<Type, SaveGameType> m_Types;

		/// <summary>
		/// Gets the types.
		/// </summary>
		/// <value>The types.</value>
		public static Dictionary<Type, SaveGameType> Types
		{
			get
			{
				if ( m_Types == null )
				{
					Initialize ();
				}
				return m_Types;
			}
		}

		/// <summary>
		/// Initialize the manager and load all custom types.
		/// </summary>
		[RuntimeInitializeOnLoadMethod ( RuntimeInitializeLoadType.BeforeSceneLoad )]
		private static void Initialize ()
		{
			m_Types = new Dictionary<Type, SaveGameType> ();
			#if (UNITY_WSA || UNITY_WINRT) && !UNITY_EDITOR
			AddType ( typeof ( UnityEngine.AnchoredJoint2D ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_AnchoredJoint2D () );
			AddType ( typeof ( UnityEngine.Animation ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Animation () );
			AddType ( typeof ( UnityEngine.AnimationClip ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_AnimationClip () );
			AddType ( typeof ( UnityEngine.AnimationCurve ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_AnimationCurve () );
			AddType ( typeof ( UnityEngine.AnimationEvent ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_AnimationEvent () );
			AddType ( typeof ( UnityEngine.AnimationState ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_AnimationState () );
			AddType ( typeof ( UnityEngine.UI.AnimationTriggers ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_AnimationTriggers () );
			AddType ( typeof ( UnityEngine.Animator ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Animator () );
			AddType ( typeof ( UnityEngine.AnimatorControllerParameter ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_AnimatorControllerParameter () );
			AddType ( typeof ( UnityEngine.AnimatorOverrideController ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_AnimatorOverrideController () );
			AddType ( typeof ( UnityEngine.AreaEffector2D ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_AreaEffector2D () );
			AddType ( typeof ( UnityEngine.UI.AspectRatioFitter ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_AspectRatioFitter () );
			AddType ( typeof ( UnityEngine.AudioChorusFilter ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_AudioChorusFilter () );
			AddType ( typeof ( UnityEngine.AudioClip ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_AudioClip () );
			AddType ( typeof ( UnityEngine.AudioConfiguration ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_AudioConfiguration () );
			AddType ( typeof ( UnityEngine.AudioDistortionFilter ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_AudioDistortionFilter () );
			AddType ( typeof ( UnityEngine.AudioEchoFilter ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_AudioEchoFilter () );
			AddType ( typeof ( UnityEngine.AudioHighPassFilter ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_AudioHighPassFilter () );
			AddType ( typeof ( UnityEngine.AudioListener ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_AudioListener () );
			AddType ( typeof ( UnityEngine.AudioLowPassFilter ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_AudioLowPassFilter () );
			AddType ( typeof ( UnityEngine.Audio.AudioMixer ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_AudioMixer () );
			AddType ( typeof ( UnityEngine.Audio.AudioMixerGroup ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_AudioMixerGroup () );
			AddType ( typeof ( UnityEngine.AudioReverbFilter ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_AudioReverbFilter () );
			AddType ( typeof ( UnityEngine.AudioReverbZone ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_AudioReverbZone () );
			AddType ( typeof ( UnityEngine.AudioSource ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_AudioSource () );
			AddType ( typeof ( UnityEngine.Avatar ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Avatar () );
			AddType ( typeof ( UnityEngine.AvatarMask ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_AvatarMask () );
			AddType ( typeof ( UnityEngine.BillboardAsset ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_BillboardAsset () );
			AddType ( typeof ( UnityEngine.BillboardRenderer ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_BillboardRenderer () );
			AddType ( typeof ( UnityEngine.BoneWeight ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_BoneWeight () );
			AddType ( typeof ( UnityEngine.Bounds ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Bounds () );
			AddType ( typeof ( UnityEngine.BoxCollider ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_BoxCollider () );
			AddType ( typeof ( UnityEngine.BoxCollider2D ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_BoxCollider2D () );
			AddType ( typeof ( UnityEngine.BuoyancyEffector2D ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_BuoyancyEffector2D () );
			AddType ( typeof ( UnityEngine.UI.Button ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Button () );
			AddType ( typeof ( UnityEngine.Camera ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Camera () );
			AddType ( typeof ( UnityEngine.UI.CanvasScaler ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_CanvasScaler () );
			AddType ( typeof ( UnityEngine.CapsuleCollider ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_CapsuleCollider () );
			AddType ( typeof ( UnityEngine.CapsuleCollider2D ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_CapsuleCollider2D () );
			AddType ( typeof ( UnityEngine.CharacterController ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_CharacterController () );
			AddType ( typeof ( UnityEngine.CharacterInfo ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_CharacterInfo () );
			AddType ( typeof ( UnityEngine.CharacterJoint ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_CharacterJoint () );
			AddType ( typeof ( UnityEngine.CircleCollider2D ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_CircleCollider2D () );
			AddType ( typeof ( UnityEngine.Cloth ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Cloth () );
			AddType ( typeof ( UnityEngine.Collider ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Collider () );
			AddType ( typeof ( UnityEngine.Collider2D ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Collider2D () );
			AddType ( typeof ( UnityEngine.ParticleSystem.CollisionModule ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_CollisionModule () );
			AddType ( typeof ( UnityEngine.Color ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Color () );
			AddType ( typeof ( UnityEngine.Color32 ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Color32 () );
			AddType ( typeof ( UnityEngine.UI.ColorBlock ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_ColorBlock () );
			AddType ( typeof ( UnityEngine.ParticleSystem.ColorBySpeedModule ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_ColorBySpeedModule () );
			AddType ( typeof ( UnityEngine.ParticleSystem.ColorOverLifetimeModule ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_ColorOverLifetimeModule () );
			AddType ( typeof ( UnityEngine.CompositeCollider2D ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_CompositeCollider2D () );
			AddType ( typeof ( UnityEngine.ConfigurableJoint ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_ConfigurableJoint () );
			AddType ( typeof ( UnityEngine.ConstantForce ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_ConstantForce () );
			AddType ( typeof ( UnityEngine.ConstantForce2D ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_ConstantForce2D () );
			AddType ( typeof ( UnityEngine.UI.ContentSizeFitter ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_ContentSizeFitter () );
			AddType ( typeof ( UnityEngine.CullingGroup ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_CullingGroup () );
			AddType ( typeof ( UnityEngine.ParticleSystem.CustomDataModule ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_CustomDataModule () );
			AddType ( typeof ( UnityEngine.DetailPrototype ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_DetailPrototype () );
			AddType ( typeof ( UnityEngine.DistanceJoint2D ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_DistanceJoint2D () );
			AddType ( typeof ( UnityEngine.UI.Dropdown ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Dropdown () );
			AddType ( typeof ( UnityEngine.EdgeCollider2D ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_EdgeCollider2D () );
			AddType ( typeof ( UnityEngine.Effector2D ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Effector2D () );
			AddType ( typeof ( UnityEngine.ParticleSystem.EmissionModule ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_EmissionModule () );
			AddType ( typeof ( UnityEngine.EventSystems.EventSystem ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_EventSystem () );
			AddType ( typeof ( UnityEngine.EventSystems.EventTrigger ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_EventTrigger () );
			AddType ( typeof ( UnityEngine.ParticleSystem.ExternalForcesModule ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_ExternalForcesModule () );
			AddType ( typeof ( UnityEngine.FixedJoint ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_FixedJoint () );
			AddType ( typeof ( UnityEngine.FixedJoint2D ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_FixedJoint2D () );
			AddType ( typeof ( UnityEngine.Flare ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Flare () );
			AddType ( typeof ( UnityEngine.FlareLayer ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_FlareLayer () );
			AddType ( typeof ( UnityEngine.Font ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Font () );
			AddType ( typeof ( UnityEngine.UI.FontData ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_FontData () );
			AddType ( typeof ( UnityEngine.ParticleSystem.ForceOverLifetimeModule ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_ForceOverLifetimeModule () );
			AddType ( typeof ( UnityEngine.FrictionJoint2D ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_FrictionJoint2D () );
			AddType ( typeof ( UnityEngine.Gradient ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Gradient () );
			AddType ( typeof ( UnityEngine.GradientAlphaKey ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_GradientAlphaKey () );
			AddType ( typeof ( UnityEngine.GradientColorKey ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_GradientColorKey () );
			AddType ( typeof ( UnityEngine.UI.GraphicRaycaster ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_GraphicRaycaster () );
			AddType ( typeof ( UnityEngine.UI.GridLayoutGroup ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_GridLayoutGroup () );
			AddType ( typeof ( UnityEngine.HingeJoint ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_HingeJoint () );
			AddType ( typeof ( UnityEngine.HingeJoint2D ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_HingeJoint2D () );
			AddType ( typeof ( UnityEngine.UI.HorizontalLayoutGroup ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_HorizontalLayoutGroup () );
			AddType ( typeof ( UnityEngine.UI.Image ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Image () );
			AddType ( typeof ( UnityEngine.ParticleSystem.InheritVelocityModule ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_InheritVelocityModule () );
			AddType ( typeof ( UnityEngine.UI.InputField ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_InputField () );
			AddType ( typeof ( UnityEngine.JointAngleLimits2D ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_JointAngleLimits2D () );
			AddType ( typeof ( UnityEngine.JointDrive ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_JointDrive () );
			AddType ( typeof ( UnityEngine.JointLimits ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_JointLimits () );
			AddType ( typeof ( UnityEngine.JointMotor ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_JointMotor () );
			AddType ( typeof ( UnityEngine.JointMotor2D ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_JointMotor2D () );
			AddType ( typeof ( UnityEngine.JointSpring ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_JointSpring () );
			AddType ( typeof ( UnityEngine.JointSuspension2D ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_JointSuspension2D () );
			AddType ( typeof ( UnityEngine.JointTranslationLimits2D ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_JointTranslationLimits2D () );
			AddType ( typeof ( UnityEngine.Keyframe ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Keyframe () );
			AddType ( typeof ( UnityEngine.LayerMask ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_LayerMask () );
			AddType ( typeof ( UnityEngine.UI.LayoutElement ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_LayoutElement () );
			AddType ( typeof ( UnityEngine.LensFlare ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_LensFlare () );
			AddType ( typeof ( UnityEngine.Light ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Light () );
			AddType ( typeof ( UnityEngine.LightmapData ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_LightmapData () );
			AddType ( typeof ( UnityEngine.LightProbeGroup ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_LightProbeGroup () );
			AddType ( typeof ( UnityEngine.LightProbeProxyVolume ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_LightProbeProxyVolume () );
			AddType ( typeof ( UnityEngine.LightProbes ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_LightProbes () );
			AddType ( typeof ( UnityEngine.ParticleSystem.LightsModule ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_LightsModule () );
			AddType ( typeof ( UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_LimitVelocityOverLifetimeModule () );
			AddType ( typeof ( UnityEngine.LineRenderer ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_LineRenderer () );
			AddType ( typeof ( UnityEngine.ParticleSystem.MainModule ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_MainModule () );
			AddType ( typeof ( UnityEngine.UI.Mask ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Mask () );
			AddType ( typeof ( UnityEngine.Material ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Material () );
			AddType ( typeof ( UnityEngine.Matrix4x4 ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Matrix4x4 () );
			AddType ( typeof ( UnityEngine.Mesh ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Mesh () );
			AddType ( typeof ( UnityEngine.MeshCollider ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_MeshCollider () );
			AddType ( typeof ( UnityEngine.MeshFilter ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_MeshFilter () );
			AddType ( typeof ( UnityEngine.MeshRenderer ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_MeshRenderer () );
			AddType ( typeof ( UnityEngine.ParticleSystem.MinMaxCurve ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_MinMaxCurve () );
			AddType ( typeof ( UnityEngine.ParticleSystem.MinMaxGradient ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_MinMaxGradient () );
			AddType ( typeof ( UnityEngine.Motion ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Motion () );
			AddType ( typeof ( UnityEngine.UI.Navigation ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Navigation () );
			AddType ( typeof ( UnityEngine.AI.NavMeshAgent ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_NavMeshAgent () );
			AddType ( typeof ( UnityEngine.AI.NavMeshData ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_NavMeshData () );
			AddType ( typeof ( UnityEngine.AI.NavMeshDataInstance ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_NavMeshDataInstance () );
			AddType ( typeof ( UnityEngine.AI.NavMeshHit ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_NavMeshHit () );
			AddType ( typeof ( UnityEngine.AI.NavMeshLinkData ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_NavMeshLinkData () );
			AddType ( typeof ( UnityEngine.AI.NavMeshLinkInstance ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_NavMeshLinkInstance () );
			AddType ( typeof ( UnityEngine.AI.NavMeshObstacle ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_NavMeshObstacle () );
			AddType ( typeof ( UnityEngine.AI.NavMeshQueryFilter ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_NavMeshQueryFilter () );
			AddType ( typeof ( UnityEngine.AI.NavMeshTriangulation ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_NavMeshTriangulation () );
			AddType ( typeof ( UnityEngine.ParticleSystem.NoiseModule ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_NoiseModule () );
			AddType ( typeof ( UnityEngine.OcclusionArea ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_OcclusionArea () );
			AddType ( typeof ( UnityEngine.OcclusionPortal ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_OcclusionPortal () );
			AddType ( typeof ( UnityEngine.AI.OffMeshLink ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_OffMeshLink () );
			AddType ( typeof ( UnityEngine.UI.Dropdown.OptionData ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_OptionData () );
			AddType ( typeof ( UnityEngine.UI.Dropdown.OptionDataList ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_OptionDataList () );
			AddType ( typeof ( UnityEngine.UI.Outline ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Outline () );
			AddType ( typeof ( UnityEngine.ParticleSystem ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_ParticleSystem () );
			AddType ( typeof ( UnityEngine.PhysicMaterial ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_PhysicMaterial () );
			AddType ( typeof ( UnityEngine.EventSystems.Physics2DRaycaster ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Physics2DRaycaster () );
			AddType ( typeof ( UnityEngine.PhysicsMaterial2D ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_PhysicsMaterial2D () );
			AddType ( typeof ( UnityEngine.EventSystems.PhysicsRaycaster ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_PhysicsRaycaster () );
			AddType ( typeof ( UnityEngine.PlatformEffector2D ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_PlatformEffector2D () );
			AddType ( typeof ( UnityEngine.PointEffector2D ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_PointEffector2D () );
			AddType ( typeof ( UnityEngine.PolygonCollider2D ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_PolygonCollider2D () );
			AddType ( typeof ( UnityEngine.Projector ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Projector () );
			AddType ( typeof ( UnityEngine.Quaternion ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Quaternion () );
			AddType ( typeof ( UnityEngine.UI.RawImage ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_RawImage () );
			AddType ( typeof ( UnityEngine.Ray ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Ray () );
			AddType ( typeof ( UnityEngine.Ray2D ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Ray2D () );
			AddType ( typeof ( UnityEngine.RaycastHit ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_RaycastHit () );
			AddType ( typeof ( UnityEngine.RaycastHit2D ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_RaycastHit2D () );
			AddType ( typeof ( UnityEngine.Rect ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Rect () );
			AddType ( typeof ( UnityEngine.UI.RectMask2D ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_RectMask2D () );
			AddType ( typeof ( UnityEngine.RectTransform ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_RectTransform () );
			AddType ( typeof ( UnityEngine.RelativeJoint2D ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_RelativeJoint2D () );
			AddType ( typeof ( UnityEngine.RenderTexture ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_RenderTexture () );
			AddType ( typeof ( UnityEngine.RenderTextureDescriptor ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_RenderTextureDescriptor () );
			AddType ( typeof ( UnityEngine.Rigidbody ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Rigidbody () );
			AddType ( typeof ( UnityEngine.Rigidbody2D ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Rigidbody2D () );
			AddType ( typeof ( UnityEngine.ParticleSystem.RotationBySpeedModule ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_RotationBySpeedModule () );
			AddType ( typeof ( UnityEngine.ParticleSystem.RotationOverLifetimeModule ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_RotationOverLifetimeModule () );
			AddType ( typeof ( UnityEngine.RuntimeAnimatorController ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_RuntimeAnimatorController () );
			AddType ( typeof ( UnityEngine.UI.Scrollbar ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Scrollbar () );
			AddType ( typeof ( UnityEngine.UI.ScrollRect ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_ScrollRect () );
			AddType ( typeof ( UnityEngine.Shader ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Shader () );
			AddType ( typeof ( UnityEngine.UI.Shadow ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Shadow () );
			AddType ( typeof ( UnityEngine.ParticleSystem.ShapeModule ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_ShapeModule () );
			AddType ( typeof ( UnityEngine.ParticleSystem.SizeBySpeedModule ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_SizeBySpeedModule () );
			AddType ( typeof ( UnityEngine.ParticleSystem.SizeOverLifetimeModule ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_SizeOverLifetimeModule () );
			AddType ( typeof ( UnityEngine.SkinnedMeshRenderer ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_SkinnedMeshRenderer () );
			AddType ( typeof ( UnityEngine.Skybox ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Skybox () );
			AddType ( typeof ( UnityEngine.UI.Slider ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Slider () );
			AddType ( typeof ( UnityEngine.SliderJoint2D ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_SliderJoint2D () );
			AddType ( typeof ( UnityEngine.SoftJointLimit ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_SoftJointLimit () );
			AddType ( typeof ( UnityEngine.SoftJointLimitSpring ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_SoftJointLimitSpring () );
			AddType ( typeof ( UnityEngine.Rendering.SortingGroup ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_SortingGroup () );
			AddType ( typeof ( UnityEngine.SparseTexture ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_SparseTexture () );
			AddType ( typeof ( UnityEngine.SphereCollider ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_SphereCollider () );
			AddType ( typeof ( UnityEngine.SpringJoint ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_SpringJoint () );
			AddType ( typeof ( UnityEngine.SpringJoint2D ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_SpringJoint2D () );
			AddType ( typeof ( UnityEngine.Sprite ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Sprite () );
			AddType ( typeof ( UnityEngine.SpriteMask ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_SpriteMask () );
			AddType ( typeof ( UnityEngine.SpriteRenderer ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_SpriteRenderer () );
			AddType ( typeof ( UnityEngine.UI.SpriteState ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_SpriteState () );
			AddType ( typeof ( UnityEngine.EventSystems.StandaloneInputModule ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_StandaloneInputModule () );
			AddType ( typeof ( UnityEngine.ParticleSystem.SubEmittersModule ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_SubEmittersModule () );
			AddType ( typeof ( UnityEngine.SurfaceEffector2D ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_SurfaceEffector2D () );
			AddType ( typeof ( UnityEngine.TargetJoint2D ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_TargetJoint2D () );
			AddType ( typeof ( UnityEngine.Terrain ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Terrain () );
			AddType ( typeof ( UnityEngine.TerrainCollider ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_TerrainCollider () );
			AddType ( typeof ( UnityEngine.TerrainData ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_TerrainData () );
			AddType ( typeof ( UnityEngine.UI.Text ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Text () );
			AddType ( typeof ( UnityEngine.TextMesh ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_TextMesh () );
			AddType ( typeof ( UnityEngine.Texture ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Texture () );
			AddType ( typeof ( UnityEngine.Texture2D ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Texture2D () );
			AddType ( typeof ( UnityEngine.Texture2DArray ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Texture2DArray () );
			AddType ( typeof ( UnityEngine.Texture3D ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Texture3D () );
			AddType ( typeof ( UnityEngine.ParticleSystem.TextureSheetAnimationModule ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_TextureSheetAnimationModule () );
			AddType ( typeof ( UnityEngine.UI.Toggle ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Toggle () );
			AddType ( typeof ( UnityEngine.UI.ToggleGroup ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_ToggleGroup () );
			AddType ( typeof ( UnityEngine.Touch ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Touch () );
			AddType ( typeof ( UnityEngine.ParticleSystem.TrailModule ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_TrailModule () );
			AddType ( typeof ( UnityEngine.TrailRenderer ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_TrailRenderer () );
			AddType ( typeof ( UnityEngine.Transform ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Transform () );
			AddType ( typeof ( UnityEngine.Tree ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Tree () );
			AddType ( typeof ( UnityEngine.TreeInstance ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_TreeInstance () );
			AddType ( typeof ( UnityEngine.TreePrototype ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_TreePrototype () );
			AddType ( typeof ( UnityEngine.ParticleSystem.TriggerModule ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_TriggerModule () );
			AddType ( typeof ( UnityEngine.Vector2 ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Vector2 () );
			AddType ( typeof ( UnityEngine.Vector3 ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Vector3 () );
			AddType ( typeof ( UnityEngine.Vector4 ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_Vector4 () );
			AddType ( typeof ( UnityEngine.ParticleSystem.VelocityOverLifetimeModule ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_VelocityOverLifetimeModule () );
			AddType ( typeof ( UnityEngine.UI.VerticalLayoutGroup ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_VerticalLayoutGroup () );
			AddType ( typeof ( UnityEngine.Video.VideoClip ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_VideoClip () );
			AddType ( typeof ( UnityEngine.Video.VideoPlayer ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_VideoPlayer () );
			AddType ( typeof ( UnityEngine.WheelCollider ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_WheelCollider () );
			AddType ( typeof ( UnityEngine.WheelFrictionCurve ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_WheelFrictionCurve () );
			AddType ( typeof ( UnityEngine.WheelHit ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_WheelHit () );
			AddType ( typeof ( UnityEngine.WheelJoint2D ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_WheelJoint2D () );
			AddType ( typeof ( UnityEngine.WindZone ), new BayatGames.SaveGamePro.Serialization.Types.SaveGameType_WindZone () );

			#else
			Type type = typeof ( SaveGameType );
			Type [] typesFound = AppDomain.CurrentDomain.GetAssemblies ()
			.SelectMany ( s => s.GetTypes () )
			.Where ( p => type.IsAssignableFrom ( p ) && !p.IsInterface && !p.IsAbstract ).ToArray ();
			for ( int i = 0; i < typesFound.Length; i++ )
			{
				SaveGameType saveGameType = ( SaveGameType )Activator.CreateInstance ( typesFound [ i ] );
				m_Types.Add ( saveGameType.AssociatedType, saveGameType );
			}
			#endif
		}

		/// <summary>
		/// Add the custom type.
		/// </summary>
		/// <param name="type">Type.</param>
		/// <param name="saveGameType">Save game type.</param>
		public static void AddType ( Type type, SaveGameType saveGameType )
		{
			if ( !HasType ( type ) )
			{
				Types.Add ( type, saveGameType );
			}
		}

		/// <summary>
		/// Remove the type.
		/// </summary>
		/// <param name="type">Type.</param>
		public static void RemoveType ( Type type )
		{
			Types.Remove ( type );
		}

		/// <summary>
		/// Get the type.
		/// </summary>
		/// <returns>The type.</returns>
		/// <param name="type">Type.</param>
		public static SaveGameType GetType ( Type type )
		{
			return Types [ type ];
		}

		/// <summary>
		/// Determines if the type exists.
		/// </summary>
		/// <returns><c>true</c> if has type the specified type; otherwise, <c>false</c>.</returns>
		/// <param name="type">Type.</param>
		public static bool HasType ( Type type )
		{
			return Types.ContainsKey ( type );
		}

	}

}