using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BayatGames.SaveGamePro.Extensions;

namespace BayatGames.SaveGamePro.Examples
{

    /// <summary>
    /// Save runtime generated objects example.
    /// </summary>
    public class SaveRuntimeGeneratedObjects : MonoBehaviour
    {

        /// <summary>
        /// The prefab.
        /// </summary>
        public GameObject prefab;

        /// <summary>
        /// The container.
        /// </summary>
        public GameObject container;

        /// <summary>
        /// The count.
        /// </summary>
        [SerializeField]
        private int _count;

        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        /// <value>The count.</value>
        public string count
        {
            get
            {
                return _count.ToString();
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _count = 0;
                }
                else
                {
                    _count = int.Parse(value);
                }
            }
        }

        /// <summary>
        /// Spawn the objects.
        /// </summary>
        public void Spawn()
        {

            // Destroy all previously generated objects.
            DestroyAll();
            for (int i = 0; i < _count; i++)
            {

                // Generate object at random position.
                Vector3 position = new Vector3();
                position.x = Random.Range(-20f, 20f);
                position.y = Random.Range(-20f, 20f);
                position.z = Random.Range(-20f, 20f);
                GameObject.Instantiate<GameObject>(prefab, position, Quaternion.identity, container.transform);
            }
        }

        /// <summary>
        /// Destroy all childs.
        /// </summary>
        public void DestroyAll()
        {
            container.DestroyChilds();
        }

        /// <summary>
        /// Save the generated objects.
        /// </summary>
        public void Save()
        {
            SaveGame.Save("instantiatedGameObjects", container);
        }

        /// <summary>
        /// Load the generated objects.
        /// </summary>
        public void Load()
        {
            if (container == null)
            {
                container = SaveGame.Load<GameObject>("instantiatedGameObjects");
            }
            else
            {
                SaveGame.LoadInto("instantiatedGameObjects", container);
            }
        }

    }

}