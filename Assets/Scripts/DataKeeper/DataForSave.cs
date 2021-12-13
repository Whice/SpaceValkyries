
using Assets.Scripts.DataKeeper;
using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Данные для сохраненияю
    /// </summary>
    [Serializable]
    public struct DataForSave
    {
        /// <summary>
        /// Номер уровня.
        /// </summary>
        public Int16 levelNumber;
        /// <summary>
        /// Список врагов на карте.
        /// </summary>
        public IList<ISpaceObject> spaceObjects;
        /// <summary>
        /// Уровень пройден.
        /// </summary>
        public Boolean isLevelComplete;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="spaceObjects">Данные о препятствиях в уровне.</param>
        /// <param name="isLevelComplete">Уровень пройден.</param>
        public DataForSave(IList<ISpaceObject> spaceObjects, Int16 levelNumber, Boolean isLevelComplete=false)
        {
            this.spaceObjects = spaceObjects;
            this.isLevelComplete = isLevelComplete;
            this.levelNumber = levelNumber;
        }
        /// <summary>
        /// Перенести данные из одного объекта в другой.
        /// Поверхностное копирование.
        /// </summary>
        /// <param name="dataForSave"></param>
        public DataForSave(DataForSave dataForSave)
        {
            this.spaceObjects = dataForSave.spaceObjects;
            this.isLevelComplete = dataForSave.isLevelComplete;
            this.levelNumber = dataForSave.levelNumber;
        }
        
    }
}
