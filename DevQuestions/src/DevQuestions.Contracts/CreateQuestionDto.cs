namespace DevQuestions.Contracts;

public record CreateQuestionDto(Guid UserId, string Title, string Text, Guid[] TagIds);