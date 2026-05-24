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
        private IRequestState state;

        public Request(Employee employee, CertificateTypes certType, int amount, string reason)
        {
            this.employee = employee;
            this.certificate = new Certificate(certType, employee);
            this.amount = amount;
            this.reason = reason;
            this.state = new InitRequest();
            state.Create(this);
        }

        public void SetState(IRequestState stateToSet)
        {
            this.state = stateToSet;
        }

        public void TakeToWork()
        {
            state.TakeToWork(this);
        }

        public void Reject()
        {
            state.Reject(this);
        }

        public void Complete()
        {
            state.Complete(this);
        }


        public override string ToString()
        {
            return $"Запрос справки сотрудником = {employee}, где тип справки = {certificate.GetCertificateType()}, " +
                $"количество = {amount}, причина запроса = {reason}, статус заявки = {state}";
        }
    }

}
