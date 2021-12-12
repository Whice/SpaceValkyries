using Assets.Scripts;
using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Prefabs.GameLevel.Map
{
    /// <summary>
    /// Создает начальные значения для препятствий и врагов на карте.
    /// </summary>
    public class MapStartController
    {
        /// <summary>
        /// Поворот всех объектов вниз "лицом".
        /// </summary>
        private Quaternion rotate = Quaternion.AngleAxis(90, new Vector3(0, 1, 0));
        /// <summary>
        /// Информация о карте.
        /// </summary>
        private GameMapInfo mapInfo = null;

        public MapStartController(GameMapInfo mapInfo)
        {
            this.mapInfo = mapInfo;
        }

        /// <summary>
        /// Создать вектор положения со случайным смещением на карте по одной оси (z).
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private Vector3 CreateReandomYVector3(Single x, Single y)
        {
            return new Vector3
                (
                x,
                y, 
                UnityEngine.Random.Range
                    (
                    -this.mapInfo.gameManagerInfo.boundHorizontal,
                    this.mapInfo.gameManagerInfo.boundHorizontal + 1
                    )
                );
        }
        /// <summary>
        /// Создать все объекты для карты.
        /// </summary>
        public List<ISpaceObject> CreateMapObjects()
        {
            List<ISpaceObject> spaceObjects = new List<ISpaceObject>(GameMapInfo.MAX_COUNT_OBJECTS);

            Int16 level = MainGameKeeper.numberActiveLevel;
            LevelKeeper levelKeeper = MainGameKeeper.GetKeeper(level);
            if (levelKeeper!=null)
            {
                spaceObjects = levelKeeper.GetDataForLevel() as List<ISpaceObject>;
                return spaceObjects;
            }

            Int32 countOfdifficulties = 1;
            const Single lengthMap = GameMapInfo.LENGTH_MAP;
            const Single lengthObject = GameMapInfo.LENGTH_ONE_OBJECT;
            Single y = this.mapInfo.playerSpaceShip.transform.localPosition.y;
            Single startX = this.mapInfo.playerSpaceShip.transform.position.x + 100;
            SpaceObject newObject = null;

            for (Single x = startX; x < lengthMap; x += lengthObject, countOfdifficulties++)
            {
                if (countOfdifficulties % 5 == 0)
                {
                    newObject = new SpaceObject(CreateReandomYVector3(-x, y), this.rotate, "Enemy");
                }
                else
                {
                    newObject = new SpaceObject(CreateReandomYVector3(-x, y), this.rotate, "Asteroid");
                }
                spaceObjects.Add(newObject);
            }

            levelKeeper = new LevelKeeper(level, spaceObjects);
            levelKeeper.SaveData();
            MainGameKeeper.AddLevelKeeper(levelKeeper);

            return spaceObjects;
        }
    }
}
