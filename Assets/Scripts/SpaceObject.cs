using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class SpaceObject : ISpaceObject
    {
        private Vector3 positionPrivate = new Vector3(0, 0, 0);
        public Vector3 position => this.positionPrivate;

        private Quaternion rotationPrivate = new Quaternion(0, 0, 0, 0);
        public Quaternion rotation => this.rotationPrivate;

        private String namePrefabPrivate = "";
        public String namePrefab => this.namePrefabPrivate;

        public SpaceObject(Vector3 position, Quaternion rotation, String namePrefab)
        {
            this.positionPrivate = position;
            this.rotationPrivate = rotation;
            this.namePrefabPrivate = namePrefab;
        }
    }
}
