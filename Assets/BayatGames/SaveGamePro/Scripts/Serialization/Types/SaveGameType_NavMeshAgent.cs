using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

    /// <summary>
    /// Save Game Type NavMeshAgent serialization implementation.
    /// </summary>
    public class SaveGameType_NavMeshAgent : SaveGameType
    {

        /// <summary>
        /// Gets the associated type for this custom type.
        /// </summary>
        /// <value>The type of the associated.</value>
        public override Type AssociatedType
        {
            get
            {
                return typeof(UnityEngine.AI.NavMeshAgent);
            }
        }

        /// <summary>
        /// Write the specified value using the writer.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="writer">Writer.</param>
        public override void Write(object value, ISaveGameWriter writer)
        {
            UnityEngine.AI.NavMeshAgent navMeshAgent = (UnityEngine.AI.NavMeshAgent)value;
            writer.WriteProperty("destination", navMeshAgent.destination);
            writer.WriteProperty("stoppingDistance", navMeshAgent.stoppingDistance);
            writer.WriteProperty("velocity", navMeshAgent.velocity);
            writer.WriteProperty("nextPosition", navMeshAgent.nextPosition);
            writer.WriteProperty("baseOffset", navMeshAgent.baseOffset);
            writer.WriteProperty("autoTraverseOffMeshLink", navMeshAgent.autoTraverseOffMeshLink);
            writer.WriteProperty("autoBraking", navMeshAgent.autoBraking);
            writer.WriteProperty("autoRepath", navMeshAgent.autoRepath);
            writer.WriteProperty("isStopped", navMeshAgent.isStopped);
            writer.WriteProperty("path", navMeshAgent.path);
#if UNITY_2017_1_OR_NEWER
			writer.WriteProperty ( "agentTypeID", navMeshAgent.agentTypeID );
#endif
            writer.WriteProperty("areaMask", navMeshAgent.areaMask);
            writer.WriteProperty("speed", navMeshAgent.speed);
            writer.WriteProperty("angularSpeed", navMeshAgent.angularSpeed);
            writer.WriteProperty("acceleration", navMeshAgent.acceleration);
            writer.WriteProperty("updatePosition", navMeshAgent.updatePosition);
            writer.WriteProperty("updateRotation", navMeshAgent.updateRotation);
            writer.WriteProperty("updateUpAxis", navMeshAgent.updateUpAxis);
            writer.WriteProperty("radius", navMeshAgent.radius);
            writer.WriteProperty("height", navMeshAgent.height);
            writer.WriteProperty("obstacleAvoidanceType", navMeshAgent.obstacleAvoidanceType);
            writer.WriteProperty("avoidancePriority", navMeshAgent.avoidancePriority);
            writer.WriteProperty("enabled", navMeshAgent.enabled);
            writer.WriteProperty("tag", navMeshAgent.tag);
            writer.WriteProperty("name", navMeshAgent.name);
            writer.WriteProperty("hideFlags", navMeshAgent.hideFlags);
        }

        /// <summary>
        /// Read the data using the reader.
        /// </summary>
        /// <param name="reader">Reader.</param>
        public override object Read(ISaveGameReader reader)
        {
            UnityEngine.AI.NavMeshAgent navMeshAgent = SaveGameType.CreateComponent<UnityEngine.AI.NavMeshAgent>();
            ReadInto(navMeshAgent, reader);
            return navMeshAgent;
        }

        /// <summary>
        /// Read the data into the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="reader">Reader.</param>
        public override void ReadInto(object value, ISaveGameReader reader)
        {
            UnityEngine.AI.NavMeshAgent navMeshAgent = (UnityEngine.AI.NavMeshAgent)value;
            foreach (string property in reader.Properties)
            {
                switch (property)
                {
                    case "destination":
                        navMeshAgent.destination = reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "stoppingDistance":
                        navMeshAgent.stoppingDistance = reader.ReadProperty<System.Single>();
                        break;
                    case "velocity":
                        navMeshAgent.velocity = reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "nextPosition":
                        navMeshAgent.nextPosition = reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "baseOffset":
                        navMeshAgent.baseOffset = reader.ReadProperty<System.Single>();
                        break;
                    case "autoTraverseOffMeshLink":
                        navMeshAgent.autoTraverseOffMeshLink = reader.ReadProperty<System.Boolean>();
                        break;
                    case "autoBraking":
                        navMeshAgent.autoBraking = reader.ReadProperty<System.Boolean>();
                        break;
                    case "autoRepath":
                        navMeshAgent.autoRepath = reader.ReadProperty<System.Boolean>();
                        break;
                    case "isStopped":
                        navMeshAgent.isStopped = reader.ReadProperty<System.Boolean>();
                        break;
                    case "path":
                        navMeshAgent.path = reader.ReadProperty<UnityEngine.AI.NavMeshPath>();
                        break;
                    case "agentTypeID":
#if UNITY_2017_1_OR_NEWER
                        navMeshAgent.agentTypeID = reader.ReadProperty<System.Int32>();
#else
                        reader.ReadProperty<System.Int32>();
#endif
                        break;
                    case "areaMask":
                        navMeshAgent.areaMask = reader.ReadProperty<System.Int32>();
                        break;
                    case "speed":
                        navMeshAgent.speed = reader.ReadProperty<System.Single>();
                        break;
                    case "angularSpeed":
                        navMeshAgent.angularSpeed = reader.ReadProperty<System.Single>();
                        break;
                    case "acceleration":
                        navMeshAgent.acceleration = reader.ReadProperty<System.Single>();
                        break;
                    case "updatePosition":
                        navMeshAgent.updatePosition = reader.ReadProperty<System.Boolean>();
                        break;
                    case "updateRotation":
                        navMeshAgent.updateRotation = reader.ReadProperty<System.Boolean>();
                        break;
                    case "updateUpAxis":
                        navMeshAgent.updateUpAxis = reader.ReadProperty<System.Boolean>();
                        break;
                    case "radius":
                        navMeshAgent.radius = reader.ReadProperty<System.Single>();
                        break;
                    case "height":
                        navMeshAgent.height = reader.ReadProperty<System.Single>();
                        break;
                    case "obstacleAvoidanceType":
                        navMeshAgent.obstacleAvoidanceType = reader.ReadProperty<UnityEngine.AI.ObstacleAvoidanceType>();
                        break;
                    case "avoidancePriority":
                        navMeshAgent.avoidancePriority = reader.ReadProperty<System.Int32>();
                        break;
                    case "enabled":
                        navMeshAgent.enabled = reader.ReadProperty<System.Boolean>();
                        break;
                    case "tag":
                        navMeshAgent.tag = reader.ReadProperty<System.String>();
                        break;
                    case "name":
                        navMeshAgent.name = reader.ReadProperty<System.String>();
                        break;
                    case "hideFlags":
                        navMeshAgent.hideFlags = reader.ReadProperty<UnityEngine.HideFlags>();
                        break;
                }
            }
        }

    }

}