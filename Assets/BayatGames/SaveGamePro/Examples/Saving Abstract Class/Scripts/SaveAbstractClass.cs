using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Examples
{

    public class SaveAbstractClass : MonoBehaviour
    {

        public ItemWeapon weapon;
        public List<ItemBase> items;

        private void Start()
        {
            this.items = new List<ItemBase>();
            items.Add(weapon);
            Save();
            Load();
        }

        public void Save()
        {
            SaveGame.Save("abstract.dat", items);
        }

        public void Load()
        {
            SaveGame.LoadInto("abstract.dat", this.items);
            Debug.Log(this.items[0]);
        }

    }

}