
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public struct DataForSave
    {
        /// <summary>
        /// Уровень уже был создан.
        /// </summary>
        public Boolean isCreatedLevel
        {
            get => enemys != null;
        }
        /// <summary>
        /// Номер уровня.
        /// </summary>
        public Int16 levelNumber;
        /// <summary>
        /// Список врагов на карте.
        /// </summary>
        public List<GameObject> enemys;
        /// <summary>
        /// Список врагов на карте.
        /// </summary>
        public List<GameObject> asteroids;
        public DataForSave(Int32 numberOfLevel)
        {
            this.levelNumber = 1;
            this.enemys = null;
            this.asteroids = null;
        }

    }
}
