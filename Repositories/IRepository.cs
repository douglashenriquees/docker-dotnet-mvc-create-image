using System.Collections.Generic;
using mvc1.Models;

namespace mvc1.Repositories;

public interface IRepository
{
    IEnumerable<Produto> Produtos { get; }
}