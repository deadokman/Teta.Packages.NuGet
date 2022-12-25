﻿using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Teta.UnitOfWork.Interfaces
{
    /// <summary>
    /// Интерфейс UnitOfWork
    /// </summary>
    public interface IUnitOfWork<TContext> : IUnitOfWorkBase
            where TContext : DbContext
    {
        /// <summary>
        /// Ссылка на DbContext
        /// </summary>
        /// <returns>Экземпляр контекста<typeparamref name="TContext"/>.</returns>
        TContext CommonContext { get; }

        /// <summary>
        /// Выполнить сохранение всех изменений из всех UnitOfWork
        /// </summary>
        /// <param name="unitOfWorks">Опциональный параметр, ссылка на оставшиеся UnitOfWork <see cref="IUnitOfWork"/> </param>
        /// <returns>A <see cref="Task{TResult}"/> Асинхронная операция возвращающая число измененных сущностей.</returns>
        Task SaveChangesAsync(params IUnitOfWorkBase[] unitOfWorks);
    }
}