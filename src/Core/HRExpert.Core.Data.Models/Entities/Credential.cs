using System.ComponentModel.DataAnnotations.Schema;

namespace HRExpert.Core.Data.Models
{
    /// <summary>
    /// Данные для входа
    /// </summary>
    [Table("Credentials")]
    public class Credential: ExtCore.Data.Models.Abstractions.IEntity
    {/*
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Column("Id")]
        [Key]
        public long Id { get; set; }*/
        /// <summary>
        /// Значение(Логин/емаил/и т.д.)
        /// </summary>
        [Column("Value")]
        public string Value { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        [Column("Secret")]
        public string Secret { get; set; }
        /// <summary>
        /// Идентификатор типа(емаил,логин, телефон)
        /// </summary>
        [Column("CredentialTypeId")]
        public long CredentialTypeId {get;set;}
        /// <summary>
        /// Тип
        /// </summary>
        [ForeignKey("CredentialTypeId")]
        public CredentialType CredentialType { get; set; }
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [ForeignKey("User")]
        public long UserId {get;set;}
        /// <summary>
        /// Пользователь
        /// </summary>
        public User User { get; set; }
    }
}
