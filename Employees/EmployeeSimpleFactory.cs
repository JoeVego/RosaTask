namespace FirstApp.Employees
{
    //выбрал шаблон SimpleFactory, посчитал удобным, раз имеем родительский класс
    // и с учетом, что различных должностей сотрудников может быть много.
    internal class EmployeeSimpleFactory
    {
        public Employee СreateEmployee(String fName, EmployeePositions position) 
        {
            switch (position)
            {
                case EmployeePositions.Accountant:
                    return new Accountant(fName, position);

                case EmployeePositions.Programmer: 
                    return new Programmer(fName, position);

                default:
                    throw new ArgumentException("Указан неверный тип клиента");
            }
        }
    }
}
