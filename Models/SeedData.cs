using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoMateProjectShare.Data;

namespace YoMateProjectShare.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new YoMateProjectShareContext(
                serviceProvider.GetRequiredService<DbContextOptions<YoMateProjectShareContext>>()))
            {
                if (context.Projects.Any())
                {
                    return;
                }

                context.Projects.AddRange(
                    new ScienceProjects
                    {
                        ArticleName = "Example 1",
                        AuthorName = "Example Author 1",
                        UploadTime = DateTime.Parse("2020-9-3"),
                        AbstractText = "This is a Science major example",
                        FieldOfStudy = "Science"
                    },

                    new EngineeringProjects
                    {
                        ArticleName = "Example 2",
                        AuthorName = "Example Author 2",
                        UploadTime = DateTime.Parse("2020-9-2"),
                        AbstractText = "This is an Engineering example",
                        FieldOfStudy = "Engineering"
                    },

                    new OtherProjects
                    {
                        ArticleName = "Example 3",
                        AuthorName = "Example Author 23",
                        UploadTime = DateTime.Parse("2020-9-1"),
                        AbstractText = "This is a Other major example",
                        FieldOfStudy = "Other"
                    },

                    new OtherProjects
                    {
                        ArticleName = "Example 4",
                        AuthorName = "Example Author 4",
                        UploadTime = DateTime.Parse("2020-8-31"),
                        AbstractText = "This is an example",
                        FieldOfStudy = "Other"
                    },

                    new OtherProjects
                    {
                        ArticleName = "Example 5",
                        AuthorName = "Example Author 5",
                        UploadTime = DateTime.Parse("2020-8-30"),
                        AbstractText = "This is an example",
                        FieldOfStudy = "Other"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
