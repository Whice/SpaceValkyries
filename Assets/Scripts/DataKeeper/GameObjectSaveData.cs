using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.DataKeeper
{
    /// <summary>
    /// Класс содержащий данные из класса GameObject, которые надо сохранить.
    /// </summary>
    [Serializable]
    public class GameObjectSaveData
    {
        public String nameOfPrefab = "";

        private Single positionX = 0;
        private Single positionY = 0;
        private Single positionZ = 0;
        public Vector3 position
        {
            get
            {
                return new Vector3
                (
                this.positionX,
                this.positionY,
                this.positionZ
                );
            }
            private set
            {
                this.positionX = value.x;
                this.positionY = value.y;
                this.positionZ = value.z;
            }
        }


        private Single rotationX = 0;
        private Single rotationY = 0;
        private Single rotationZ = 0;
        private Single rotationW = 0;
        public Quaternion rotation
        {
            get
            {
                return new Quaternion
                (
                this.rotationX,
                this.rotationY,
                this.rotationZ, 
                this.rotationW
                );
            }
            private set
            {
                this.rotationX = value.x;
                this.rotationY = value.y;
                this.rotationZ = value.z;
                this.rotationW = value.w;
            }
        }
        public GameObjectSaveData(GameObject gameObject)
        {
            this.nameOfPrefab = gameObject.name.Replace("(Clone)", "");
            this.position = gameObject.transform.position;
            this.rotation = gameObject.transform.rotation;
        }
    
    public  GameObject GetGameObject()
        {
            return GameObject.Instantiate(MainGameKeeper.prefabs[this.nameOfPrefab], this.position, this.rotation);
        }
    }
}
