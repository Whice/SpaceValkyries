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
    /// Объект для хранения характеристик игровых объектов.
    /// </summary>
    [Serializable]
    public class SpaceObject : ISpaceObject
    {
        #region Местоположение объекта.

        private Single positionPrivateX = 0;
        private Single positionPrivateY = 0;
        private Single positionPrivateZ = 0;
        /// <summary>
        /// Местоположение объекта.
        /// </summary>
        public Vector3 position
        {
            get
            {
                return new Vector3
                    (
                    this.positionPrivateX,
                    this.positionPrivateY,
                    this.positionPrivateZ
                    );
            }
            set
            {
                this.positionPrivateX = value.x;
                this.positionPrivateY = value.y;
                this.positionPrivateZ = value.z;
            }
        }

        #endregion

        #region Поворот объекта.

        private Single rotationPrivateX = 0;
        private Single rotationPrivateY = 0;
        private Single rotationPrivateZ = 0;
        private Single rotationPrivateW = 0;
        /// <summary>
        /// Поворот объекта.
        /// </summary>
        public Quaternion rotation
        {
            get
            {
                return new Quaternion
                    (
                    this.rotationPrivateX,
                    this.rotationPrivateY,
                    this.rotationPrivateZ,
                    this.rotationPrivateW
                    );
            }
            set
            {
                this.rotationPrivateX = value.x;
                this.rotationPrivateY = value.y;
                this.rotationPrivateZ = value.z;
                this.rotationPrivateW = value.w;
            }
        }

        #endregion

        /// <summary>
        /// Имя заготовки объекта.
        /// </summary>
        private String namePrefabPrivate = "";
        public String namePrefab => this.namePrefabPrivate;

        /// <summary>
        /// Новый объект хранения.
        /// </summary>
        /// <param name="position">Местоположение объекта.</param>
        /// <param name="rotation">Поворот объекта.</param>
        /// <param name="namePrefab">Имя заготовки объекта.</param>
        public SpaceObject(Vector3 position, Quaternion rotation, String namePrefab)
        {
            this.position = position;
            this.rotation = rotation;
            this.namePrefabPrivate = namePrefab;
        }

    }
}
