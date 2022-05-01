
namespace MinimalAPI.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

public class CourseDataContext : DbContext
{
    public DbSet<CourseType> CourseTypes {get;set;}
    public DbSet<Course> Courses {get;set;}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
        
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));

		optionsBuilder
			.UseMySql(@"Connection String", serverVersion);


	}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>()
            .HasOne(p => p.CourseTypeInfo)
            .WithMany(b => b.CourseList);
    }


	public virtual void Commit()
    {
        try
        {
            base.SaveChanges();
        }
        catch (Exception db)
        {
			Console.WriteLine(db.ToString());

            throw;  // You can also choose to handle the exception here...
        }


    }

}