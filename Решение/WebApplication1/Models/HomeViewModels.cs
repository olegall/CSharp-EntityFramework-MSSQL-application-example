using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Administration
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<Section> Sections { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Group> Groups { get; set; }

        public Administration()
        {
            Sections = new List<Section>();
            Employees = new List<Employee>();
            Groups = new List<Group>();
        }
    }

    public class Section
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? AdministrationId { get; set; }
        public Administration Administration { get; set; }

        public ICollection<Group> Groups { get; set; }
        public ICollection<Employee> Employees { get; set; }

        public Section()
        {
            Groups = new List<Group>();
            Employees = new List<Employee>();
        }
    }

    public class Group
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public int? SectionId { get; set; }
        public Section Section { get; set; }

        public ICollection<Employee> Employees { get; set; }
        public ICollection<Subgroup> Subgroups { get; set; }

        public Group()
        {
            Employees = new List<Employee>();
            Subgroups = new List<Subgroup>();
        }
    }

    public class Subgroup
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? GroupId { get; set; }
        public Group Group { get; set; }

        public ICollection<Employee> Employees { get; set; }

        public Subgroup()
        {
            Employees = new List<Employee>();
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string LastName { get; set; }

        public int? AdministrationId { get; set; }
        public Administration Administration { get; set; }

        public int? SectionId { get; set; }
        public Section Section { get; set; }

        public int? GroupId { get; set; }
        public Group Group { get; set; }

        public int? SubgroupId { get; set; }
        public Subgroup Subgroup { get; set; }
    }
}