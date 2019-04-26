using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Examples
{

    [CreateAssetMenu(menuName = "Save Game Pro/Examples/Item Weapon")]
    public class ItemWeapon : ItemBase
    {

        [Savable]
        public bool IsEquiped { get; set; }

    }

}