using Domoplat.System.Database.Entities;

namespace Domoplat.Tariffs.Entities;

/// <summary>
/// Тариф ЖКХ
/// </summary>
public class Tariff : IDomoplatEntity<int>
{
    /// <summary>
    /// Идентификатор типа тарифа
    /// </summary>  
    public int Id { get; set; }

    /// <summary>
    /// Название типа тарифа
    /// </summary>
    public string Name { get; set; }
}
