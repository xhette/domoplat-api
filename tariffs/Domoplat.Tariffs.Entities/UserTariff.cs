using Domoplat.System.Database.Entities;

namespace Domoplat.Tariffs.Entities;

/// <summary>
/// Тариф пользователя
/// </summary>
public class UserTariff : IDomoplatEntity<int>
{
    /// <summary>
    /// Идентификатор тарифа пользователя
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Идентификатор пользователя (внешний ключ из микросервиса Identity)
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Идентификатор тарифа компании
    /// </summary>
    public int CompanyTariffId { get; set; }

    /// <summary>
    /// Тариф компании
    /// </summary>
    public virtual CompanyTariffs CompanyTariff { get; set; }
}
