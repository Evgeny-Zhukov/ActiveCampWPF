using System;
using System.Collections.Generic;

namespace ActiveCamp.BL.Model
{
    public class Group
    {
        #region Свойства
        /// <summary>
        /// ИД группы.
        /// </summary>
        public int GroupId { get; private set; }

        /// <summary>
        /// ИД маршрута.
        /// </summary>
        public int RouteId { get; private set; }

        /// <summary>
        /// Ссылка-приглашение.
        /// </summary>
        public string InvitationLink { get; private set; }

        /// <summary>
        /// Идентификаторы пользователей.
        /// </summary>
        public List<int> UserIds { get; private set; } = new List<int>();

        /// <summary>
        /// Руководитель группы.
        /// </summary>
        public User GroupSupervisor { get; private set; }
        #endregion

        public Group() { }

        /// <summary>
        /// Создает новую группу.
        /// </summary>
        /// <param name="routeId">ИД маршрута</param>
        /// <param name="invitationLink">Ссылка-приглашение</param>
        /// <param name="groupSupervisor">Руководитель группы</param>
        /// <param name="userIds">Идентификаторы пользователей</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Group(int routeId, string invitationLink, User groupSupervisor, List<int> userIds)
        {
            SetRouteId(routeId);
            SetInvitationLink(invitationLink);
            SetGroupSupervisor(groupSupervisor);
            SetUserIds(userIds);
        }

        /// <summary>
        /// Устанавливает ИД маршрута.
        /// </summary>
        /// <param name="routeId">ИД маршрута</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetRouteId(int routeId)
        {
            if (routeId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(routeId), "ID маршрута должен быть положительным числом.");
            }
            RouteId = routeId;
        }

        /// <summary>
        /// Устанавливает ссылку-приглашение.
        /// </summary>
        /// <param name="invitationLink">Ссылка-приглашение</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void SetInvitationLink(string invitationLink)
        {
            InvitationLink = invitationLink ?? throw new ArgumentNullException(nameof(invitationLink), "Ссылка-приглашение не может быть пустой или null.");
        }

        /// <summary>
        /// Устанавливает руководителя группы.
        /// </summary>
        /// <param name="groupSupervisor">Руководитель группы</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void SetGroupSupervisor(User groupSupervisor)
        {
            GroupSupervisor = groupSupervisor ?? throw new ArgumentNullException(nameof(groupSupervisor), "Руководитель группы не может быть пустым или null.");
        }

        /// <summary>
        /// Устанавливает идентификаторы пользователей.
        /// </summary>
        /// <param name="userIds">Идентификаторы пользователей</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void SetUserIds(List<int> userIds)
        {
            UserIds = userIds ?? throw new ArgumentNullException(nameof(userIds), "Список идентификаторов пользователей не может быть пустым или null.");
        }

        /// <summary>
        /// Добавляет идентификатор пользователя в группу.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void AddUserId(int userId)
        {
            if (userId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(userId), "ID пользователя должен быть положительным числом.");
            }
            UserIds.Add(userId);
        }

        /// <summary>
        /// Внутренний метод для установки ИД группы, доступен только внутри сборки.
        /// </summary>
        /// <param name="groupId">ИД группы</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        internal void SetGroupId(int groupId)
        {
            if (groupId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(groupId), "ID группы должен быть положительным числом.");
            }
            GroupId = groupId;
        }
    }

}
