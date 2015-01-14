using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace LINQToExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter input file: ");
            string file = Console.ReadLine();
            var students = new List<Student>();
            using (var inputFile = new StreamReader(file))
            {
                inputFile.ReadLine();
                while (!inputFile.EndOfStream)
                {
                    try
                    {
                        string[] studentData = inputFile.ReadLine().Split('\t');
                        var student = new Student();
                        student.ID = int.Parse(studentData[0]);
                        student.FirstName = studentData[1];
                        student.LastName = studentData[2];
                        student.Email = studentData[3];
                        student.Gender = studentData[4];
                        student.StudentType = studentData[5];
                        student.ExamResult = int.Parse(studentData[6]);
                        student.HomeworkSent = int.Parse(studentData[7]);
                        student.HomeworkEvaluated = int.Parse(studentData[8]);
                        student.Teamwork = double.Parse(studentData[9]);
                        student.Attendances = int.Parse(studentData[10]);
                        student.Bonus = double.Parse(studentData[11]);
                        students.Add(student);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            try
            {
                using (var fileStream = File.Open("students.xlsx", FileMode.Create))
                using (var excel = new ExcelPackage(fileStream))
                {
                    var onlineStudents = students
                        .Where(x => x.StudentType == "Online")
                        .OrderBy(x => x.CalculateResult());
                    CreateTable(excel, onlineStudents);
                    Console.WriteLine("Done!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void CreateTable(ExcelPackage excel, IOrderedEnumerable<Student> onlineStudents)
        {
            var worksheet = excel.Workbook.Worksheets.Add("Students");
            BuildHeader(worksheet);
            int index = 3;
            foreach (var student in onlineStudents)
            {
                worksheet.Cells["A" + index].Value = student.ID;
                worksheet.Cells["B" + index].Value = student.FirstName;
                worksheet.Cells["C" + index].Value = student.LastName;
                worksheet.Cells["D" + index].Value = student.Email;
                worksheet.Cells["E" + index].Value = student.Gender;
                worksheet.Cells["F" + index].Value = student.StudentType;
                worksheet.Cells["G" + index].Value = student.ExamResult;
                worksheet.Cells["H" + index].Value = student.HomeworkSent;
                worksheet.Cells["I" + index].Value = student.HomeworkEvaluated;
                worksheet.Cells["J" + index].Value = student.Teamwork;
                worksheet.Cells["K" + index].Value = student.Attendances;
                worksheet.Cells["L" + index].Value = student.Bonus;
                worksheet.Cells["M" + index].Value = student.Result;
                index++;
            }
            worksheet.Cells.AutoFitColumns(0);

            using (ExcelRange r = worksheet.Cells["M3:M" + index])
            {
                r.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                r.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 255, 32));
            }

            using (ExcelRange r = worksheet.Cells["A2:M2"])
            {
                r.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.DarkHorizontal;
                r.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 255, 100));
            }

            using (ExcelRange r = worksheet.Cells["A2:M" + index])
            {
                r.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            }

            excel.Workbook.Properties.Title = "Students";
            excel.Workbook.Properties.Author = "AlexandurSeferinkyn";
            excel.Workbook.Properties.Comments = "";
            excel.Workbook.Properties.Company = "";
            excel.Save();
        }

        private static void BuildHeader(ExcelWorksheet worksheet)
        {
            worksheet.Cells["A1"].Value = "Softuni OOP Course Results";
            using (ExcelRange r = worksheet.Cells["A1:M1"])
            {
                r.Merge = true;
                r.Style.Font.SetFromFont(new Font("Britannic Bold", 22, FontStyle.Italic));
                r.Style.Font.Color.SetColor(Color.White);
                r.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                r.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                r.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(23, 55, 93));
            }

            worksheet.Cells[2, 1].Value = "ID";
            worksheet.Cells[2, 2].Value = "First name";
            worksheet.Cells[2, 3].Value = "Last Name";
            worksheet.Cells[2, 4].Value = "Email";
            worksheet.Cells[2, 5].Value = "Gender";
            worksheet.Cells[2, 6].Value = "Student type";
            worksheet.Cells[2, 7].Value = "Exam result";
            worksheet.Cells[2, 8].Value = "Homework sent";
            worksheet.Cells[2, 9].Value = "Homework evaluated";
            worksheet.Cells[2, 10].Value = "Teamwork";
            worksheet.Cells[2, 11].Value = "Attendances";
            worksheet.Cells[2, 12].Value = "Bonus";
            worksheet.Cells[2, 13].Value = "Result";
        }
    }
}