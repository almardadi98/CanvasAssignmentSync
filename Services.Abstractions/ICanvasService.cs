using Contracts;

namespace Services.Abstractions
{
    public interface ICanvasService
    {
        // Course methods
        Task<IEnumerable<CourseDto>> GetCourses(CancellationToken cancellationToken = default);

        Task<CourseDto?> GetCourse(string id, CancellationToken cancellationToken = default);


        // Assignment methods
        Task<IEnumerable<AssignmentDto>> GetAssignments(string courseId, CancellationToken cancellationToken = default);

        Task<AssignmentDto?> GetAssignment(string courseId, string id, CancellationToken cancellationToken = default);

    }
}
