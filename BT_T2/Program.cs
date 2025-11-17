using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_T2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Nhap thong tin sinh vien");
                Console.WriteLine("2. Hien thi danh sach sinh vien");
                Console.WriteLine("3. Xuat ra thong tin cac SV thuoc khoa 'CNTT'");
                Console.WriteLine("4. Xuat ra thong tin sinh vien co diem TB lon hon bang 5");
                Console.WriteLine("5. Sap xep danh sach sinh vien theo diem TB tang dan");
                Console.WriteLine("6. Xuat ra danh sach sinh vien co diem TB lon hon bang 5 va thuoc khoa 'CNTT'");
                Console.WriteLine("7. Xuat ra danh sach sinh vien co diem trung binh cao nhat va thuoc khoa 'CNTT");
                Console.WriteLine("8. So luong cua tung xep loai trong danh sach");
                Console.WriteLine("0. Thoat");
                Console.Write("Chon chuc nang (0-8): ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddStudent(students);
                        break;
                    case "2":
                        DisplayStudents(students);
                        break;
                    case "3":
                        DisplayStudentsByFaculty(students, "CNTT");
                        break;
                    case "4":
                        DisplayStudentsByAverageScore(students, 5);
                        break;
                    case "5":
                        SortStudentsByAverageScore(students);
                        break;
                    case "6":
                        DisplayStudentsByFacultyAndScore(students, "CNTT", 5);
                        break;
                    case "7":
                        DisplayTopStudentsByFaculty(students, "CNTT");
                        break;
                    case "8":
                        CountStudentsByClassification(students);
                        break;
                }
            }
        }

        static void AddStudent(List<Student> students)
        {
            Console.WriteLine("Nhap thong tin sinh vien:");
            Student student = new Student();
            student.InputStudent();
            students.Add(student);
        }

        static void DisplayStudents(List<Student> students)
        {
            Console.WriteLine("Danh sach sinh vien:");
            foreach (var student in students)
            {
                student.Show();
            }
        }

        static void DisplayStudentsByFaculty(List<Student> students, string faculty)
        {
            Console.WriteLine($"Sinh vien thuoc khoa '{faculty}':");
            var filteredStudents = students.Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase));
            foreach (var student in filteredStudents)
            {
                student.Show();
            }
        }

        static void DisplayStudentsByAverageScore(List<Student> students, float score)
        {
            Console.WriteLine($"Sinh vien co diem TB lon hon bang {score}:");
            var filteredStudents = students.Where(s => s.AverageScore > score);
            foreach (var student in filteredStudents)
            {
                student.Show();
            }
        }

        static void SortStudentsByAverageScore(List<Student> students)
        {
            Console.WriteLine("Danh sach sinh vien sap xep theo diem TB tang dan:");
            var sortedStudents = students.OrderBy(s => s.AverageScore);
            foreach (var student in sortedStudents)
            {
                student.Show();
            }
        }

        static void DisplayStudentsByFacultyAndScore(List<Student> students, string faculty, float score)
        {
            Console.WriteLine("Danh sach sinh vien co diem TB lon hon bang {score} va thuoc khoa '{faculty}':");
            var filteredStudents = students.Where(s => s.AverageScore > score && s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase));
            foreach (var student in filteredStudents)
            {
                student.Show();
            }
        }

        static void DisplayTopStudentsByFaculty(List<Student> students, string faculty)
        {
            Console.WriteLine($"Sinh vien co diem trung binh cao nhat va thuoc khoa '{faculty}':");
            var maxScore = students.Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase)).Max(s => s.AverageScore);
            var topStudents = students.Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase) && s.AverageScore == maxScore);
            foreach (var student in topStudents)
            {
                student.Show();
            }
        }

        static void CountStudentsByClassification(List<Student> students)
        {
            Console.WriteLine("So luong cua tung xep loai trong danh sach:");
            var classifications = new Dictionary<string, int>
            {
                {"Xuat sac", 0 },
                { "Gioi", 0 },
                { "Kha", 0 },
                { "Trung Binh", 0 },
                { "Yeu", 0 }
            };
            foreach (var student in students)
            {
                if (student.AverageScore >= 9)
                {
                    classifications["Xuat sac"]++;
                }
                else
                if (student.AverageScore >= 8)
                {
                    classifications["Gioi"]++;
                }
                else if (student.AverageScore >= 7)
                {
                    classifications["Kha"]++;
                }
                else if (student.AverageScore >= 5)
                {
                    classifications["Trung Binh"]++;
                }
                else if (student.AverageScore >= 4)
                {
                    classifications["Yeu"]++;
                }
                else
                {
                    classifications["Kem"]++;
                }
            }
            foreach (var classification in classifications)
            {
                Console.WriteLine($"{classification.Key}: {classification.Value}");
            }
        }
    }
}
