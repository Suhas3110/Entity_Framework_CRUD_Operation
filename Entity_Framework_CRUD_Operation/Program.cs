using Entity_Framework_CRUD_Operation.Model;
using System;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;

namespace Entity_Framework_CRUD_Operation
{
    class Operations
    {
        public void insert()
        {
            //step 1 Model.context.cs object created
            Model.Entity_FrameworkEntities obj = new Entity_FrameworkEntities();

            //step 2 Table of created object
            Student ob = new Student();

            Console.WriteLine("Enter the Student ID");
            int ID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Student Name");
            string Name = Console.ReadLine();

            Console.WriteLine("Enter the Student Marks");
            int Marks = int.Parse(Console.ReadLine());

            ob.Id = ID;
            ob.Name = Name;
            ob.Marks = Marks;

            obj.Students.Add(ob);
            int n = obj.SaveChanges();
            if (n > 0)
            {
                Console.WriteLine("Record Inserted Successfully!!!");
            }
            else
            {
                Console.WriteLine("Record Not Inserted Successfully!!!");
            }

        }

        public void select()
        {

            //step 1 Model.context.cs object created
            Model.Entity_FrameworkEntities obj = new Entity_FrameworkEntities();

            //step 2 Table of created object
            Student ob = new Student();


            Console.WriteLine("Enter the Student Name");
            string Name = Console.ReadLine();

            Student std = obj.Students.FirstOrDefault(x => x.Name == Name);
            if(std!=null)
            {
                Console.WriteLine("Record Found!!!");
                Console.WriteLine("Student Id = "+std.Id);
                Console.WriteLine("Student Name = "+std.Name);
                Console.WriteLine("Student Marks = "+std.Marks);
            }
            else
            {
                Console.WriteLine("Not Record Found!!!");
            }

        }
        public void Update()
        {
            //step 1 Model.context.cs object created
            Model.Entity_FrameworkEntities obj = new Entity_FrameworkEntities();
            Console.WriteLine("Enter the Student Name");
            string Name= Console.ReadLine();
            
            var upadate=obj.Students.FirstOrDefault(x=>x.Name==Name);  
            
            if(upadate!=null)
            {
                upadate.Name = "Update Student Name";
                upadate.Name = "Rahul";
                int n=obj.SaveChanges();
                if(n>0)
                {
                    Console.WriteLine("Record Updated Successfully!!!");
                }
                else
                {
                    Console.WriteLine("Record Not Updated!!!");
                }
            }
        }

        public void Delete()
        {
            Model.Entity_FrameworkEntities obj = new Entity_FrameworkEntities();
            Console.WriteLine("Enter the Student Id");
            int Id=int.Parse(Console.ReadLine());
            var delete=obj.Students.FirstOrDefault(x=>x.Id==Id);
            int n=obj.SaveChanges();
            if(delete!=null)
            {
                Console.WriteLine("Deleted Permanantly!!!");
            }
            else
            {
                Console.WriteLine("Not deleted Permanantly");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Operations op = new Operations();
            //op.insert();
            //op.select();
            //op.Update();
            op.Delete();
            Console.ReadKey();
        }
    }
}
