using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

    /// <summary>
    /// Save Game Type FixedJoint serialization implementation.
    /// </summary>
    public class SaveGameType_FixedJoint : SaveGameType
    {

        /// <summary>
        /// Gets the associated type for this custom type.
        /// </summary>
        /// <value>The type of the associated.</value>
        public override Type AssociatedType
        {
            get
            {
                return typeof(UnityEngine.FixedJoint);
            }
        }

        /// <summary>
        /// Write the specified value using the writer.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="writer">Writer.</param>
        public override void Write(object value, ISaveGameWriter writer)
        {
            UnityEngine.FixedJoint fixedJoint = (UnityEngine.FixedJoint)value;
            writer.WriteProperty("connectedBody", fixedJoint.connectedBody);
            writer.WriteProperty("axis", fixedJoint.axis);
            writer.WriteProperty("anchor", fixedJoint.anchor);
            writer.WriteProperty("connectedAnchor", fixedJoint.connectedAnchor);
            writer.WriteProperty("autoConfigureConnectedAnchor", fixedJoint.autoConfigureConnectedAnchor);
            writer.WriteProperty("breakForce", fixedJoint.breakForce);
            writer.WriteProperty("breakTorque", fixedJoint.breakTorque);
            writer.WriteProperty("enableCollision", fixedJoint.enableCollision);
            writer.WriteProperty("enablePreprocessing", fixedJoint.enablePreprocessing);
#if UNITY_2017_1_OR_NEWER
			writer.WriteProperty ( "massScale", fixedJoint.massScale );
			writer.WriteProperty ( "connectedMassScale", fixedJoint.connectedMassScale );
#endif
            writer.WriteProperty("tag", fixedJoint.tag);
            writer.WriteProperty("name", fixedJoint.name);
            writer.WriteProperty("hideFlags", fixedJoint.hideFlags);
        }

        /// <summary>
        /// Read the data using the reader.
        /// </summary>
        /// <param name="reader">Reader.</param>
        public override object Read(ISaveGameReader reader)
        {
            UnityEngine.FixedJoint fixedJoint = SaveGameType.CreateComponent<UnityEngine.FixedJoint>();
            ReadInto(fixedJoint, reader);
            return fixedJoint;
        }

        /// <summary>
        /// Read the data into the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="reader">Reader.</param>
        public override void ReadInto(object value, ISaveGameReader reader)
        {
            UnityEngine.FixedJoint fixedJoint = (UnityEngine.FixedJoint)value;
            foreach (string property in reader.Properties)
            {
                switch (property)
                {
                    case "connectedBody":
                        if (fixedJoint.connectedBody == null)
                        {
                            fixedJoint.connectedBody = reader.ReadProperty<UnityEngine.Rigidbody>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.Rigidbody>(fixedJoint.connectedBody);
                        }
                        break;
                    case "axis":
                        fixedJoint.axis = reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "anchor":
                        fixedJoint.anchor = reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "connectedAnchor":
                        fixedJoint.connectedAnchor = reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "autoConfigureConnectedAnchor":
                        fixedJoint.autoConfigureConnectedAnchor = reader.ReadProperty<System.Boolean>();
                        break;
                    case "breakForce":
                        fixedJoint.breakForce = reader.ReadProperty<System.Single>();
                        break;
                    case "breakTorque":
                        fixedJoint.breakTorque = reader.ReadProperty<System.Single>();
                        break;
                    case "enableCollision":
                        fixedJoint.enableCollision = reader.ReadProperty<System.Boolean>();
                        break;
                    case "enablePreprocessing":
                        fixedJoint.enablePreprocessing = reader.ReadProperty<System.Boolean>();
                        break;
                    case "massScale":
#if UNITY_2017_1_OR_NEWER
                        fixedJoint.massScale = reader.ReadProperty<System.Single>();
#else
                        reader.ReadProperty<System.Single>();
#endif
                        break;
                    case "connectedMassScale":
#if UNITY_2017_1_OR_NEWER
                        fixedJoint.connectedMassScale = reader.ReadProperty<System.Single>();
#else
                        reader.ReadProperty<System.Single>();
#endif
                        break;
                    case "tag":
                        fixedJoint.tag = reader.ReadProperty<System.String>();
                        break;
                    case "name":
                        fixedJoint.name = reader.ReadProperty<System.String>();
                        break;
                    case "hideFlags":
                        fixedJoint.hideFlags = reader.ReadProperty<UnityEngine.HideFlags>();
                        break;
                }
            }
        }

    }

}