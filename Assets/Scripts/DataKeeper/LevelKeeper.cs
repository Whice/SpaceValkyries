using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class LevelKeeper
    {
        /// <summary>
        /// Уровень уже был создан.
        /// </summary>
        public Boolean isCreatedLevel
        {
            get => this.dataForSave.isCreatedLevel;
        }
        /// <summary>
        /// Номер уровня.
        /// </summary>
        public Int16 levelNumber
        {
            get => this.dataForSave.levelNumber;
            set => this.dataForSave.levelNumber = value;
        }
        /// <summary>
        /// Новый хранитель через номер.
        /// </summary>
        /// <param name="levelNumber"> Номер уровня, которому принадлежит хранитель.</param>
        public LevelKeeper(Int16 levelNumber)
        {
            this.levelNumber = levelNumber;
        }
        /// <summary>
        /// Новый хранитель через данные.
        /// </summary>
        /// <param name="dataForSave"></param>
        public LevelKeeper(DataForSave dataForSave)
        {
            this.dataForSave = dataForSave;
        }

        #region Данные для сохранения

        /// <summary>
        /// Сохраняемые данные.
        /// </summary>
        private DataForSave dataForSave = new DataForSave();
        /// <summary>
        /// Установить данные для сохранения через GameManagerInfo.
        /// </summary>
        /// <param name="levelMaganager"></param>
        public void SetDataForLevel(GameManagerInfo levelMaganager)
        {
            GameMapInfo mapInfo = levelMaganager.mapInfo;
            this.dataForSave.enemys = mapInfo.enemies;
            this.dataForSave.asteroids = mapInfo.asteroids;
        }
        /// <summary>
        /// Получить данные для сохранения для GameManagerInfo.
        /// </summary>
        /// <param name="levelMaganager"></param>
        public void GetDataForLevel(GameManagerInfo levelMaganager)
        {
            GameMapInfo mapInfo = levelMaganager.mapInfo;
            mapInfo.enemies = this.dataForSave.enemys;
            mapInfo.asteroids = this.dataForSave.asteroids;
        }
        /// <summary>
        /// Получить копию данных для сохранения.
        /// </summary>
        /// <returns></returns>
        public DataForSave GetDataForSave()
        {
            return this.dataForSave;
        }

        #endregion

        #region Сохранение

        /// <summary>
        /// Основная часть имени для сохранения.
        /// </summary>
        private const String nameForSave = "Level ";
        /// <summary>
        /// Расширение файла.
        /// </summary>
        private const String filenameExtension = ".lvlsv";
        /// <summary>
        /// Полное имя для сохранения.
        /// </summary>
        public String fullNameForSave
        {
            get => nameForSave + levelNumber.ToString() + filenameExtension;
        }
        /// <summary>
        /// Выполнить сохранение.
        /// </summary>
        public void SaveData()
        {
            /*BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(this.fullNameForSave, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, this.dataForSave);
            }*/
        }
        /// <summary>
        /// Выполнить загрузку.
        /// </summary>
        public bool LoadData()
        {
            if(!File.Exists(this.fullNameForSave))
            {
                return false;
            }
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(this.fullNameForSave, FileMode.Open))
            {
                DataForSave dataForLoad = (DataForSave)formatter.Deserialize(fs);
                this.dataForSave.enemys = dataForLoad.enemys;
                this.dataForSave.asteroids = dataForLoad.asteroids;
            }
            return true;
        }


        #endregion
    }
}
