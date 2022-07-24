using Domain.Models.Canvas;
using Domain.Settings;

namespace Domain.Repositories
{
    public interface ICanvasRepository
    {
        Task<IEnumerable<Course>> GetCourses(CancellationToken cancellationToken = default);

        Task<Course?> GetCourse(string id, CancellationToken cancellationToken = default);

        bool Connect(CanvasOptions? canvasOptions);

        Task<IEnumerable<Assignment>> GetAssignments(int courseId, CancellationToken cancellationToken = default);

        Task<Assignment?> GetAssignment(int courseId, string id, CancellationToken cancellationToken = default);
    }
}
