using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

    /// <summary>
    /// Save Game Type SpringJoint serialization implementation.
    /// </summary>
    public class SaveGameType_SpringJoint : SaveGameType
    {

        /// <summary>
        /// Gets the associated type for this custom type.
        /// </summary>
        /// <value>The type of the associated.</value>
        public override Type AssociatedType
        {
            get
            {
                return typeof(UnityEngine.SpringJoint);
            }
        }

        /// <summary>
        /// Write the specified value using the writer.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="writer">Writer.</param>
        public override void Write(object value, ISaveGameWriter writer)
        {
            UnityEngine.SpringJoint springJoint = (UnityEngine.SpringJoint)value;
            writer.WriteProperty("spring", springJoint.spring);
            writer.WriteProperty("damper", springJoint.damper);
            writer.WriteProperty("minDistance", springJoint.minDistance);
            writer.WriteProperty("maxDistance", springJoint.maxDistance);
            writer.WriteProperty("tolerance", springJoint.tolerance);
            writer.WriteProperty("connectedBody", springJoint.connectedBody);
            writer.WriteProperty("axis", springJoint.axis);
            writer.WriteProperty("anchor", springJoint.anchor);
            writer.WriteProperty("connectedAnchor", springJoint.connectedAnchor);
            writer.WriteProperty("autoConfigureConnectedAnchor", springJoint.autoConfigureConnectedAnchor);
            writer.WriteProperty("breakForce", springJoint.breakForce);
            writer.WriteProperty("breakTorque", springJoint.breakTorque);
            writer.WriteProperty("enableCollision", springJoint.enableCollision);
            writer.WriteProperty("enablePreprocessing", springJoint.enablePreprocessing);
#if UNITY_2017_1_OR_NEWER
			writer.WriteProperty ( "massScale", springJoint.massScale );
			writer.WriteProperty ( "connectedMassScale", springJoint.connectedMassScale );
#endif
            writer.WriteProperty("tag", springJoint.tag);
            writer.WriteProperty("name", springJoint.name);
            writer.WriteProperty("hideFlags", springJoint.hideFlags);
        }

        /// <summary>
        /// Read the data using the reader.
        /// </summary>
        /// <param name="reader">Reader.</param>
        public override object Read(ISaveGameReader reader)
        {
            UnityEngine.SpringJoint springJoint = SaveGameType.CreateComponent<UnityEngine.SpringJoint>();
            ReadInto(springJoint, reader);
            return springJoint;
        }

        /// <summary>
        /// Read the data into the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="reader">Reader.</param>
        public override void ReadInto(object value, ISaveGameReader reader)
        {
            UnityEngine.SpringJoint springJoint = (UnityEngine.SpringJoint)value;
            foreach (string property in reader.Properties)
            {
                switch (property)
                {
                    case "spring":
                        springJoint.spring = reader.ReadProperty<System.Single>();
                        break;
                    case "damper":
                        springJoint.damper = reader.ReadProperty<System.Single>();
                        break;
                    case "minDistance":
                        springJoint.minDistance = reader.ReadProperty<System.Single>();
                        break;
                    case "maxDistance":
                        springJoint.maxDistance = reader.ReadProperty<System.Single>();
                        break;
                    case "tolerance":
                        springJoint.tolerance = reader.ReadProperty<System.Single>();
                        break;
                    case "connectedBody":
                        if (springJoint.connectedBody == null)
                        {
                            springJoint.connectedBody = reader.ReadProperty<UnityEngine.Rigidbody>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.Rigidbody>(springJoint.connectedBody);
                        }
                        break;
                    case "axis":
                        springJoint.axis = reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "anchor":
                        springJoint.anchor = reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "connectedAnchor":
                        springJoint.connectedAnchor = reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "autoConfigureConnectedAnchor":
                        springJoint.autoConfigureConnectedAnchor = reader.ReadProperty<System.Boolean>();
                        break;
                    case "breakForce":
                        springJoint.breakForce = reader.ReadProperty<System.Single>();
                        break;
                    case "breakTorque":
                        springJoint.breakTorque = reader.ReadProperty<System.Single>();
                        break;
                    case "enableCollision":
                        springJoint.enableCollision = reader.ReadProperty<System.Boolean>();
                        break;
                    case "enablePreprocessing":
                        springJoint.enablePreprocessing = reader.ReadProperty<System.Boolean>();
                        break;
                    case "massScale":
#if UNITY_2017_1_OR_NEWER
                        springJoint.massScale = reader.ReadProperty<System.Single>();
#else
                        reader.ReadProperty<System.Single>();
#endif
                        break;
                    case "connectedMassScale":
#if UNITY_2017_1_OR_NEWER
                        springJoint.connectedMassScale = reader.ReadProperty<System.Single>();
#else
                        reader.ReadProperty<System.Single>();
#endif
                        break;
                    case "tag":
                        springJoint.tag = reader.ReadProperty<System.String>();
                        break;
                    case "name":
                        springJoint.name = reader.ReadProperty<System.String>();
                        break;
                    case "hideFlags":
                        springJoint.hideFlags = reader.ReadProperty<UnityEngine.HideFlags>();
                        break;
                }
            }
        }

    }

}