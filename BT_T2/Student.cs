using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_T2
{
    internal class Student
    {
        private string studentID;
        private string fullName;
        private float averageScore;
        private string faculty;

        public string StudentID { get => studentID; set => studentID = value;}
        public string FullName { get => fullName; set => fullName = value; }
        public float AverageScore { get => averageScore; set => averageScore = value; }
        public string Faculty { get => faculty; set => faculty = value; }


        public Student() 
        { 
        }
        public Student(string studentID, string fullName, float averageScore, string faculty)
        {
            this.studentID = studentID;
            this.fullName = fullName;
            this.averageScore = averageScore;
            this.faculty = faculty;
        }

        public void InputStudent()
        {
            Console.Write("Nhap Student ID: ");
            studentID = Console.ReadLine();
            Console.Write("Nhap Full Name: ");
            fullName = Console.ReadLine();
            Console.Write("Nhap Average Score: ");
            averageScore = float.Parse(Console.ReadLine());
            Console.Write("Nhap Faculty: ");
            faculty = Console.ReadLine();
        }

        public void Show() 
        {
            Console.WriteLine("MSSV: {0} Ho ten: {1} Khoa: {2} Diem TB: {3}", studentID, fullName, faculty, averageScore);
        }
    }
}
