﻿namespace MusicShop.AppData.Contexts.User.Repository
{
    /// <summary>
    /// Абстрактный тип, описывающий внешний интерфейс репозитория пользователя.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Получение всех пользователей, асинхронно.
        /// </summary>
        /// <param name="cancelToken">Жетон отмены асинхронной задачи</param>
        /// <returns>Выстроенное в оптимизированный запрос перечисление из пользователей.</returns>
        public Task<IQueryable<Domain.Models.User.User>> GetAllAsync(CancellationToken cancelToken = default);
        /// <summary>
        /// Получение пользователя по идентификатору, асинхронно.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя, для поиска того</param>
        /// <param name="cancelToken">Жетон отмены асинхронной задачи</param>
        /// <returns>Пользователя, чей идентификатор соответствует <paramref name="userId"/></returns>
        public Task<Domain.Models.User.User> GetByIdAsync(Guid userId, CancellationToken cancelToken = default);
        /// <summary>
        /// Добавление пользователя в БД, асинхронно.
        /// </summary>
        /// <param name="userToAdd">Пользователь,которого необходимо добавить</param>
        /// <param name="cancelToken">Жетон отмены асинхронной задачи</param>
        public Task AddAsync(Domain.Models.User.User userToAdd, CancellationToken cancelToken = default);
        /// <summary>
        /// Обновление состояния пользователя в БД, асинхронно.
        /// </summary>
        /// <param name="userToUpdate">Пользователь, чье состояние необходимо обновить</param>
        /// <param name="cancelToken">Жетон отмены асинхронной задачи</param>
        public Task UpdateAsync(Domain.Models.User.User userToUpdate, CancellationToken cancelToken = default);
        /// <summary>
        /// Удаление пользователя из БД, асинхронно
        /// </summary>
        /// <param name="usetToDelete">Пользователь, кого необходимо удалить</param>
        /// <param name="cancelToken">Жетон отмены асинхронной задачи</param>
        public Task DeleteAsync(Domain.Models.User.User usetToDelete, CancellationToken cancelToken = default);
    }
}