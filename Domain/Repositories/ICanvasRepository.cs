using Domain.Models.Canvas;

namespace Domain.Repositories
{
    public interface ICanvasRepository
    {
        Task<IEnumerable<Course>> GetCourses(CancellationToken cancellationToken = default);

        Task<Course?> GetCourse(string id, CancellationToken cancellationToken = default);


        Task<IEnumerable<Assignment>> GetAssignments(string courseId, CancellationToken cancellationToken = default);

        Task<Assignment?> GetAssignment(string courseId, string id, CancellationToken cancellationToken = default);
    }
}
