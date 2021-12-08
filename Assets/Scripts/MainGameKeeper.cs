using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public static class MainGameKeeper
    {
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
        /// <param name="number"></param>
        /// <returns></returns>
        public static LevelKeeper GetKeeper(Int16 number)
        {
            if (levelKeepers.Count <= number)
                return null;

            return levelKeepers[number];
        }
    }
}
