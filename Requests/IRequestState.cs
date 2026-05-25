using System;
using System.Collections.Generic;
using System.Text;

namespace FirstApp.Requests
{
    //выбрал шаблон состояния, т.к. состояний может быть множество с сложными связями/переходами
    //например статусы: назначения, согласования, выдачи, подписания
    //возможно, лишнее усложнение получилось
    internal interface IRequestState
    {
        public void TakeToWork(Request request)
        {
            Console.WriteLine("Извините, на данном этапе нельзя перевести заявку в статус В работе");
        }
        void Reject(Request request)
        {
            Console.WriteLine("Извините, на данном этапе нельзя перевести заявку в статус Отклонена");
        }
        void Complete(Request request)
        {
            Console.WriteLine("Извините, на данном этапе нельзя перевести заявку в статус Готова");
        }
        void Create(Request request)
        {
            Console.WriteLine("Извините, на данном этапе нельзя перевести заявку в статус Новый");
        }
    }

    internal class NewRequest : IRequestState
    {
        public void TakeToWork(Request request)
        {
            request.SetState(new RequestInProcess());
            Console.WriteLine("Заявка в работе");
        }

        public override string ToString()
        {
            return "Новый";
        }
    }

    internal class RequestInProcess : IRequestState
    {
        public void Reject(Request request)
        {
            request.SetState(new RejectedRequest());
            Console.WriteLine("Заявка отклонена");
        }

        public void Complete(Request request)
        {
            request.SetState(new RequestCompleted());
            Console.WriteLine("Заявка готова");
        }

        public override string ToString()
        {
            return "В работе";
        }
    }

    internal class RejectedRequest : IRequestState
    {
        public void TakeToWork(Request request)
        {
            request.SetState(new RequestInProcess());
            Console.WriteLine("Заявка в работе");
        }

        public override string ToString()
        {
            return "Отклонена";
        }
    }

    internal class InitRequest : IRequestState
    {
        public void Create(Request request)
        {
            request.SetState(new NewRequest());
            Console.WriteLine("Заявка создана");
        }

        public override string ToString()
        {
            return "Заявка создана";
        }
    }

    internal class RequestCompleted : IRequestState {
        public override string ToString()
        {
            return "Завершена";
        }
    }
}