using CanvasAssignmentSync.Data;
using CanvasAssignmentSync.Models;

namespace CanvasAssignmentSync.Tests.Data
{
    public class CanvasServiceTest
    {
        [Fact]
        public void SetShouldSyncStatusWorks()
        {
            //var canvasService = new CanvasService();

            var coursesFromCanvas = new List<Course>
            {
                new() {Id=1000, ShouldSync = false, Name = "Stærðfræði 3", StartAt = new DateTime(1998, 9, 19)},
                new() {Id=1001, ShouldSync = false, Name = "Mechatronics 5", StartAt = new DateTime(1998, 9, 19)},
                new() {Id=1002, ShouldSync = false, Name = "UML for dummies", StartAt = new DateTime(1998, 9, 19)},
                new() {Id=1003, ShouldSync = false, Name = "Linear Algebra", StartAt = new DateTime(1998, 9, 19)}
                };
            var coursesFromDb = new List<Course>
            {
                new() {Id=1000, ShouldSync = true, Name = "Stærðfræði 3", StartAt = new DateTime(1998, 9, 19)},
                new() {Id=1001, ShouldSync = false, Name = "Mechatronics 5", StartAt = new DateTime(1998, 9, 19)},
                new() {Id=1002, ShouldSync = true, Name = "UML for dummies", StartAt = new DateTime(1998, 9, 19)},
                new() {Id=1003, ShouldSync = false, Name = "Linear Algebra", StartAt = new DateTime(1998, 9, 19)}
            };

        }
    }
}
