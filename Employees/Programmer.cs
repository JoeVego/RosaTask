using System;
using System.Collections.Generic;
using System.Text;

namespace FirstApp.Employees
{
    internal class Programmer(string firstName, EmployeePositions position) : Employee(firstName, position)
    {
    }
}
