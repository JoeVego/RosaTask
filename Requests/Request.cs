using System;
using System.Collections.Generic;
using System.Text;
using FirstApp.Certificates;
using FirstApp.Employees;

namespace FirstApp.Requests
{
    internal class Request
    {
        private Employee employee;
        private Certificate certificate;
        private int amount;
        private string reason;
        private Statuses state;

        public Request(Employee employee, CertificateTypes certType, int amount, string reason)
        {
            this.employee = employee;
            this.certificate = new Certificate(certType, employee);
            this.amount = amount;
            this.reason = reason;
            this.state = Statuses.New;
        }

        // не приват ведь для буха метод
        private void getCertInfo()
        {
            // сделать
        }

        // не приват ведь для буха метод
        private void changeState()
        {
            // меняем статус
        }

        public void SetState(Statuses newState)
        {
            this.state = newState;
        }

        public override string ToString()
        {
            return $"Запрос справки сотрудником = {employee}, где тип справки = {certificate.GetCertificateType()}, " +
                $"количество = {amount}, причина запроса = {reason}, статус заявки = {state}";
        }
    }

}
