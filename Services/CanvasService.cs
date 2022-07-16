using Contracts;
using Domain.Repositories;
using Services.Abstractions;
using Mapster;

namespace Services
{

    internal sealed class CanvasService : ICanvasService
    {
        private readonly IRepositoryManager _repositoryManager;

        public CanvasService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<CourseDto>> GetCourses(CancellationToken cancellationToken = default)
        {
            var courses =  await _repositoryManager.CanvasRepository.GetCourses(cancellationToken);

            var coursesDto = courses.Adapt<IEnumerable<CourseDto>>();

            return coursesDto;
        }

        public async Task<CourseDto?> GetCourse(string id, CancellationToken cancellationToken = default)
        {
            var course = await _repositoryManager.CanvasRepository.GetCourse(id, cancellationToken);

            var courseDto = course?.Adapt<CourseDto>();

            return courseDto;
        }


        public async Task<IEnumerable<AssignmentDto>> GetAssignments(string courseId, CancellationToken cancellationToken = default)
        {
            var assignments = await _repositoryManager.CanvasRepository.GetAssignments(courseId, cancellationToken);
            
            var assignmentsDto = assignments.Adapt<IEnumerable<AssignmentDto>>();

            return assignmentsDto;
        }

        public async Task<AssignmentDto?> GetAssignment(string courseId, string id, CancellationToken cancellationToken = default)
        {
            var assignment = await _repositoryManager.CanvasRepository.GetAssignment(courseId, id, cancellationToken);

            var assignmentDto = assignment?.Adapt<AssignmentDto>();
            
            return assignmentDto;
        }
    }
}
