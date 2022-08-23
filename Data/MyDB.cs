using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Role_Test.Data;

public class MyDB : IdentityDbContext<MyUser, MyRole,string>
{
    public MyDB(DbContextOptions<MyDB> options)
        : base(options)
    {

    }
    public override DbSet<MyRole> Roles { get => base.Roles; set => base.Roles = value; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        foreach (var item in GetRoles())
        {

            builder.Entity<MyRole>().HasData(item);

        }

    }

    public List<MyRole> GetRoles()
    {
        var list = new List<MyRole>();
        list.Add(new MyRole { Id = "b0eb6d15-ca41-4f2c-838d-0169b578b305", Name = "Sales", NormalizedName = "Sales", Controller_Name = "Sales", Action_Name = "Index,Create,Update,Delete" });
        list.Add(new MyRole { Id = "33b3b157-21c9-4f80-b006-5f0219e9c968", Name = "Comp", NormalizedName = "Comp", Controller_Name = "Companies", Action_Name = "Index,Create,Update,Delete" });
        list.Add(new MyRole { Id = "c1e2240e-35c6-4939-a235-4f55b866d7f9", Name = "Emp", NormalizedName = "Emp", Controller_Name = "Employs", Action_Name = "Index,Create,Update,Delete" });
        list.Add(new MyRole { Id = "5344b217-24bc-433c-b11d-a7bce2ee17a2", Name = "Off", NormalizedName = "Off", Controller_Name = "Officers", Action_Name = "Index,Create,Update,Delete" });
        list.Add(new MyRole { Id = "74b43960-7bd2-42d1-b25d-555315f8df98", Name = "Set", NormalizedName = "Set", Controller_Name = "Settings", Action_Name = "Index,Create,Update,Delete" });

        return list;
    }
}
