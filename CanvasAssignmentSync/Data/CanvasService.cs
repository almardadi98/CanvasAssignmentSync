using CanvasAssignmentSync.Models;

namespace CanvasAssignmentSync.Data
{
    public class CanvasService
    {


        public List<Course> CoursesList { get; set; }

        private List<Course> fakecourseList = new List<Course>
        {
            new Course {Name="Stærðfræði 2", ShouldSync=true, ID=100},
            new Course {Name="Línuleg Algebra með tölvunarfræði", ShouldSync=true, ID=101},
            new Course {Name="Kerfisgreining og kerfishönnun", ShouldSync=false, ID=110},
            new Course {Name="Nýsköpun og stofnun fyrirtækja", ShouldSync=true, ID=111},
        };

        public async Task<List<Course>> GetCourseListAsync()
        {

            return await Task.FromResult(fakecourseList);
        }


    }
}
