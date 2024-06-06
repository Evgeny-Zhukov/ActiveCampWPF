using System;
using System.Collections.Generic;

namespace ActiveCamp.BL.Model
{
    public class UserProfile
    {
        #region Свойства
        /// <summary>
        /// Получает идентификатор пользователя.
        /// </summary>
        public int UserID { get; private set; }

        /// <summary>
        /// Получает имя пользователя.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Получает вес пользователя.
        /// </summary>
        public float Weight { get; private set; }

        /// <summary>
        /// Получает рост пользователя.
        /// </summary>
        public float Height { get; private set; }

        /// <summary>
        /// Получает пол пользователя.
        /// </summary>
        public string Gender { get; private set; }

        /// <summary>
        /// Получает список заболеваний пользователя.
        /// </summary>
        public List<UserIllness> UserIllnesses { get; private set; } = new List<UserIllness>();

        /// <summary>
        /// Получает список оборудования пользователя.
        /// </summary>
        public List<RecordOfUserEquipment> UserEquipment { get; private set; } = new List<RecordOfUserEquipment>();

        /// <summary>
        /// Получает список потребленной еды пользователя.
        /// </summary>
        public List<UserDish> UserFoodConsumptions { get; private set; } = new List<UserDish>();

        /// <summary>
        /// Получает опыт пользователя.
        /// </summary>
        public string Experience { get; private set; }
        #endregion

        /// <summary>
        /// Создает профиль пользователя.
        /// </summary>
        public UserProfile() { }

        /// <summary>
        /// Создает профиль пользователя с указанными параметрами.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="name">Имя пользователя</param>
        /// <param name="weight">Вес пользователя</param>
        /// <param name="height">Рост пользователя</param>
        /// <param name="gender">Пол пользователя</param>
        /// <param name="experience">Опыт пользователя</param>
        public UserProfile(int userId, string name, float weight, float height, string gender, string experience)
        {
            UserID = userId;
            Name = name;
            Weight = weight;
            Height = height;
            Gender = gender;
            Experience = experience;
        }

        /// <summary>
        /// Устанавливает идентификатор пользователя.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        public void SetUserId(int userId)
        {
            UserID = userId;
        }

        /// <summary>
        /// Устанавливает имя пользователя.
        /// </summary>
        /// <param name="name">Имя пользователя</param>
        public void SetName(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name), "Имя пользователя не может быть пустым или null.");
        }

        /// <summary>
        /// Устанавливает вес пользователя.
        /// </summary>
        /// <param name="weight">Вес пользователя</param>
        public void SetWeight(float weight)
        {
            Weight = weight;
        }

        /// <summary>
        /// Устанавливает рост пользователя.
        /// </summary>
        /// <param name="height">Рост пользователя</param>
        public void SetHeight(float height)
        {
            Height = height;
        }

        /// <summary>
        /// Устанавливает пол пользователя.
        /// </summary>
        /// <param name="gender">Пол пользователя</param>
        public void SetGender(string gender)
        {
            Gender = gender ?? throw new ArgumentNullException(nameof(gender), "Пол пользователя не может быть пустым или null.");
        }

        /// <summary>
        /// Устанавливает список заболеваний пользователя.
        /// </summary>
        /// <param name="userIllnesses">Список заболеваний пользователя</param>
        public void SetUserIllnesses(List<UserIllness> userIllnesses)
        {
            UserIllnesses = userIllnesses ?? throw new ArgumentNullException(nameof(userIllnesses), "Список заболеваний пользователя не может быть пустым или null.");
        }

        /// <summary>
        /// Добавляет заболевание пользователя.
        /// </summary>
        /// <param name="userIllness">Заболевание пользователя</param>
        public void AddUserIllness(UserIllness userIllness)
        {
            if (userIllness == null)
            {
                throw new ArgumentNullException(nameof(userIllness), "Заболевание пользователя не может быть null.");
            }
            UserIllnesses.Add(userIllness);
        }

        /// <summary>
        /// Устанавливает список оборудования пользователя.
        /// </summary>
        /// <param name="userEquipment">Список оборудования пользователя</param>
        public void SetUserEquipment(List<RecordOfUserEquipment> userEquipment)
        {
            UserEquipment = userEquipment ?? throw new ArgumentNullException(nameof(userEquipment), "Список оборудования пользователя не может быть пустым или null.");
        }

        /// <summary>
        /// Добавляет оборудование пользователя.
        /// </summary>
        /// <param name="equipment">Оборудование пользователя</param>
        public void AddUserEquipment(RecordOfUserEquipment equipment)
        {
            if (equipment == null)
            {
                throw new ArgumentNullException(nameof(equipment), "Оборудование пользователя не может быть null.");
            }
            UserEquipment.Add(equipment);
        }

        /// <summary>
        /// Устанавливает список потребленной еды пользователя.
        /// </summary>
        /// <param name="userFoodConsumptions">Список потребленной еды пользователя</param>
        public void SetUserFoodConsumptions(List<UserDish> userFoodConsumptions)
        {
            UserFoodConsumptions = userFoodConsumptions ?? throw new ArgumentNullException(nameof(userFoodConsumptions), "Список потребленной еды пользователя не может быть пустым или null.");
        }

        /// <summary>
        /// Добавляет потребленную еду пользователя.
        /// </summary>
        /// <param name="userDish">Потребленная еда пользователя</param>
        public void AddUserFoodConsumption(UserDish userDish)
        {
            if (userDish == null)
            {
                throw new ArgumentNullException(nameof(userDish), "Потребленная еда пользователя не может быть null.");
            }
            UserFoodConsumptions.Add(userDish);
        }

        /// <summary>
        /// Устанавливает опыт пользователя.
        /// </summary>
        /// <param name="experience">Опыт пользователя</param>
        public void SetExperience(string experience)
        {
            Experience = experience ?? throw new ArgumentNullException(nameof(experience), "Опыт пользователя не может быть пустым или null.");
        }
    }
}
