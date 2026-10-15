
using WestcoastEdukation.Models;
using WestcoastEdukation.Services;


// Skapa Data-mappen om den inte finns
Directory.CreateDirectory("Data");

// Listor och inläsning från JSON
List<Course> courses = JsonService.LoadData<Course>("Data/courses.json");
List<Student> students = JsonService.LoadData<Student>("Data/students.json");
List<Teacher> teachers = JsonService.LoadData<Teacher>("Data/teachers.json");
List<EducationLeader> educationLeaders = JsonService.LoadData<EducationLeader>("Data/educationLeaders.json");
List<Administrator> administrators = JsonService.LoadData<Administrator>("Data/administrators.json");
List<Employee> employees = JsonService.LoadData<Employee>("Data/employees.json");


foreach (Course course in courses)
{
    foreach (Teacher teacher in teachers)
    {
        if (course.TeacherPersonalNumber == teacher.PersonalNumber
            && !string.IsNullOrEmpty(course.TeacherPersonalNumber))
        {
            course.Teacher = teacher;
            break;
        }
    }
}

foreach (Course course in courses)
{
    foreach (Student student in students)
    {
        if (course.StudentPersonalNumber.Contains(student.PersonalNumber))
        {
            course.Students.Add(student);
            student.Courses.Add(course);
        }
    }
}


while (true)
{
    Console.WriteLine("\n    WESTCOAST EDUCATION");
    Console.WriteLine("1.  Lägg till kurs");
    Console.WriteLine("2.  Visa alla kurser");
    Console.WriteLine("3.  Lägg till student");
    Console.WriteLine("4.  Visa alla studenter");
    Console.WriteLine("5.  Lägg till lärare");
    Console.WriteLine("6.  Visa alla lärare");
    Console.WriteLine("7.  Lägg till utbildningsledare");
    Console.WriteLine("8.  Visa alla utbildningsledare");
    Console.WriteLine("9.  Lägg till administratör");
    Console.WriteLine("10. Visa alla administratörer");
    Console.WriteLine("11. Tilldela lärare till kurs");
    Console.WriteLine("12. Lägg till student på kurs");
    Console.WriteLine("13. Lägg till anställd");
    Console.WriteLine("14. Visa alla anställda");
    Console.WriteLine("0.  Avsluta");

    Console.Write("\nVälj ett alternativ: ");
    string choice = Console.ReadLine() ?? "";

    switch (choice)
    {
        
        case "1":
            Console.WriteLine("Lägg till kurs");

            Course course = CourseService.RegisterCourse();

            courses.Add(course);
            SaveCourses(courses);

            Console.WriteLine("Kursen har lagts till!");
            break;


        case "2":
            Console.WriteLine("Visa alla kurser");

            if (courses.Count == 0)
            {
                Console.WriteLine("Det finns inga kurser registrerade.");
            }
            else
            {
                foreach (Course c in courses)
                {
                    Console.WriteLine(c.ToString());

                    if (c.Students.Count == 0)
                    {
                        Console.WriteLine("Inga studenter registrerade på kursen!");
                    }
                    else
                    {
                        Console.WriteLine("Studenter på kursen: ");

                        foreach (Student s in c.Students)
                        {
                            Console.WriteLine($"  -{s.FirstName} {s.LastName}");
                        }
                        
                            
        
                    }
                }
            }
            break;

        case "3":
            Console.WriteLine("Lägg till student");

            Student student = new Student();

            RegistrationService.RegisterPerson(student);

            students.Add(student);
            SaveStudents(students);

            Console.WriteLine("Studenten har lagts till!");
            break;

        case "4":
            Console.WriteLine("Visa alla studenter");

            if (students.Count == 0)
            {
                Console.WriteLine("Det finns inga studenter registrerade.");
            }
            else
            {
                foreach (Student s in students)
                {
                    Console.WriteLine(s.ToString());
                }
            }
            break;

        case "5":
            Console.WriteLine("Lägg till lärare");

            Teacher teacher = new Teacher();

            RegistrationService.RegisterEmployee(teacher);

            teachers.Add(teacher);
            SaveTeachers(teachers);

            Console.WriteLine("Läraren har lagts till!");
            break;

        case "6":
            Console.WriteLine("Visa alla lärare");

            if (teachers.Count == 0)
            {
                Console.WriteLine("Det finns inga lärare registrerade.");
            }
            else
            {
                foreach (Teacher t in teachers)
                {
                    Console.WriteLine(t.ToString());
                }
            }
            break;

        case "7":
            Console.WriteLine("Lägg till utbildningsledare");

            EducationLeader educationLeader = new EducationLeader();

            RegistrationService.RegisterEmployee(educationLeader);

            educationLeaders.Add(educationLeader);
            SaveEducationLeaders(educationLeaders);

            Console.WriteLine("Utbildningsledaren har lagts till!");
            break;

        case "8":
            Console.WriteLine("Visa alla utbildningsledare");

            if (educationLeaders.Count == 0)
            {
                Console.WriteLine("Det finns inga utbildningsledare registrerade.");
            }
            else
            {
                foreach (EducationLeader leader in educationLeaders)
                {
                    Console.WriteLine(leader.ToString());
                }
            }
            break;

        case "9":
            Console.WriteLine("Lägg till administratör");

            Administrator administrator = new Administrator();

            RegistrationService.RegisterEmployee(administrator);

            administrators.Add(administrator);
            SaveAdministrators(administrators);

            Console.WriteLine("Administratören har lagts till!");
            break;

        case "10":
            Console.WriteLine("Visa alla administratörer");

            if (administrators.Count == 0)
            {
                Console.WriteLine("Det finns inga administratörer registrerade.");
            }
            else
            {
                foreach (Administrator admin in administrators)
                {
                    Console.WriteLine(admin.ToString());
                }
            }
            break;

        case "11":
            Console.WriteLine("Tilldela lärare till kurs");

            if (courses.Count == 0 || teachers.Count == 0)
            {
                Console.WriteLine("Registrera minst en kurs och en lärare först.");
                break;
            }

            Console.WriteLine("\nTillgängliga kurser:");

            foreach (Course c in courses)
            {
                Console.WriteLine($"{c.CourseNumber} - {c.Title}");
            }

            Console.Write("\nAnge kursnummer: ");
            string number = Console.ReadLine() ?? "";

            Console.WriteLine("\nLärare:");

            foreach (Teacher t in teachers)
            {
                Console.WriteLine(t.FirstName + " " + t.LastName);
            }

            Console.Write("Ange lärarens efternamn: ");
            string lastName = Console.ReadLine() ?? "";

            bool teacherAssigned = false;

            foreach (Course c in courses)
            {
                if (c.CourseNumber == number)
                {
                    foreach (Teacher t in teachers)
                    {
                        if (t.LastName == lastName)
                        {
                            c.Teacher = t;
                            c.TeacherPersonalNumber = t.PersonalNumber;

                            SaveCourses(courses);

                            teacherAssigned = true;

                            Console.WriteLine("Läraren har kopplats till kursen!");
                            break;
                        }
                    }
                    break;
                }
            }

            if (!teacherAssigned)
            {
                Console.WriteLine("Kursen eller läraren hittades inte.");
            }

            break;

        case "12":
            Console.WriteLine("Lägg till student på kurs");

            if (courses.Count == 0 || students.Count == 0)
            {
                Console.WriteLine("Registrera minst en kurs och en student först.");
                break;
            }

            Console.WriteLine("\nKurser:");

            foreach (Course c in courses)
            {
                Console.WriteLine(c.CourseNumber + " - " + c.Title);
            }

            Console.Write("Ange kursnummer: ");
            string studentCourseNumber = Console.ReadLine() ?? "";

            Console.WriteLine("\nStudenter:");

            foreach (Student s in students)
            {
                Console.WriteLine(s.FirstName + " " + s.LastName);
            }

            Console.Write("Ange studentens personnummer: ");
            string studentPersonalNumber = Console.ReadLine() ?? "";

            bool studentFound = false;

            foreach (Course c in courses)
            {
                if (c.CourseNumber.ToLower() == studentCourseNumber.ToLower())
                {
                    foreach (Student s in students)
                    {
                        if (s.PersonalNumber == studentPersonalNumber)
                        {
                            studentFound = true;

                            if (!c.Students.Contains(s))
                            {
                                c.Students.Add(s);
                                s.Courses.Add(c);

                                if (!c.StudentPersonalNumber.Contains(s.PersonalNumber))
                                {
                                    c.StudentPersonalNumber.Add(s.PersonalNumber);
                                }

                                SaveCourses(courses);

                                Console.WriteLine("Studenten har lagts till på kursen!");
                            }
                            else
                            {
                                Console.WriteLine("Studenten finns redan på kursen.");
                            }
                            break;
                        }
                    }
                    break;
                }
            }

            if (!studentFound)
            {
                Console.WriteLine("Kursen eller studenten hittades inte.");
            }

            break;

        case "13":
            Console.WriteLine("Lägg till anställd");

            Employee employee = new Employee();

            RegistrationService.RegisterEmployee(employee);

            employees.Add(employee);
            SaveEmployees(employees);

            Console.WriteLine("Den anställde har lagts till!");
            break;

        case "14":
            Console.WriteLine("Visa alla anställda");

            if (employees.Count == 0)
            {
                Console.WriteLine("Det finns inga anställda registrerade.");
            }
            else
            {
                foreach (Employee e in employees)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            break;

        case "0":
            Console.WriteLine("Avsluta");
            return;

        default:
            Console.WriteLine("Felaktigt val, försök igen.");
            break;
    }
}



static void SaveCourses(List<Course> courses)
{
    JsonService.SaveData(courses, "Data/courses.json");

    Console.WriteLine("Kursen har sparats!");
}

static void SaveStudents(List<Student> students)
{
    JsonService.SaveData(students, "Data/students.json");

    Console.WriteLine("Studenten har sparats!");
}

static void SaveTeachers(List<Teacher> teachers)
{
    JsonService.SaveData(teachers,"Data/teachers.json");

    Console.WriteLine("Läraren har sparats!");
}

static void SaveEducationLeaders(List<EducationLeader> educationLeaders)
{
    JsonService.SaveData(educationLeaders, "Data/educationLeaders.json");

    Console.WriteLine("Utbildningsledaren har sparats!");
}

static void SaveAdministrators(List<Administrator> administrators)
{
    JsonService.SaveData(administrators, "Data/administrators.json");

    Console.WriteLine("Administratören har sparats!");
}

static void SaveEmployees(List<Employee> employees)
{
    JsonService.SaveData(employees, "Data/employees.json");

    Console.WriteLine("Den anställde har sparats!");
}
