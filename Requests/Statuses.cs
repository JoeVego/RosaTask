namespace FirstApp.Requests
{
    // <summary>
    /// Перечисление состояния заявок.
    /// Состония новый, в процессе, готова идут последовательно.
    /// заявка может быть отклонена из статуса в процессе.
    /// и может быть возвращена в работу в тот же статус
    /// </summary>
    public enum Statuses
    {
        New,
        InProcess,
        Completed,
        Rejected
    }
}