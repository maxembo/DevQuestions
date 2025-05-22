using DevQuestions.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DevQuestions.Presenters;

[ApiController]
[Route("[controller]")]
public class QuestionsController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetQuestionsDto request, CancellationToken cancellationToken)
    {
        return Ok("Question all get");
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateQuestionDto request, CancellationToken cancellationToken)
    {
        return Ok("Question created");
    }

    [HttpGet("{questionId:guid}")]
    public async Task<IActionResult> GetBy([FromRoute] Guid questionId, CancellationToken cancellationToken)
    {
        return Ok("Question get");
    }

    [HttpPut("{questionId:guid}")]
    public async Task<IActionResult> Update(
        [FromRoute] Guid questionId,
        [FromBody] UpdateQuestionDto request,
        CancellationToken cancellationToken)
    {
        return Ok("Question updated");
    }

    [HttpDelete("{questionId:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid questionId, CancellationToken cancellationToken)
    {
        return Ok("Question deleted");
    }

    [HttpPost("{questionId:guid}/answers")]
    public async Task<IActionResult> AddAnswer(
        [FromRoute] Guid questionId,
        [FromBody] AddAnswerDto request,
        CancellationToken cancellationToken)
    {
        return Ok("Answer added");
    }

    [HttpPost("{questionId:guid}/comments")]
    public async Task<IActionResult> AddComment(
        [FromRoute] Guid questionId,
        [FromBody] AddCommentDto request,
        CancellationToken cancellationToken)
    {
        return Ok("Comment added");
    }

    [HttpPut("{questionId:guid}/solution")]
    public async Task<IActionResult> SelectSolution(
        [FromRoute] Guid questionId,
        [FromQuery] Guid answerId,
        CancellationToken cancellationToken)
    {
        return Ok("Solution selected");
    }
}