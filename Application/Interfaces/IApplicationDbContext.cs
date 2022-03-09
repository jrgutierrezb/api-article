using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
       // DbSet<Product> Products { get; set; }
        DbSet<Source> Sources { get; set; }
        DbSet<Post> Posts { get; set; }
        Task<int> SaveChangesAsync();
    }
}
