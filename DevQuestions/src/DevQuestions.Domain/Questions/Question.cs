namespace DevQuestions.Domain.Questions;

public class Question
{
    public Question(
        Guid id,
        Guid userId,
        string title,
        string text,
        Guid? screenshotId,
        IEnumerable<Guid> tags)
    {
        Id = id;
        UserId = userId;
        Title = title;
        Text = text;
        Tags = tags.ToList();
    }

    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string Title { get; set; }

    public string Text { get; set; }

    public Guid? ScreenshotId { get; set; }

    public List<Guid> Tags { get; set; }

    public Answer? Solution { get; set; }

    public List<Answer> Answers { get; set; } = [];

    public QuestionStatus QuestionStatus { get; set; } = QuestionStatus.Open;
}