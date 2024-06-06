
using ActiveCamp.BL.Controller;

namespace ActiveCamp.BL.Model
{
    public class UserIllness
    {
        #region Свойства
        /// <summary>
        /// Получает идентификатор заболевания пользователя.
        /// </summary>
        public int UserIllnessId { get; private set; }

        /// <summary>
        /// Получает идентификатор пользователя.
        /// </summary>
        public int UserID { get; private set; }

        /// <summary>
        /// Получает идентификатор заболевания.
        /// </summary>
        public int IllnessID { get; private set; }
        #endregion

        /// <summary>
        /// Создает заболевание пользователя.
        /// </summary>
        public UserIllness() { }

        /// <summary>
        /// Создает заболевание пользователя с указанными идентификаторами.
        /// </summary>
        /// <param name="userIllnessId">Идентификатор заболевания пользователя</param>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="illnessId">Идентификатор заболевания</param>
        public UserIllness(int userIllnessId, int userId, int illnessId)
        {
            UserIllnessId = userIllnessId;
            UserID = userId;
            IllnessID = illnessId;
        }

        /// <summary>
        /// Устанавливает идентификатор заболевания пользователя.
        /// </summary>
        /// <param name="userIllnessId">Идентификатор заболевания пользователя</param>
        public void SetUserIllnessId(int userIllnessId)
        {
            UserIllnessId = userIllnessId;
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
        /// Устанавливает идентификатор заболевания.
        /// </summary>
        /// <param name="illnessId">Идентификатор заболевания</param>
        public void SetIllnessId(Illness illness)
        {
            IllnessManager illnessManager = new IllnessManager();
            int userIllnessID = illnessManager.GetIllnessID(illness);
            UserIllnessId = userIllnessID;
        }
    }

}
