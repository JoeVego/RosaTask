using FirstApp.Certificates;
using FirstApp.Employees;
using FirstApp.Requests;

class Program
{
    static string InputString()
    {
        while (true)
        {
            Console.Write("Ввод = ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, попробуйте снова");
            }
        }
    }

    static int InputInt()
    {
        while (true)
        {
            Console.Write("Введите число = ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, попробуйте снова");
            }
        }
    }
    static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>();
        bool exit = false;
        Console.WriteLine("Добро пожаловать в сервис справок сотрудников.");

        while (!exit)
        {
            Console.WriteLine("\nВыберите действие:\n0.Создать сотрудника" +
            "\n1.Войти в профиль сотрудника\n2.Завершить выполнение программы");
            int mainMenu = InputInt();

            if (mainMenu == 0)
            {
                Console.WriteLine("\nВведите имя сотрудника:");
                string fNameInput = InputString();

                Console.WriteLine("\nВыберите должность сотрудника:" +
                    "\n0. Бухгалтер\n1. Разработчик");
                int createEmployeePos = InputInt();

                if (createEmployeePos == 0)
                {
                    employees.Add(new Accountant(fNameInput, EmployeePositions.Accountant));
                    Console.WriteLine($"Сотрудник {fNameInput} должности бухгалтер создан");
                }
                else if (createEmployeePos == 1)
                {
                    employees.Add(new Programmer(fNameInput, EmployeePositions.Programmer));
                    Console.WriteLine($"Сотрудник {fNameInput} создан");
                }
                else
                {
                    Console.WriteLine($"\nОшибка создания сотрудника с именем {fNameInput}");
                }

            }
            else if (mainMenu == 1)
            {
                int counter = 0;
                Console.WriteLine("\nСписок сотрудников:");
                foreach (Employee empl in employees)
                {
                    Console.WriteLine($"{counter}. " + empl);
                    counter++;
                }

                Console.WriteLine("\nВведите номер выбранного сотрудника:");
                int emplIdx = InputInt();
                Employee currentEmpl = employees[emplIdx];

                if (currentEmpl.position == EmployeePositions.Programmer)
                {
                    Console.WriteLine($"\nCотруднику {currentEmpl.GetName()} " +
                        $"доступны операции:\n1.Заказать справку" +
                        $"\n2.Получить информацию о заказанных справках");
                    int progOperation = InputInt();

                    if (progOperation == 1)
                    {
                        Console.WriteLine($"\nВведите тип требуемой справки" +
                            $"(2-НДФЛ,по месту работы, средний доход," +
                            $"свободной формы)");
                        string reqCertType = InputString();

                        CertificateTypes? newCertType = null;
                        switch (reqCertType)
                        {
                            case "2-НДФЛ": 
                                newCertType = CertificateTypes.NDFL2;
                                break;
                            case "по месту работы":
                                newCertType = CertificateTypes.JobPlace;
                                break;
                            case "средний доход":
                                newCertType = CertificateTypes.AverageIncome;
                                break;
                            case "свободной формы":
                                newCertType = CertificateTypes.FreeType;
                                break;
                            default: Console.WriteLine("\nУказан несуществующий тип справки." +
                                "Попробуйте оформить справку заново");
                                break;
                        }

                        Console.WriteLine($"\nВведите кол-во справок для заказа:");
                        int reqCertAmount = InputInt();

                        Console.WriteLine($"\nВведите причину заказа справки");
                        string reqCertReason = InputString();

                        if (newCertType.HasValue)
                        {
                            currentEmpl.RequestCertificate(newCertType.Value, reqCertAmount, reqCertReason);
                        }
                        //currentEmpl.RequestCertificate(newCertType, reqCertAmount, reqCertReason);
                    }
                    if (progOperation == 2)
                    {
                        Console.WriteLine($"\nСписок справок сотрудника {currentEmpl.GetName()} :");
                        foreach(Request req in currentEmpl.GetEmployeeRequests())
                        {
                            Console.WriteLine(req);
                        }
                    }
                }
                else if (currentEmpl.position == EmployeePositions.Accountant)
                {
                    Console.WriteLine($"\nCотруднику {currentEmpl.GetName()} " +
                        $"доступны операции:\n1.Посмотреть детали запроса" +
                        $"\n2.Изменить статус запроса" +
                        $"\n3.Заказать справку" +
                        $"\n4.Получить информацию о заказанных справках");
                    int accOperation = InputInt();

                    if (accOperation == 1)
                    {
                        Console.WriteLine("\nСписок сотрудников:");

                        int index = 0;
                        foreach (Employee empl in employees)
                        {
                            Console.WriteLine($"{index}. " + empl.GetName());
                            index++;
                        }

                        Console.WriteLine("\nВведите номер сотрудника, чьи справки требуется посмотреть = ");
                        int accEmplIdx = InputInt();

                        Employee accEmpl = employees[accEmplIdx];
                        Console.WriteLine($"\nСотрудник {accEmpl.GetName()}" +
                            $"имеет {accEmpl.GetEmployeeRequests().Count} справок.");

                        int cntr = 0;
                        foreach (Request req in accEmpl.GetEmployeeRequests())
                        {
                            Console.WriteLine($"{cntr}. " + req.GetCertTypeName());
                            cntr++;
                        }

                        Console.WriteLine("\nВведите номер справки = ");
                        int reqId = InputInt();

                        Console.WriteLine($"\nИнформация по справке:" +
                            $"\n{accEmpl.GetEmployeeRequests()[reqId]}");
                    }
                    if (accOperation == 2)
                    {
                        Console.WriteLine("\nСписок сотрудников доступных для изменения статуса заявок:");

                        int index = 0;
                        foreach (Employee empl in employees)
                        {
                            Console.WriteLine($"{index}. " + empl.GetName());
                            index++;
                        }

                        Console.WriteLine("\nВведите номер нужного сотрудника = ");
                        int accEmplIdx = InputInt();

                        Employee accEmpl = employees[accEmplIdx];
                        Console.WriteLine($"\nСотрудник {accEmpl.GetName()}" +
                            $"имеет {accEmpl.GetEmployeeRequests().Count} справок.");

                        int cntr = 0;
                        foreach (Request req in accEmpl.GetEmployeeRequests())
                        {
                            Console.WriteLine($"{cntr}. " + req.GetCertTypeName());
                            cntr++;
                        }

                        Console.WriteLine("\nВведите номер справки, по которой требуется изменить статус = ");
                        //int reqId = InputInt();
                        //if (reqId >= accEmpl.GetEmployeeRequests().Count)
                        //{
                        //    Console.WriteLine("Введен неверный номер справки." +
                        //        "\nВведите номер справки повторно.");
                        //    reqId = InputInt();

                        //}
                        int requestsCount = accEmpl.GetEmployeeRequests().Count;
                        int reqId;
                        do
                        {
                            reqId = InputInt();
                            if (reqId < 0 || reqId >= requestsCount)
                            {
                                Console.WriteLine("Введен неверный номер справки." +
                                    "\nВведите номер справки повторно.");
                            }
                        } while (reqId < 0 || reqId >= requestsCount);

                        // проверка выхода за пределы массива
                        IRequestState currentReqStatus = accEmpl.GetEmployeeRequests()[reqId].GetCertStatus();
                        Console.WriteLine($"\nСправка имеет статус = " +
                            $" {accEmpl.GetEmployeeRequests()[reqId].GetCertStatusName()}");

                        //не нравится, но лучше не придумал
                        Accountant currentEmpl2 = (Accountant)currentEmpl;
                        currentEmpl2.ChangeReqState(currentReqStatus, accEmpl, reqId);
                    }
                    else if (accOperation == 3)
                    {
                        Console.WriteLine($"\nВведите тип требуемой справки(2-НДФЛ,по месту работы, средний доход," +
                            $"свободной формы) :");
                        string reqCertType = InputString();

                        CertificateTypes? newCertType = null;
                        switch (reqCertType)
                        {
                            case "2-НДФЛ":
                                newCertType = CertificateTypes.NDFL2;
                                break;
                            case "по месту работы":
                                newCertType = CertificateTypes.JobPlace;
                                break;
                            case "средний доход":
                                newCertType = CertificateTypes.AverageIncome;
                                break;
                            case "свободной формы":
                                newCertType = CertificateTypes.FreeType;
                                break;
                            default:
                                Console.WriteLine("\nУказан несуществующий тип справки" +
                                    "Попробуйте оформить справку заново");
                                break;
                        }

                        Console.WriteLine($"\nВведите кол-во справок для заказа:");
                        int reqCertAmount = InputInt();

                        Console.WriteLine($"\nВведите причину заказа справки");
                        string reqCertReason = InputString();

                        if (newCertType.HasValue)
                        {
                            currentEmpl.RequestCertificate(newCertType.Value, reqCertAmount, reqCertReason);
                        }
                    }
                    if (accOperation == 4)
                    {
                        Console.WriteLine($"\nСписок справок сотрудника {currentEmpl.GetName()} :");
                        foreach (Request req in currentEmpl.GetEmployeeRequests())
                        {
                            Console.WriteLine(req);
                        }
                    }
                }
            }
            else if(mainMenu == 2)
            {
                //выход из программы
                Environment.Exit(0);
            }
        }
     }
}