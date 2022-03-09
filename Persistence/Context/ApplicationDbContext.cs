using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>().Property(p => p.Rate).HasColumnType("decimal(10, 2)");

            modelBuilder.Entity<Source>().HasData(
                new Source { Id = 1, Name = "The Irish Sun", Url = "https://www.thesun.ie" },
                new Source { Id = 2, Name = "The Boston Globe", Url = "https://www.bostonglobe.com" },
                new Source { Id = 3, Name = "The Indian Express", Url = "https://indianexpress.com" },
                new Source { Id = 4, Name = "Birmingham Live", Url = "https://www.birminghammail.co.uk" }
            );

            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    Id = 1,
                    Title = "Piers Morgan fights back tears over pal Shane Warne's death as he watches emotional TV tribute",
                    Content = "PIERS Morgan fought back tears over his close friend Shane Warne's death while watching an emotional TV tribute.\nRemembering Shane Warne - a repeat documentary in honour of the cricketing legend - is being aired on Sky.\n2 Shane Warne with Piers Morga... [1688 chars]",
                    Description = "PIERS Morgan fought back tears over his close friend Shane Warne's death while watching an emotional TV tribute.Remembering Shane Warne - a repeat doc",
                    Url = "https://www.thesun.ie/tv/8464762/piers-morgan-fights-back-tears-shane-warne-death/",
                    Image = "https://www.thesun.ie/wp-content/uploads/sites/3/2022/03/comp-skc-shane-warne-piers.jpg?strip=all&quality=100&w=1200&h=800&crop=1",
                    PublishedAt = DateTime.Now,
                    SourceId = 1
                },
                new Post
                {
                    Id = 2,
                    Title = "As the world watches the war in Ukraine, educators are facing the challenges of teaching history in real time",
                    Content = "Governments, think tanks, and analysts around the world had been asking the same questions. But Rinaldi, a teacher at Newton South High School, and his young minds, a group of seniors in his comparative politics and world government seminar, happened... [6697 chars]",
                    Description = "As the war in Ukraine unfolds, teachers have the unique obligation to balance giving students information and historical context about the conflict, while also quelling theirs fears and anxiety",
                    Url = "https://www.bostonglobe.com/2022/03/06/metro/world-watches-war-ukraine-educators-are-facing-challenges-teaching-history-real-time/",
                    Image = "https://bostonglobe-prod.cdn.arcpublishing.com/resizer/Pr3Nd9bEjaAn4uiNcAsuDoH4kmI=/506x0/cloudfront-us-east-1.images.arcpublishing.com/bostonglobe/5CFA2HR2ZRB2DI6RJOILVP7ASY.jpg",
                    PublishedAt = DateTime.Now,
                    SourceId = 2
                },
                new Post
                {
                    Id = 3,
                    Title = "A millennial watches Angoor: In dark times, revisiting Gulzar’s cult classic",
                    Content = "Amid dark times, we look for a reprieve in cinema or books. The last two years, however, have produced few mood lifters as both the film industry and OTT platforms seem partial towards dark thrillers, murder mysteries, social dramas or biopics. Where... [4149 chars]",
                    Description = "Today, when Bollywood’s idea of comedies involve a fair degree of sexism, Angoor comes across as simple, clean, and a crisp comedy-drama. Here's revisiting the Gulzar directorial as it completes 40 years of its release.",
                    Url = "https://indianexpress.com/article/entertainment/bollywood/a-millennial-watches-angoor-in-dark-times-revisiting-gulzars-cult-classic-7802072/",
                    Image = "https://images.indianexpress.com/2022/03/angoor-40-years.jpg",
                    PublishedAt = DateTime.Now,
                    SourceId = 3
                },
                new Post
                {
                    Id = 4,
                    Title = "Bruno Lage makes Max Kilman admission after Gareth Southgate watches Wolves horror show",
                    Content = "Bruno Lage has reiterated his support for Max Kilman but he doesn’t believe the Wolves defender’s recent struggles should be attributed to the war in Ukraine.\nKilman’s mother, Maria, is Ukrainian and the Wolves defender was contacted by Andriy Shevch... [2668 chars]",
                    Description = "Wolverhampton Wanderers head coach Bruno Lage has been discussing England hopeful Max Kilman's form",
                    Url = "https://www.birminghammail.co.uk/sport/football/football-news/wolves-max-kilman-southgate-england-23308321",
                    Image = "https://i2-prod.birminghammail.co.uk/sport/football/football-news/article23308507.ece/ALTERNATES/s1200/0_JS259676123.jpg",
                    PublishedAt = DateTime.Now,
                    SourceId = 4
                }

            );

            base.OnModelCreating(modelBuilder);
        }
        //public DbSet<Product> Products { get; set; }
        public DbSet<Source> Sources { get; set; }
        public DbSet<Post> Posts { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
