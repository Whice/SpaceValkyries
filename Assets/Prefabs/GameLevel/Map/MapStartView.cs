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
    /// Задает начальный внешний вид для препятствий и врагов на карте.
    /// </summary>
    public class MapStartView
    {
        /// <summary>
        /// Базовый размер астероидов. 
        /// </summary>
        private const Single SIZE_OF_ASTEROID = 2.3f;
        /// <summary>
        /// Информация о карте.
        /// </summary>
        private GameMapInfo mapInfo = null;
        public MapStartView(GameMapInfo mapInfo)
        {
            this.mapInfo = mapInfo;
        }
        /// <summary>
        /// Установить внешний вид для всех объектов.
        /// </summary>
        /// <param name="spaceObjects">Характеристики препятствий.</param>
        /// <param name="enemies">Хранилище для врагов.</param>
        /// <param name="asteroids">Хранилище для астероидов.</param>
        public void SetViewForAllObjects(List<ISpaceObject> spaceObjects, ref List<GameObject> enemies, ref List<GameObject> asteroids)
        {
            //Обнуление массивов
            enemies = new List<GameObject>();
            asteroids = new List<GameObject>();
            //Вспомогательные ссылки
            ISpaceObject spaceObject = null;
            GameObject newObject = null;
            GameObject enemyPrefab = this.mapInfo.gameManagerInfo.enemyPrefab;
            GameObject asteroidPrefab = this.mapInfo.gameManagerInfo.asteroidPrefab;
            Transform parentTransform = this.mapInfo.gameObject.transform;

            for (Int32 i=0;i<spaceObjects.Count;i++)
            {
                spaceObject = spaceObjects[i];

                if (spaceObject.namePrefab=="Enemy")
                {
                    newObject = MonoBehaviour.Instantiate
                        (
                        enemyPrefab,
                        spaceObject.position,
                        spaceObject.rotation
                        );
                    //добавить информации врагу,
                    //он будет пытаться убить игрока только
                    //если его видит камера.
                    EnemyInfo info = newObject.GetComponent<EnemyInfo>();
                    info.gameManager = this.mapInfo.gameManager;
                    info.gameManagerInfo = this.mapInfo.gameManagerInfo;
                    info.mainCamera = this.mapInfo.mainCamera;
                    this.mapInfo.enemies.Add(newObject);
                }
                else
                {
                    newObject = MonoBehaviour.Instantiate
                        (
                        asteroidPrefab,
                        spaceObject.position,
                        spaceObject.rotation
                        );
                    //размер астероида зависит от уровня
                    newObject.transform.localScale = new Vector3
                        (
                        SIZE_OF_ASTEROID * MainGameKeeper.numberActiveLevel,
                        SIZE_OF_ASTEROID * MainGameKeeper.numberActiveLevel,
                        SIZE_OF_ASTEROID * MainGameKeeper.numberActiveLevel
                        );
                    this.mapInfo.asteroids.Add(newObject);
                }

                newObject.transform.parent = parentTransform;
            }
        }
    }
}
