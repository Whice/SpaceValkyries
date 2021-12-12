using System;
using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface ISpaceObject
    {
        Vector3 position { get; }
        Quaternion rotation { get; }
        String namePrefab { get; }
    }
}
