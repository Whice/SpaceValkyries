using System;
using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    /// <summary>
    /// Дает доступ к характеристикам игровых объектов.
    /// </summary>
    public interface ISpaceObject
    {
        /// <summary>
        /// Местоположение объекта.
        /// </summary>
        Vector3 position { get; }
        /// <summary>
        /// Поворот объекта.
        /// </summary>
        Quaternion rotation { get; }
        /// <summary>
        /// Имя заготовки объекта.
        /// </summary>
        String namePrefab { get; }
    }
}
