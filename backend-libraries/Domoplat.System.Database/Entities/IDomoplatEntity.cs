namespace Domoplat.System.Database.Entities;

public interface IDomoplatEntity<TKey> where TKey : struct 
{
    TKey Id { get; set; }
}