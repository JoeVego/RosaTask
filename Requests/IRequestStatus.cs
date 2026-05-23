using System;
using System.Collections.Generic;
using System.Text;

namespace FirstApp.Requests
{
    //выбрал шаблон состояния, т.к. состояний может быть множество с сложными связями/переходами
    //например статусы: назначения, согласования, выдачи, подписания
    // не нравится обработка ошибок
    internal interface IRequestState
    {
        void TakeToWork(Request request)
        {
            throw new ArgumentException("Извините, на данном этапе нельзя перевести заявку в статус В работе");
        }
        void Reject(Request request)
        {
            throw new ArgumentException("Извините, на данном этапе нельзя перевести заявку в статус Отклонена");
        }
        void Complete(Request request)
        {
            throw new ArgumentException("Извините, на данном этапе нельзя перевести заявку в статус Готова");
        }
    }

    internal class NewState : IRequestState
    {
        public void TakeToWork(Request request)
        {
            request.SetState(Statuses.InProcess);
            Console.WriteLine("Заявка в работе");
        }
    }

    internal class InProcessState : IRequestState
    {
        public void Reject(Request request)
        {
            request.SetState(Statuses.Rejected);
            Console.WriteLine("Заявка отклонена");
        }

        public void Complete(Request request)
        {
            request.SetState(Statuses.Completed);
            Console.WriteLine("Заявка готова");
        }
    }

    internal class RejectedState : IRequestState
    {
        public void TakeToWork(Request request)
        {
            request.SetState(Statuses.InProcess);
            Console.WriteLine("Заявка в работе");
        }
    }
}