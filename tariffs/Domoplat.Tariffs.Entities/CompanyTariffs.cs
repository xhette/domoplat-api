using Domoplat.System.Database.Entities;

namespace Domoplat.Tariffs.Entities;

/// <summary>
/// Тариф компании
/// </summary>
public class CompanyTariffs : IDomoplatEntity<int>
{
    /// <summary>
    /// Идентификатор тарифа компании
    /// </summary>  
    public int Id { get; set; }
    
    /// <summary>
    /// Идентификатор компании
    /// </summary>
    public Guid CompanyId { get; set; }
    
    /// <summary>
    /// Идентификатор тарифа
    /// </summary>
    public int TariffId { get; set; }

    /// <summary>
    /// Активен ли тариф
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Цена тарифа
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Компания
    /// </summary>
    public virtual Company Company { get; set; }

    /// <summary>
    /// Тариф
    /// </summary>
    public virtual Tariff Tariff { get; set; }
}
