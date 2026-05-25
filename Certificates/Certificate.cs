using FirstApp.Employees;

namespace FirstApp.Certificates
{
    /// <summary>
    /// Класс справки содержит информацию о заказчике справки
    /// и ее типе
    /// </summary>
    internal class Certificate
    {
        private CertificateTypes certificateType;
        private Employee employee;

        public Certificate(CertificateTypes certificateType, Employee employee)
        {
            this.certificateType = certificateType;
            this.employee = employee;
        }

        internal CertificateTypes GetCertificateType()
        {
            return certificateType;
        }

        public string GetCertTypeName()
        {
            return certificateType switch
            {
                CertificateTypes.NDFL2 => "2-НДФЛ",
                CertificateTypes.JobPlace => "по месту работы",
                CertificateTypes.AverageIncome => "средний доход",
                CertificateTypes.FreeType => "свободной формы",
                _ => "Некорректный тип справки",
            };
        }
    }
}
