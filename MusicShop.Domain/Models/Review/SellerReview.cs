﻿using MusicShop.Domain.Models.Base;

namespace MusicShop.Domain.Models.Review
{
    /// <summary>
    /// Отзыв продавца.
    /// Зависима и реализует <see cref="BaseEntity"/>
    /// </summary>
    public class SellerReview : BaseEntity
    {
        /// <summary>
        /// Заголовок отзыва.
        /// </summary>
        public string Topic { get; set; }
        /// <summary>
        /// Отзыв продаца.
        /// </summary>
        public double Rating { get; set; }
        /// <summary>
        /// Описание отзыва.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Пользователь, получивший отзыв.
        /// Навигационное свойство в отношении один ко многим,
        /// Между главной сущностью - <see cref="User.User"/> и зависимой <see cref="SellerReview"/>
        /// </summary>
        public User.User User { get; set; }
        /// <summary>
        /// Идентификатор пользователя, получившего отзыв.
        /// Внешний ключ для отношения один ко многим,
        /// Между главной сущностью - <see cref="User.User"/> и зависимой <see cref="SellerReview"/>
        /// </summary>
        public Guid? UserId { get; set; }
        /// <summary>
        /// Пользователь, покупатель, оставляющий отзыв.
        /// Навигационное свойство для отношения один ко многим,
        /// Между главной сущностью - <see cref="User.User"/> и зависимой <see cref="SellerReview"/>
        /// </summary>
        public User.User Sender { get; set; }
        /// <summary>
        /// Идентификатор пользователя, оставившего отзыв.
        /// Внешний ключ для отношения один ко многим,
        /// Между главной сущностью - <see cref="User.User"/> и зависимой <see cref="SellerReview"/>
        /// </summary>
        public Guid? SenderId { get; set; }
        /// <summary>
        /// Дата отзыв.
        /// </summary>
        public DateTime Date { get; set; }
    }
}