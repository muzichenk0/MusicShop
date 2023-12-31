﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MusicShop.DataAccess.Contexts.User
{
    /// <summary>
    /// Конфигурация модели для таблицы БД, основанная на <see cref="Domain.Models.User.User"/>.
    /// Сервис, зависимый и реализующий <see cref="IEntityTypeConfiguration{TEntity}"/>
    /// </summary>
    public class UserConfiguration : IEntityTypeConfiguration<Domain.Models.User.User>
    {
        /// <summary>
        /// Процедура для настройки модели, через ORM технологию, для дальнейшего создания таблицы в реляционной БД.
        /// </summary>
        /// <param name="builder">Строитель типа сущности</param>B
        public void Configure(EntityTypeBuilder<Domain.Models.User.User> builder)
        {
            builder
                .HasKey(u => u.Id);
            builder
                .Property(u => u.RegistratedIn)
                .HasConversion(d => d, d => DateTime.SpecifyKind(d, DateTimeKind.Utc));
            builder
                .Property(u => u.Rating)
                .HasDefaultValue(0.00);
            builder
                .HasMany(u => u.Offers)
                .WithOne(o => o.User)
                .HasForeignKey(u => u.UserId);
            builder
                .HasMany(u => u.SendedReviews)
                .WithOne(r => r.Sender)
                .HasForeignKey(r => r.SenderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(u => u.GainedReviews)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(u => u.ClosedOffers)
                .WithOne(o => o.ClosedUser)
                .HasForeignKey(o => o.ClosedUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(u => u.Qualifications)
                .WithMany(u => u.Users);
        }
    }
}
