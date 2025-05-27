namespace DevQuestions.Contracts.Questions;

public record CreateQuestionDto(Guid UserId, string Title, string Text, Guid[] TagIds);