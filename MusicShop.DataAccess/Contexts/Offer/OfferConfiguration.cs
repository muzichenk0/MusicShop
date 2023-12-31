﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MusicShop.DataAccess.Contexts.Offer
{ 
   /// <summary>
   /// Конфигурация модели для таблицы БД, основанная на <see cref="Domain.Models.Offer.Offer"/>.
   /// Сервис, зависимый и реализующий <see cref="IEntityTypeConfiguration{TEntity}"/>
   /// </summary>
    public class OfferConfiguration : IEntityTypeConfiguration<Domain.Models.Offer.Offer>
    {
        /// <summary>
        /// Процедура для настройки модели, через ORM технологию, для дальнейшего создания таблицы в реляционной БД.
        /// </summary>
        /// <param name="builder">Строитель типа сущности</param>
        public void Configure(EntityTypeBuilder<Domain.Models.Offer.Offer> builder)
        {
            builder
                .HasKey(o => o.Id);
            builder
                .HasOne(o => o.OfferCategory)
                .WithMany(o => o.Offers)
                .HasForeignKey(o => o.OfferCategoryId)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasMany(o => o.OfferFiles)
                .WithOne(f => f.FileOffer)
                .HasForeignKey(f => f.OfferId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
