using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Главный хранитель всей игры.
    /// О нем знают все.
    /// </summary>
    public static class MainGameKeeper
    {
        /// <summary>
        /// Информация о главном управляющем скрипте.
        /// </summary>
        private static GameManagerInfo gameManagerInfoPrivate = null;
        /// <summary>
        /// Информация о главном управляющем скрипте.
        /// </summary>
        public static GameManagerInfo gameManagerInfo
        {
            get
            {
                if (gameManagerInfoPrivate == null)
                {
                    gameManagerInfoPrivate = GameObject.Find("GameManager").GetComponent<GameManagerInfo>();
                }
                return gameManagerInfoPrivate;
            }
        }
        /// <summary>
        /// Словарь всех заготовок проектаю
        /// </summary>
        private static Dictionary<String, GameObject> prefabsPrivate = new Dictionary<string, GameObject>();
        /// <summary>
        /// Словарь всех заготовок проектаю
        /// </summary>
        public static Dictionary<String, GameObject> prefabs
        {
            get
            {
                if(prefabsPrivate.Count==0)
                {
                    gameManagerInfo.AddPrefabToKeeper();
                }
                return prefabsPrivate;
            }
        }
        /// <summary>
        /// Добавить заготовку к словарю.
        /// </summary>
        /// <param name="namePrefab">Имя заготовки - ключ.</param>
        /// <param name="prefab">Заготовка - значение.</param>
        public static void AddPrefab(String namePrefab, GameObject prefab)
        {
            prefabsPrivate[namePrefab] = prefab;
        }
        /// <summary>
        /// Номер активного уровня.
        /// </summary>
        public static Int16 numberActiveLevel = 0;
        /// <summary>
        /// Загруженные уровни.
        /// </summary>
        private static List<LevelKeeper> levelKeepers = new List<LevelKeeper>();
        /// <summary>
        /// Загрузить все уровни.
        /// </summary>
        public static void LoadLevels()
        {
            LevelKeeper levelForLoad = new LevelKeeper(1);
            while (levelForLoad.LoadData())
            {
                levelKeepers.Add(new LevelKeeper(levelForLoad.GetDataForSave()));
                levelForLoad.levelNumber++;
            }
        }
        /// <summary>
        /// Сохранить все уровни.
        /// </summary>
        public static void SaveLevels()
        {
            for(Int32 i=0;i<levelKeepers.Count;i++)
            {
                levelKeepers[i].SaveData();
            }
        }
        /// <summary>
        /// Добавить еще один уровень.
        /// </summary>
        /// <param name="keeper"></param>
        public static void AddLevelKeeper(LevelKeeper keeper)
        {
            levelKeepers.Add(keeper);
        }
        /// <summary>
        /// Вернуть хранителя уровня или null, если его нет.
        /// </summary>
        /// <param name="number">Номер уровня.</param>
        /// <returns></returns>
        public static LevelKeeper GetKeeper(Int16 number)
        {
            LevelKeeper levelKeeper= levelKeepers.Find(x => x.levelNumber == number);
            if (levelKeeper != null)
                return levelKeeper;
            else
                return null;
        }
        /// <summary>
        /// Уровень, соответствующий этому номеру, открыт.
        /// </summary>
        /// <param name="number">Номер уровня.</param>
        /// <returns></returns>
        public static Boolean IsLevelOpen(Int16 number)
        {
            //если предыдущий уровень есть и он пройден, то этот уровень открыт.
            LevelKeeper levelKeeper = GetKeeper((Int16)(number-1));
            if (levelKeeper != null && levelKeeper.levelNumber==number-1)
                return levelKeeper.isLevelComplete;
            return false;
        }
        }
}
