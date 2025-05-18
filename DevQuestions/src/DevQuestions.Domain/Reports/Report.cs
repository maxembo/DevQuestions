namespace DevQuestions.Domain.Reports;

public class Report
{
    public Guid Id { get; set; }
    
    public required Guid UserId { get; set; }
    
    public required Guid ReportedUserId { get; set; }

    public required Guid? ResolvedByUserId { get; set; }
    
    public required string Reason { get; set; }
    
    public DateTime CreatedAt { set; get; }

    public DateTime? UpdatedAt { get; set; }

    public Status Status { get; set; } = Status.Open;
}