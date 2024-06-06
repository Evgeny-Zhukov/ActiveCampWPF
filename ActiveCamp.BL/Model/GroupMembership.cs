using System;

namespace ActiveCamp.BL.Model
{
    public class GroupMembership
    {
        #region Свойства
        /// <summary>
        /// ИД группы.
        /// </summary>
        public int GroupId { get; private set; }

        /// <summary>
        /// ИД пользователя.
        /// </summary>
        public int UserId { get; private set; }

        /// <summary>
        /// Дата присоединения.
        /// </summary>
        public DateTime JoinedDate { get; private set; }
        #endregion

        public GroupMembership() { }

        /// <summary>
        /// Создает членство в группе.
        /// </summary>
        /// <param name="groupId">ИД группы</param>
        /// <param name="userId">ИД пользователя</param>
        /// <param name="joinedDate">Дата присоединения</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public GroupMembership(int groupId, int userId, DateTime joinedDate)
        {
            SetGroupId(groupId);
            SetUserId(userId);
            SetJoinedDate(joinedDate);
        }

        /// <summary>
        /// Устанавливает ИД группы.
        /// </summary>
        /// <param name="groupId">ИД группы</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetGroupId(int groupId)
        {
            if (groupId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(groupId), "ID группы должен быть положительным числом.");
            }
            GroupId = groupId;
        }

        /// <summary>
        /// Устанавливает ИД пользователя.
        /// </summary>
        /// <param name="userId">ИД пользователя</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetUserId(int userId)
        {
            if (userId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(userId), "ID пользователя должен быть положительным числом.");
            }
            UserId = userId;
        }

        /// <summary>
        /// Устанавливает дату присоединения.
        /// </summary>
        /// <param name="joinedDate">Дата присоединения</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void SetJoinedDate(DateTime joinedDate)
        {
            if (joinedDate == default(DateTime))
            {
                throw new ArgumentNullException(nameof(joinedDate), "Дата присоединения не может быть пустой.");
            }
            JoinedDate = joinedDate;
        }

        /// <summary>
        /// Внутренний метод для установки ИД членства в группе, доступен только внутри сборки.
        /// </summary>
        /// <param name="groupMembershipId">ИД членства в группе</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
    }

}
