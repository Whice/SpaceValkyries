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
        private const Single SIZE_OF_ASTEROID = 2.3f;
        private GameMapInfo mapInfo = null;
        public MapStartView(GameMapInfo mapInfo)
        {
            this.mapInfo = mapInfo;
        }
        public void SetViewForAllObjects(List<ISpaceObject> spaceObjects, ref List<GameObject> enemies, ref List<GameObject> asteroids)
        {
            ISpaceObject spaceObject = null;
            GameObject newObject = null;
            enemies = new List<GameObject>();
            asteroids = new List<GameObject>();
            asteroids = new List<GameObject>();
            Transform parentTransform = this.mapInfo.gameObject.transform;

            for (Int32 i=0;i<spaceObjects.Count;i++)
            {
                spaceObject = spaceObjects[i];

                if (spaceObject.namePrefab=="Enemy")
                {
                    newObject = MonoBehaviour.Instantiate
                        (
                        this.mapInfo.gameManagerInfo.enemyPrefab,
                        spaceObject.position,
                        spaceObject.rotation
                        );
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
                        this.mapInfo.gameManagerInfo.asteroidPrefab,
                        spaceObject.position,
                        spaceObject.rotation
                        );
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
