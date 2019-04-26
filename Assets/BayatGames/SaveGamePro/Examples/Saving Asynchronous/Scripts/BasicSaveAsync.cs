using System.Collections;
using System.Collections.Generic;
#if NET_4_6 || NET_STANDARD_2_0
using System.Threading.Tasks;
#endif
using UnityEngine;

namespace BayatGames.SaveGamePro.Examples
{

    /// <summary>
    /// Basic save asynchronous.
    /// </summary>
    public class BasicSaveAsync : MonoBehaviour
    {

        /// <summary>
        /// The identifier.
        /// </summary>
        public string identifier = "saveAsync.txt";

        /// <summary>
        /// The data.
        /// </summary>
        public string data = "This is the data.";

        /// <summary>
        /// Data getter & setter.
        /// </summary>
        public string Data
        {
            get
            {
                return this.data;
            }
            set
            {
                this.data = value;
            }
        }

        /// <summary>
        /// Save the data.
        /// </summary>
        public void Save()
        {
#if NET_4_6 || NET_STANDARD_2_0
            Debug.Log("Saving ...");
            SaveGame.SaveAsync(this.identifier, this.data).ContinueWith((task) =>
            {
                if (task.IsCanceled)
                {
                    Debug.LogError("Save Task - Cancelled");
                }
                else if (task.IsFaulted)
                {
                    Debug.LogError("Save Tsak - Faulted");
                    Debug.LogException(task.Exception);
                }
                else
                {
                    Debug.Log("Saved");
                }
            });
#endif
        }

        /// <summary>
        /// Load the data.
        /// </summary>
        public void Load()
        {
#if NET_4_6 || NET_STANDARD_2_0
            Debug.Log("Loading ...");
            SaveGame.LoadAsync<string>(this.identifier).ContinueWith((task) =>
            {
                if (task.IsCanceled)
                {
                    Debug.LogError("Load Task - Cancelled");
                }
                else if (task.IsFaulted)
                {
                    Debug.LogError("Load Tsak - Faulted");
                    Debug.LogException(task.Exception);
                }
                else
                {
                    Debug.Log("Loaded");
                    Debug.Log(task.Result);

                    // The loaded data is available at Task.Result property, so we assign it to our data variable when loaded, for more informtion check out the below link:
                    // https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1.result
                    this.data = task.Result;
                }
            });
#endif
        }

    }

}