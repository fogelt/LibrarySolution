namespace Library.Core.Interfaces;

public interface ISearchable
{
  bool Matches(string searchTerm);
}