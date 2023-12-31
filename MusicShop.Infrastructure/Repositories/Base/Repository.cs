﻿using Microsoft.EntityFrameworkCore;
using MusicShop.Domain.Models.Base;

namespace MusicShop.Infrastructure.Repositories.Base
{
    /// <summary>
    /// Обобщенная сущность, описывающая интерфейс модели репозитория, используемый для выполнения обязанностей сущности.
    /// </summary>
    /// <typeparam name="T">Тип модели, на основе которой была создана таблица в БД. Класс адаптирован для взаимодействия с этим типом.</typeparam>
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Контекст, связывающий с таблицами БД.
        /// </summary>S
        protected DbContext DbContext { get; set; }
        /// <summary>
        /// Текущая таблица из БД, сформированная на основе сущности <see cref="T"/>
        /// </summary>
        protected DbSet<T> DbSet { get; set; }
         
        public Repository(DbContext dbContext)
            => (DbContext, DbSet) = (dbContext, dbContext.Set<T>());
        ///<inheritdoc/>
        public async Task<IQueryable<T>> GetAllAsync(CancellationToken token = default)
            => await Task.Run(() => DbSet.AsQueryable());
        ///<inheritdoc/>
        public async Task<IQueryable<T>> GetAllFilteredAsync(Func<T, bool>predicateFilter, CancellationToken token = default)
            => await Task.Run(() => DbSet.Where(predicateFilter).AsQueryable());
        ///<inheritdoc/>
        public async Task<T> GetByIdAsync(Guid id, CancellationToken token = default)
            => await Task.Run(async () =>
            {
                T? foundObj = await DbSet.FindAsync(id);
                if (foundObj is null)
                    throw new ArgumentNullException(nameof(foundObj));
                return foundObj;
            });
        ///<inheritdoc/>
        public async Task UpdateAsync(T objToUpdate, CancellationToken token = default)
            => await Task.Run(async () =>
            {
                if (objToUpdate is null)
                    throw new ArgumentNullException(nameof(objToUpdate));
                if (await DbSet.FindAsync(objToUpdate.Id) is null)
                    throw new ArgumentNullException($"record with id = {objToUpdate.Id} not found");

                DbContext.Update(objToUpdate);
                await DbContext.SaveChangesAsync();
            });
        ///<inheritdoc/>
        public async Task DeleteAsync(T objToDelete, CancellationToken token = default)
            => await Task.Run(async () =>
            {
                if (objToDelete == null)
                   throw new ArgumentNullException(nameof(objToDelete));

                DbContext.Remove(objToDelete);
                await DbContext.SaveChangesAsync();
            });
        ///<inheritdoc/>
        public async Task AddAsync(T? objToAdd, CancellationToken token = default)
            => await Task.Run(async () =>
            {
                if (objToAdd is null)
                    throw new ArgumentNullException(nameof(objToAdd));

                await DbSet.AddAsync(objToAdd);
                await DbContext.SaveChangesAsync();
            });
    }
}
