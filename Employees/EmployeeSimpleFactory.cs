using System;
using System.Collections.Generic;
using System.Text;

namespace FirstApp.Employees
{
    //выбрал шаблон SimpleFactory, посчитал удобным, раз имеем родительский класс
    // и с учетом, что различных должностей сотрудников может быть много.
    internal class EmployeeSimpleFactory
    {
        public Employee createEmployee(EmployeePositions position) 
        {
            switch (position)
            {
                case EmployeePositions.Accountant:
                    return new Accountant();

                case EmployeePositions.Programmer: 
                    return new Programmer();

                default:
                    throw new ArgumentException("Invalid employee type");
            }
        }
    }
}
