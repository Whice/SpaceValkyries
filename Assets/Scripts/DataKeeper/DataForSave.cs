
using Assets.Scripts.DataKeeper;
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
        private List<GameObjectSaveData> saveEnemies=null;
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
        private void ListGameObjectsToSaveData(List<GameObject> gameObjects, ref List<GameObjectSaveData> saveDatas)
        {
            saveDatas = new List<GameObjectSaveData>(gameObjects.Count);
            for(Int32 i=0;i<gameObjects.Count;i++)
            {
                saveDatas.Add(new GameObjectSaveData(gameObjects[i]));
            }
        }
        private List<GameObject> ListSaveDataToGameObjects(List<GameObjectSaveData> saveData)
        {
            List<GameObject> gameObjects = new List<GameObject>(saveData.Count);
            for(Int32 i=0;i<saveData.Count;i++)
            {
                gameObjects.Add(saveData[i].GetGameObject());
            }
            return gameObjects;
        }
        
    }
}
